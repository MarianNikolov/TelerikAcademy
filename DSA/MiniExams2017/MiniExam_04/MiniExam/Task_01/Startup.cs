using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_01
{
    class Startup
    {
        static void Main()
        {
            var s = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var e = Console.ReadLine().Split().Select(int.Parse).ToArray();

            double time = double.MaxValue;

            if (s[2] == e[2] || s[0] == e[0])
            {
                double distance = Math.Sqrt(Math.Pow(
                    s[0] - e[0], 2) + Math.Pow(s[1] - e[1], 2));
                time = distance / s[2];
            }
            else
            {
                if (s[0] > e[0])
                {
                    double temp = 0;
                    for (double x = e[0]; x <= s[0]; x += 0.01)
                    {
                        temp = 0;

                        var firstDistance = Math.Sqrt(
                            Math.Pow(s[0] - x, 2) + Math.Pow(s[1], 2));
                        temp += firstDistance / s[2];

                        var secondDistance = Math.Sqrt(
                            Math.Pow(x - e[0], 2) + Math.Pow(e[1], 2));
                        temp += secondDistance / e[2];

                        time = Math.Min(temp, time);
                    }
                }
                else
                {
                    double temp = 0;
                    for (double x = s[0]; x <= e[0]; x += 0.01)
                    {
                        temp = 0;

                        var firstDistance = Math.Sqrt(
                            Math.Pow(s[0] - x, 2) + Math.Pow(s[1], 2));
                        temp += firstDistance / s[2];

                        var secondDistance = Math.Sqrt(
                            Math.Pow(x - e[0], 2) + Math.Pow(e[1], 2));
                        temp += secondDistance / e[2];

                        time = Math.Min(temp, time);
                    }
                }
            }

            Console.WriteLine(String.Format("{0:0.00}", time));
        }
    }
}
