using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class PrimeNumbers
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());


        for (int i = n; i >= 0; i--)
        {
            bool isPrime = true;

            for (int j = 2; j < n / 2; j++)
            {
                if (i % j == 0)
                {
                    isPrime = false;
                    break;
                }
            }
            if (isPrime)
            {
                Console.WriteLine(i);
                return;
            }
        }
        
    }
}

 //int n = int.Parse(Console.ReadLine());

 //       List<int> numbersList = new List<int>();

 //       for (int i = 2; i <= n; i++)
 //       {
 //           numbersList.Add(i);
 //       }

 //       for (int i = 0; i < numbersList.Count; i++)
 //       {

 //           for (int j = i + 1; j < numbersList.Count; j++)
 //           {
 //               if (numbersList[j] % numbersList[i] == 0)
 //               {
 //                   numbersList.Remove(numbersList[j]);
 //               }
 //           }
 //       }
 //       Console.WriteLine(numbersList.Last());
        