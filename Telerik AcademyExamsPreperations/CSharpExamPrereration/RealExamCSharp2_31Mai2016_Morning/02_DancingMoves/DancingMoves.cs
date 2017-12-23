using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class DancingMoves
{
    static void Main()
    {
        List<int> array = new List<int>();
        array = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

        double round = 0;
        double sum = 0;
        int position = 0;

        while (true)
        {
            string[] input = Console.ReadLine().Split( ' ' ).ToArray();

            if (input[0] == "stop")
            {
                break;
            }

            int times = int.Parse(input[0]);
            string direction = string.Empty;

            // get direction
            if (input[1] == "right")
            {
                direction = "right";
            }
            else
            {
                direction = "left";
            }

            // get steps
            int step = int.Parse(input[2]);

            
            
            // start IF Right
            if (direction == "right")
            {
                for (int i = 0; i < times; i++)
                {
                    position += step;
                    if (position > array.Count - 1)
                    {
                        position = position % array.Count;
                    }
                    sum += array[position];
                }
            }

            // start IF Left
            if (direction == "left")
            {
                for (int i = 0; i < times; i++)
                {
                    position -= step;
                    if (position < 0)
                    {
                        position = Math.Abs(position);
                        if (position > array.Count)
                        {
                            position = position % array.Count;
                        }
                        position = array.Count - position;
                    }
                    sum += array[position];
                }
            }
            // Console.WriteLine(sum);
            round++;
        }

       double result = (sum / round);
      
       Console.WriteLine("{0:F1}", result);
      // Console.WriteLine(decimal.MaxValue);
      // Console.WriteLine();
      // Console.WriteLine(double.MaxValue);
      // Console.WriteLine();
      // Console.WriteLine(float.MaxValue);
      //
      // Console.WriteLine(long.MaxValue);
    }
}

