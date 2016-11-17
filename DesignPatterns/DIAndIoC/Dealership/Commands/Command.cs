using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Dealership.Commands
{
    public class Command : ICommand
    {
        private string name;
        private IList<string> parameters;

        public Command(string name, IList<string> parameters)
        {
            this.Parameters = parameters;
            this.Name = name;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {

                    throw new ArgumentNullException("Name cannot be null or empty.");
                }

                this.name = value;
            }
        }

        public IList<string> Parameters
        {
            get
            {
                return this.parameters;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("List of strings cannot be null.");
                }

                this.parameters = value;
            }
        }
    }
}
