using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class FindSumInArray
{
    static void Main()
    {
        // fuck  -  Mishhooo, kvo e tva be brateee?!!??!

        int[] array = Console.ReadLine().Split(new char[] { ' ', ',' },
            StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        
        int sum = 0;

        int numberForSearch = int.Parse(Console.ReadLine());
        List<int> list = new List<int>();

        for (int i = 0; i < array.Length - 1; i++)
        {
            sum = array[i];

            // print
            if (true)
            {
                if (sum == numberForSearch)
                {
                    Console.WriteLine(array[i]);
                    return;
                }
            }
            list.Add(array[i]);
            
            for (int j = i + 1; j < array.Length; j++)
            {
                list.Add(array[j]);
                // print
                sum += array[j];
                if (sum == numberForSearch)
                {
                    for (int r = 0; r < list.Count; r++)
                    {
                        if (r == list.Count - 1)
                        {
                            Console.Write("{0}", list[r]);
                            Console.WriteLine();
                        }
                        else
                        {
                            Console.Write("{0}, ", list[r]);
                        }
                    }
                }
            }
            list.Clear();
        }
    }
}

