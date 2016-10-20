using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Models
{
    public abstract class Human
    {
        private const int MinNameLength = 2;
        private const int MaxNameLength = 31;
        private const string IncorectNameMessage = "Name length must be greater than {0} and small thane {1}.";
        private const string InputNullNameMessage = "Name can nit be null or empty.";

        private string firstName;
        private string lastName;

        public Human(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(InputNullNameMessage);
                }

                if (value.Length < MinNameLength || value.Length > MaxNameLength)
                {
                    throw new ArgumentException(string.Format(IncorectNameMessage, MinNameLength, MaxNameLength));
                }

                this.firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(InputNullNameMessage);
                }

                if (value.Length < MinNameLength || value.Length > MaxNameLength)
                {
                    throw new ArgumentException(string.Format(IncorectNameMessage, MinNameLength, MaxNameLength));
                }

                this.lastName = value;
            }
        }
    }
}
