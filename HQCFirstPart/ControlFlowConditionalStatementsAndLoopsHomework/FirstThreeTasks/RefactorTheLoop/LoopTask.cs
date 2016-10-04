using System;
using System.Collections.Generic;

namespace RefactorTheLoop
{
    public class LoopTask
    {
        public void Main()
        {
            var array = new List<int>();
            var hasFoundExpectedValue = false;
            var expectedValue = 666;

            for (int i = 0; i < 100; i++)
            {
                if (i % 10 == 0)
                {
                    Console.WriteLine(array[i]);
                    if (array[i] == expectedValue)
                    {
                        hasFoundExpectedValue = !hasFoundExpectedValue;
                        break;
                    }
                    
                }
                else
                {
                    Console.WriteLine(array[i]);
                }
            }

            // More code here
            if (hasFoundExpectedValue)
            {
                Console.WriteLine("Value Found");
            }
        }
    }
}
