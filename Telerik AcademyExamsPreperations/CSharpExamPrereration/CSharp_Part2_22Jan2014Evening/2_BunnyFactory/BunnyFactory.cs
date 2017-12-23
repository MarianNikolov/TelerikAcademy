using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class BunnyFactory
{
    static void Main()
    {
        List<int> factory = new List<int>();

        string input = string.Empty;
        int index = 0;
        while (true)
        {
            input = Console.ReadLine();
            if (input == "END")
            {
                break;
            }
            factory.Add(int.Parse(input));
            index++;
        }

        while (true)
        {


            // cicle
            int cycle = 1;
            long sum = 0;
            long product = 1;
            int numberOfCagesForSumAndProdukt = 0;
            
            StringBuilder newFactory = new StringBuilder();




           // for (int i = 0; i < cycle; i++)
           // {
           //     numberOfCagesForSumAndProdukt += factory[i];
           // }
           //
           //
           // for (int i = 1; i <= numberOfCagesForSumAndProdukt; i++)
           // {
           //     sum += factory[i];
           //     product *= factory[i];
           // }
           // newFactory.Append(sum);
           // newFactory.Append(product);
           //
           // for (int i = numberOfCagesForSumAndProdukt + 1; i < factory.Count; i++)
           // {
           //     newFactory.Append(factory[i]);
           // }

            // clear factory
            factory.Clear();

            for (int i = 0; i < newFactory.Length; i++)
            {
                if (newFactory[i] == '0' || newFactory[i] == '1')
                {
                    newFactory.Remove(i, 1);
                    i--;
                }
            }

            // fill factory
            for (int i = 0; i < newFactory.Length; i++)
            {
                char fillFactory = newFactory[i];
                factory.Add(fillFactory - '0');
            }
            cycle++;
        }
    }
}

