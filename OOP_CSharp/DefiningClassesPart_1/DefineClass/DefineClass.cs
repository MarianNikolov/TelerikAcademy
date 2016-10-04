namespace DefineClass
{
    using System;
    
    class DefineClass
    {
        static void Main()
        {
            // Static IPhone4S TEST
            Console.WriteLine(GSM.IPhone4S);

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();


            // GSM TEST
            var gsmTest = new GSMTest();

            foreach (var gsm in gsmTest.ListOFGSMs)
            {
                Console.WriteLine(gsm);
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();


            // CALL History TEST
            GSMCallHistoryTest.CallHistoryTest();
        }
    }
}
