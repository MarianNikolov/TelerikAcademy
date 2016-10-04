using System;

class OddAndEvenProduct
    {
        static void Main()
        {
            Console.ReadLine();

            string numberString = Console.ReadLine();
            var array = numberString.Split(' ');
            long odd = 1;
            long even = 1;

            for (int i = 0; i < array.Length; i++)
            {
                int number = int.Parse(array[i]);

                if (i % 2 == 0)
                {
                    even *= number;  
                }
                else
                {
                    odd *= number; 
                }
            }
            if (odd == even)
            {
                Console.WriteLine("yes {0}", odd);
            }
            else
            {
                Console.WriteLine("no {0} {1}", even, odd);
            }
        }
    }

