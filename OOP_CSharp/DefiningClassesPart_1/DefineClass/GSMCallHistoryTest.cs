namespace DefineClass
{
    using System;

    public class GSMCallHistoryTest
    {

        public static void CallHistoryTest()
        {
            // Create an instance of the GSM class.
            GSM myFirstIPhone = new GSM(
                   "IPhone5",
                   "Apple",
                   55.99,
                   "Gosho Bacov",
                   new Display(9, 500000000),
                   new Battery(BatteryType.LithiumSulfur, "Li-lon", 10, 4.5),
                   new Call(DateTime.Now, "0899 513 321", 60));


            // Add few calls.
            myFirstIPhone.AddCall(new Call(DateTime.UtcNow, "0888 888 888", 162));
            myFirstIPhone.AddCall(new Call(DateTime.Today, "0999 235 123", 42));
            myFirstIPhone.AddCall(new Call(DateTime.Now, "0999 999 999", 70));


            // Display the information about the calls.
            var historyCalls = myFirstIPhone.CallHistory;

            foreach (var call in historyCalls)
            {
                Console.WriteLine(call.ToString());
                Console.WriteLine();
            }


            // Assuming that the price per minute is 0.37 calculate 
            // and print the total price of the calls in the history.
            double price;
            price = myFirstIPhone.CallPrice(myFirstIPhone.CallHistory);
            Console.WriteLine($"{price:F2}" );
            Console.WriteLine();


            // Remove the longest call from the history and calculate the total price again.
            var historyCallsList = myFirstIPhone.CallHistory;
            int longestCall = historyCallsList[0].DurationInSeconds;
            Call callForRemuve = myFirstIPhone.CallHistory[0];

            foreach (var call in historyCallsList)
            {
                if (longestCall < call.DurationInSeconds)
                {
                    callForRemuve = call;
                }
            }
            myFirstIPhone.DelCall(callForRemuve);
                
                // print again
            historyCalls = myFirstIPhone.CallHistory;
            foreach (var call in historyCalls)
            {
                Console.WriteLine(call.ToString());
                Console.WriteLine();
            }

            double newPrice;
            newPrice = myFirstIPhone.CallPrice(myFirstIPhone.CallHistory);
            Console.WriteLine($"{newPrice:F2}");
            Console.WriteLine();


            // Finally clear the call history and print it.
            myFirstIPhone.ClearHistory();

            if (myFirstIPhone.CallHistory.Count == 0)
            {
                Console.WriteLine("Call history is EMPTY !!!");
            }
            else
            {
                historyCalls = myFirstIPhone.CallHistory;
                foreach (var call in historyCalls)
                {
                    Console.WriteLine(call.ToString());
                    Console.WriteLine();
                }
            }
        }
    }
}


