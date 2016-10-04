using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class DancingMoves
{
    // 100 points in BgCoder 
    static void Main()
    {
        List<int> array = new List<int>();
        array = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

        double round = 0;
        double sum = 0;
        while (true)
        {
            string[] input = Console.ReadLine().Split(' ').ToArray();
            if (input[0] == "stop")
            {
                break;
            }

            int times = int.Parse(input[0]);
            string direction = FindDirection(input);

            // get steps
            int step = int.Parse(input[2]);

            int position = 0;

            // start IF Direction Right
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

            // start IF Direction Left
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

            round++;
        }

        double result = (sum / round);

        Console.WriteLine("{0:F1}", result);
    }

    private static string FindDirection(string[] input)
    {
        if (input[1] == "right")
        {
            return "right";
        }
        else
        {
            return "left";
        }
    }
}

