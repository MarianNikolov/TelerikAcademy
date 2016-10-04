using System;

class ModifyBit
{
    static void Main()
    {
        ulong n = ulong.Parse(Console.ReadLine());
        int p = int.Parse(Console.ReadLine());
        ulong v = ulong.Parse(Console.ReadLine());
        ulong mask = 1;
        ulong finalNumber;
       
        ulong newN = n;
        newN >>= p;
        newN = newN & 1;
        
        if (newN == v)
        {
            Console.WriteLine(n);
            return;
        }
      
        if (v == 1)
        {
            finalNumber = (mask << p) | n;
            Console.WriteLine(finalNumber);
        }
      
        if (v == 0)
        {
            finalNumber = ~(mask << p) & n;
            Console.WriteLine(finalNumber);
        }
    }
}

