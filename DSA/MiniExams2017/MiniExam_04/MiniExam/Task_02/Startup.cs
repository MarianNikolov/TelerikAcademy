using System;
using System.Text;

namespace Task_02
{
    class Startup
    {
        static void Main()
        {
            //List<int> input = Console.ReadLine()
            //    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            //    .Select(int.Parse)
            //    .ToList();

            var input = Console.ReadLine().Split(' ');

            int[] failLink = new int[input.Length + 1];
            failLink[0] = -1;

            int j;
            for (int i = 1; i < input.Length; i++)
            {
                j = failLink[i];
                while (j >= 0 && input[i] != input[j])
                {
                    j = failLink[j];
                }

                failLink[i + 1] = j + 1;
            }

            j = 0;
            int index = 1;
            while (true)
            {
                if (index == input.Length)
                {
                    index = 0;
                }

                while (j >= 0 && input[index] != input[j])
                {
                    j = failLink[j];
                }

                j++;

                if (j == input.Length)
                {
                    j = index + 1;
                    break;
                }

                index++;
            }

            StringBuilder resultStringBuilder = new StringBuilder();

            for (int i = 0; i < j; i++)
            {
                resultStringBuilder.Append(input[i] + ' ');
            }

            var result = resultStringBuilder.ToString();

            Console.WriteLine(result.Trim());
        }
    }
}
