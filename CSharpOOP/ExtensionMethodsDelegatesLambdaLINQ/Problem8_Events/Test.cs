namespace Problem8_Events
{
    using System;
    
    class Test
    {
        static void Main()
        {
            /*
            Problem 8.* Events
            Read in MSDN about the keyword event in C# and how to publish events.
            Re-implement the above using .NET events and following the best practices.
            */
            TimerN nowaTimer = new TimerN();
            MyClass someExample = new MyClass(nowaTimer);

            nowaTimer.DayMethod(6);
            Console.WriteLine();

            nowaTimer.MinutesMethod(7);
            Console.WriteLine();

            nowaTimer.MonthMethod(1);
            Console.WriteLine();

            nowaTimer.SecondsMethod(2);
            Console.WriteLine();
        }
    }

    class MyClass
    {
        private TimerN hurryUp;
        public MyClass(TimerN time)
        {
            this.hurryUp = time;
            this.hurryUp.MyEvent += new ChangedEventHandler(SomethingChanged); // hard with this events....
        }
        private void SomethingChanged(object sender, EventArgs e)
        {
            Console.WriteLine("Time changed!");
        }
    }
}
