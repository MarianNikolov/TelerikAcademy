using System.Collections.Generic;
using Dealership.Contracts.ReadersAndWriters;

namespace Dealership.Commands
{
    public class CommandsReader : ICommandsReader
    {
        private IReader reader;
        private ICommandTranslater commandTranslater;

        public CommandsReader(IReader reader, ICommandTranslater commandTranslater )
        {
            this.reader = reader;
            this.commandTranslater = commandTranslater;
        }

        public IList<ICommand> ReadCommands()
        {
            var commands = new List<ICommand>();

            var currentLine = this.reader.ReadLine();

            while (!string.IsNullOrEmpty(currentLine))
            {
                ICommand currentCommand = this.commandTranslater.TranslateInput(currentLine);
                commands.Add(currentCommand);

                currentLine = this.reader.ReadLine();
            }

            return commands;
        }
    }
}
