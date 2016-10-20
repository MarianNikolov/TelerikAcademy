using System;

namespace SchoolSystem.Models
{
    public class Mark
    {
        private const int MinMarkValue = 2;
        private const int MaxMarkValueh = 6;
        private const string IncorectMarkValueMessage = "Value of mark must be between {0} and {1}.";

        private float value;
        private Subjct subject;

        public Mark(Subjct subject, float value)
        {
            this.Subject = subject;
            this.Value = value;
        }

        internal float Value
        {
            get
            {
                return this.value;
            }

            set
            {
                if (value < MinMarkValue || value > MaxMarkValueh)
                {
                    throw new ArgumentException(string.Format(IncorectMarkValueMessage, MinMarkValue, MaxMarkValueh));
                }

                this.value = value;
            }
        }

        internal Subjct Subject
        {
            get
            {
                return this.subject;
            }

            set
            {
                this.subject = value;
            }
        }
    }
}
