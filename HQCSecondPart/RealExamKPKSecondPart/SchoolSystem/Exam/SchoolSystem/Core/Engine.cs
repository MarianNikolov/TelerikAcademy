using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using SchoolSystem.Contracts;
using SchoolSystem.Models;

namespace SchoolSystem.Core
{
    public class Engine : IEngine
    {
        private const string CommandNotFoundMassege = "The passed command is not found!";
        private const string EndCommandMessage = "End";
        private const string WhiteSpaceStringSeparator = " ";
        private const char WhiteSpaceCharSeparator = ' ';

        private IReader reader;
        private IWriter writer;

        public Engine(IReader reader, IWriter writer)
        {
            this.Reader = reader;
            this.Writer = writer;
        }

        public IReader Reader
        {
            get
            {
                return this.reader;
            }

            set
            {
                this.reader = value;
            }
        }

        public IWriter Writer
        {
            get
            {
                return this.writer;
            }

            set
            {
                this.writer = value;
            }
        }

        internal static Dictionary<int, Teacher> Teachers { get; set; } = new Dictionary<int, Teacher>();

        internal static Dictionary<int, Student> Students { get; set; } = new Dictionary<int, Student>();

        public void Start()
        {
            while (true)
            {
                try
                {
                    var command = this.reader.ReadCommand();

                    if (command == EndCommandMessage)
                    {
                        break;
                    }

                    var typeInfo = this.GetCommandTypeWithReflaction(command);

                    var currentCommand = Activator.CreateInstance(typeInfo) as ICommand;
                    var commandParameters = command.Split(WhiteSpaceCharSeparator).ToList();
                    commandParameters.RemoveAt(0);
                    this.Writer.WriteMassege(currentCommand.Execute(commandParameters));
                }
                catch (Exception ex)
                {
                    this.Writer.WriteMassege(ex.Message);
                }
            }
        }

        private TypeInfo GetCommandTypeWithReflaction(string command)
        {
            var commandName = command.Split(WhiteSpaceCharSeparator)[0];

            var assembli = this.GetType().GetTypeInfo().Assembly;
            var typeInfo = assembli.DefinedTypes
                .Where(type => type.ImplementedInterfaces.Any(inter => inter == typeof(ICommand)))
                .Where(type => type.Name.ToLower().Contains(commandName.ToLower()))
                .FirstOrDefault();

            if (typeInfo == null)
            {
                throw new ArgumentException(CommandNotFoundMassege);
            }

            return typeInfo;
        }
    }
}
