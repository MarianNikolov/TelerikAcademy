using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Dealership.Commands
{
    public class CommandTranslater : ICommandTranslater
    {
        private const char SplitCommandSymbol = ' ';
        private const string CommentOpenSymbol = "{{";
        private const string CommentCloseSymbol = "}}";

        private ICommandFactory commandFactory;

        public CommandTranslater(ICommandFactory commandFactory)
        {
            this.commandFactory = commandFactory;
        }

        public ICommand TranslateInput(string input)
        {
            var indexOfFirstSeparator = input.IndexOf(SplitCommandSymbol);
            var indexOfOpenComment = input.IndexOf(CommentOpenSymbol);
            var indexOfCloseComment = input.IndexOf(CommentCloseSymbol);

            string commandName = null;
            List<string> commandParameters = new List<string>();

            Regex regex = new Regex("{{.+(?=}})}}");

            if (indexOfFirstSeparator < 0)
            {
                commandName = input;

                IList < string > parameters = new List<string>();

                return this.commandFactory.CreateCommand(commandName, parameters);
            }

            commandName = input.Substring(0, indexOfFirstSeparator);


            if (indexOfOpenComment >= 0)
            {
                commandParameters.Add(input.Substring(indexOfOpenComment + CommentOpenSymbol.Length, indexOfCloseComment - CommentCloseSymbol.Length - indexOfOpenComment));
                input = regex.Replace(input, string.Empty);
            }

            commandParameters.AddRange(input.Substring(indexOfFirstSeparator + 1).Split(new[] { SplitCommandSymbol }, StringSplitOptions.RemoveEmptyEntries));

            return this.commandFactory.CreateCommand(commandName, commandParameters);
        }
    }
}
