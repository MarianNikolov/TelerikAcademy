using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class RemoveElementsFromArray
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[] array = new int[n];
        int[] arrayForFoundMaxSequence = new int[n];
        for (int i = 0; i < n; i++)
			{
			 arrayForFoundMaxSequence[i] = 1;
			}

        for (int i = 0; i < n; i++)
			{
			    array[i] = int.Parse(Console.ReadLine());
			}

        int max = 1;
		for (int i = 1; i < n; i++)
		{
			for (int j = 0; j < i; j++)
			{
				if (array[i] >= array[j] && arrayForFoundMaxSequence[i] <= arrayForFoundMaxSequence[j] + 1)
				{
					arrayForFoundMaxSequence[i] = arrayForFoundMaxSequence[j] + 1;

					if (max < arrayForFoundMaxSequence[i])
					{
						max = arrayForFoundMaxSequence[i];
					}
				}
			}
		}

		Console.WriteLine(n - max);
    }
}

