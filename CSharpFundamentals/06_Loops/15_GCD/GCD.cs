using System;

class GCD
{
    static void Main()
    {
        var input = Console.ReadLine().Split(' ');
        
        int a = Math.Abs(int.Parse(input[0]));
        int b = Math.Abs(int.Parse(input[1])); ;

        while (a != 0 && b != 0)
        {
            if (a > b)
                a %= b;
            else
                b %= a;
        }

        if (a == 0)
        {
            Console.WriteLine(b);
        }
        
        else
        { 
            Console.WriteLine(a);
        }
    }
}

