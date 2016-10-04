using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class AddingPolynomials
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[] firstCoef = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        int[] secondCoef = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

        int[] sum = Addition(firstCoef, secondCoef);

        var list = new List<int>();
        for (int i = 0; i < sum.Length; i++)
        {
            list.Add(sum[i]);
        }
        Console.WriteLine(string.Join(" ", list));
    }

    public static int[] Addition(int[] firstPolynom, int[] secondPolynom)
    {
        if (firstPolynom.Length < secondPolynom.Length)
        {
            return Addition(secondPolynom, firstPolynom);
        }

        int[] sumOfPoly = new int[firstPolynom.Length];

        for (int i = 0; i < secondPolynom.Length; i++)
        {
            sumOfPoly[i] = firstPolynom[i] + secondPolynom[i];
        }

        for (int i = secondPolynom.Length; i < firstPolynom.Length; i++)
        {
            sumOfPoly[i] = firstPolynom[i];
        }

        return sumOfPoly;
    }
}
