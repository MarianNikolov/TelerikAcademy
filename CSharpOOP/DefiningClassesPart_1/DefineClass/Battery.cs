namespace DefineClass
{
    using System;

    public class Battery
    {
        private string model;
        private double hoursIdle;
        private double hoursTalk;
        private BatteryType batteryType;

        public Battery(BatteryType batteryType, string model = null, double hoursIdle = 0.0, double hoursTalk = 0.0)
        {
            this.BattetyType = batteryType;
            this.Model = model;
            this.HoursIdle = hoursIdle;
            this.HoursTalk = hoursTalk;
        }

        public string Model
        {
            get
            {
                return this.model;
            }
            set
            {
                this.model = value;
            }
        }

        public double HoursIdle
        {
            get
            {
                return this.hoursIdle;
            }
            set
            {
                this.hoursIdle = value;
            }
        }

        public double HoursTalk
        {
            get
            {
                return this.hoursTalk;
            }
            set
            {
                this.hoursTalk = value;
            }
        }

        public BatteryType BattetyType
        {
            get
            {
                return this.batteryType;
            }
            set
            {
                this.batteryType = value;
            }
        }

        public override string ToString()
        {
            string result = string.Empty;
            if (Model != null)
            {
                result += string.Format("Model is {0} ", Model);
            }

            if (HoursIdle != 0.0)
            {
                result += string.Format("Hours idle is {0} ", HoursIdle);
            }

            if (HoursTalk != 0.0)
            {
                result += string.Format("Hours talk is {0} ", HoursTalk);
            }

            return base.ToString();
        }

    }
}
