using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class BinarySearch
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[] array = new int[n];

        for (int i = 0; i < n; i++)
        {
            array[i] = int.Parse(Console.ReadLine());
        }

        int numberX = int.Parse(Console.ReadLine());

        int left = 0;
        int right = array.Length - 1;
        int numberAfterPartition = n;
        int counter = 0;

        // find number of for loop iteration
        while (numberAfterPartition != 0)
        {
          numberAfterPartition = numberAfterPartition / 2;
          counter++;
        }

        
        for (int i = 0; i < counter; i++)
        {
            int middle = (left + right) / 2;
            
            if (array[left] == numberX)
            {
                Console.WriteLine(left);
                return;
            }
            if (array[right] == numberX)
            {
                Console.WriteLine(right);
                return;
            }

           
            if (array[middle] < numberX)
            {
                left = middle + 1;
            }
            if (array[middle] > numberX)
            {
                right = middle - 1;
            }
            if (array[middle] == numberX)
            {
                Console.WriteLine(middle);
                return;
            }
            if (array[left + 1] == numberX)
            {
                Console.WriteLine(left + 1);
                return;
            }
        }
        Console.WriteLine("-1");
    }
}

