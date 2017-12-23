using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task01
{
    public class Startup
    {
        static void Main()
        {
            //var N = int.Parse(Console.ReadLine());
            Console.ReadLine();

            //var jedis = new Dictionary<char, List<string>>();
            //jedis['M'] = new List<string>();
            //jedis['K'] = new List<string>();
            //jedis['P'] = new List<string>();

            var jedisM = new Queue<string>();
            //var jedisK = new Queue<string>();
            //var jedisP = new Queue<string>();


            string[] allJedi = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < allJedi.Length; i++)
            {
                var current = allJedi[i][0];

                if (current == 'M')
                {
                    jedisM.Enqueue(allJedi[i]);
                }

            }

            for (int i = 0; i < allJedi.Length; i++)
            {
                var current = allJedi[i][0];

                if (current == 'K')
                {
                    jedisM.Enqueue(allJedi[i]);
                }

            }

            for (int i = 0; i < allJedi.Length; i++)
            {
                var current = allJedi[i][0];

                if (current == 'P')
                {
                    jedisM.Enqueue(allJedi[i]);
                }

            }

            // else if (current == 'K')
            //{
            //    jedisK.Enqueue(allJedi[i]);
            //}
            //else
            //{
            //    jedisP.Enqueue(allJedi[i]);
            //}



            var result = new StringBuilder();

            while(jedisM.Count != 0)
            {
                    result.Append(jedisM.Dequeue() + ' ');
            }

            //while (jedisK.Count != 0)
            //{
            //    result.Append(jedisK.Dequeue() + ' ');
            //}

            //while (jedisP.Count != 0)
            //{
            //    result.Append(jedisP.Dequeue() + ' ');
            //}


            Console.WriteLine(result.ToString().Trim());

        }
    }
}
