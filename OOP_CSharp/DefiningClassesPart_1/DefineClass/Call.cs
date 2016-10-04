namespace DefineClass
{
    using System;

    public class Call
    {

        private DateTime date;
        private string dialledPhoneNumber;
        private int durationInSeconds;

        public Call()
        {
        }

        public Call (DateTime date, string dialledPhoneNumber, int durationInSeconds)
        {
            this.date = date;
            this.DialledPhoneNumber = dialledPhoneNumber;
            this.DurationInSeconds = durationInSeconds;
        }

        public DateTime Date
        {
            get
            {
                return this.date;
            }
            set
            {
                this.date = value;
            }
        }

        public string DialledPhoneNumber
        {
            get
            {
                return this.dialledPhoneNumber;
            }
            set
            {
                this.dialledPhoneNumber = value;
            }
        }

        public int DurationInSeconds
        {
            get
            {
                return this.durationInSeconds;
            }
            set
            {
                this.durationInSeconds = value;
            }
        }

        public override string ToString()
        {
            string result =
                "Call date is " + this.Date.ToString("dd/ mm/yyyy")
                + " time is " + this.Date.Hour 
                + ":" + this.Date.Minute + "\n"
                + "dialled phone number is " + this.dialledPhoneNumber 
                + " duration in seconds is " + this.durationInSeconds;

            return result;
        }
    }
}
