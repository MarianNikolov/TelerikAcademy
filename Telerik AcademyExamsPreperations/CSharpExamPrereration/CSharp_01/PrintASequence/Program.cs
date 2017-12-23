using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintASequence
{
    class Program
    {
        //Print a Sequence

   // Write a program that prints the first 10 members of the sequence: 2, -3, 4, -5, 6, -7, ...


        



        static void Main(string[] args)
        {
            Console.BufferHeight = 1010;
            for (int i = 2; i <= 11; i++) // from 2 to 1001 are first 1000 members
            {
                if (i % 2 == 0)
                {
                    Console.WriteLine(i);
                }
                else
                {
                    Console.WriteLine(-i);
                }
            }



            /*
                  for (int i = 2; i < 1002; i++)

                  {

                    double y = Math.Pow(-1, i);

                    Console.Write(i * y);

                    Console.Write(',');

                   }
              */

        }

        
    }
}
