using Dealership.Common;
using Dealership.Common.Enums;
using Dealership.Contracts;
using Dealership.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dealership.ReadersAndWriters;
using Dealership.Contracts.ReadersAndWriters;
using Dealership.Commands;
using Dealership.Reporters;

namespace Dealership.Engine
{
    public sealed class DealershipEngine : IDealershipEngine
    {
        private const string InvalidCommand = "Invalid command!";
        private const string UserNotLogged = "You are not logged! Please login first!";

        private IDealershipFactory factory;
        private ICollection<IUser> users;
        private IReporter reporter;
        private ICommandHandler commandhandler;
        private IUser loggedUser;
        ICommandsReader commandReader;

        public DealershipEngine(IDealershipFactory factory, ICommandsReader commandReader, IReporter reporter, ICommandHandler commandhandler)
        {
            this.Factory = factory;
            this.commandReader = commandReader;
            this.reporter = reporter;
            this.commandhandler = commandhandler;

            this.users = new List<IUser>();
            this.loggedUser = null;
        }

        public ICollection<IUser> Users
        {
            get { return this.users; }
            set { this.users = value; }
        }

        public IUser LoggedUser
        {
            get { return this.loggedUser; }

            set { this.loggedUser = value; }
        }

        public IDealershipFactory Factory
        {
            get
            {
                return this.factory;
            }

            set
            {
                this.factory = value;
            }
        }

        public void Start()
        {
            IList<ICommand> commands = this.commandReader.ReadCommands();
            IList<string> commandResult = this.ProcessCommands(commands);
            this.reporter.MakeReport(commandResult);
        }

        private IList<string> ProcessCommands(IList<ICommand> commands)
        {
            var reports = new List<string>();

            foreach (var command in commands)
            {
                try
                {
                    var report = this.ProcessSingleCommand(command);
                    reports.Add(report);
                }
                catch (Exception ex)
                {
                    reports.Add(ex.Message);
                }
            }

            return reports;
        }

        private string ProcessSingleCommand(ICommand command)
        {
            if (command.Name != "RegisterUser" && command.Name != "Login")
            {
                if (this.loggedUser == null)
                {
                    return UserNotLogged;
                }
            }
            else
            {
                return this.commandhandler.HandleCommand(command, this);
            }

            switch (command.Name)
            {
                default:
                    return string.Format(InvalidCommand, command.Name);
            }
        }
    }
}
