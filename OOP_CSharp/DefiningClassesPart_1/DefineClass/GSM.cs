namespace DefineClass
{
    using System;
    using System.Collections.Generic;
    public class GSM
    {
        private string model;
        private string manufacturer;
        private double price;
        private string owner;
        private Display display;
        private Battery battery;
        private Call call;
        private List<Call> callHistory = new List<Call>();


        private static GSM iPhone4S = new GSM(
            "IPhone4S",
            "Apple",
            999.99,
            "Pesho",
            new Display(9, 555555555),
            new Battery(BatteryType.LithiumSulfur, "Li-Lon", 9, 3));

        public GSM(
            string model, 
            string manufacturer, 
            double price = 0.0, 
            string owner = null, 
            Display display = null,
            Battery battery = null,
            Call call = null)
        {
            this.Model = model;
            this.Manufacturer = manufacturer;
            this.Price = price;
            this.Owner = owner;
            this.Display = display;
            this.Battery = battery;
            this.Call = call;
        }

        public static GSM IPhone4S
        {
            get
            {
                return iPhone4S;
            }
        }

        public string Model
        {
            get
            {
                return this.model;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentException("Please, enter mode!");
                }
                this.model = value;
            }
        }

        public string Manufacturer
        {
            get
            {
                return this.manufacturer;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentException("Please, enter manufacturer!");
                }
                this.manufacturer = value;
            }
        }

        public double Price
        {
            get
            {
                return this.price;
            }
            set
            {
                this.price = value;
            }
        }
        public string Owner
        {
            get
            {
                return this.owner;
            }
            set
            {
                this.owner = value;
            }
        }

        public Display Display
        {
            get
            {
                return this.display;
            }
            set
            {
                this.display = value;
            }
        }

        public Battery Battery
        {
            get
            {
                return this.battery;
            }
            set
            {
                this.battery = value;
            }
        }

        public Call Call
        {
            get
            {
                return this.call;
            }
            set
            {
                this.call = value;
            }
        }

        public override string ToString()
        {
            string result = "Model is " + this.Model + " Manufacturer is " + this.Manufacturer;

            if (Price != 0.0)
            {
                result += " " + this.Price;
            }
            if (Owner != null)
            {
                result += " " + this.Owner;
            }
            return result;
        }

        public List<Call> CallHistory
        {
            get
            {
                return this.callHistory;
            }
        }

        public List<Call> AddCall (Call call)
        {
            callHistory.Add(call);
            return callHistory;
        }

        public List<Call> DelCall(Call call)
        {
            callHistory.Remove(call);
            return callHistory;
        }

        public List<Call> ClearHistory()
        {
            callHistory.Clear();
            return callHistory;
        }

        public double CallPrice(List<Call> calls)
        {
            double pricePerMinute = 0.37;
            double allDurationOfCallsInSeconds = 0;
            double durationsInMinutes = 0;
            double sumOfCals = 0;

            foreach (var call in calls)
            {
                allDurationOfCallsInSeconds += call.DurationInSeconds;
            }

            durationsInMinutes = allDurationOfCallsInSeconds / 60;
            sumOfCals = durationsInMinutes * pricePerMinute;

            return sumOfCals;
        }
    }
}
