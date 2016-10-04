using System;
using System.Numerics;
class Calculate3
{
    static void Main()
    {
        BigInteger n = BigInteger.Parse(Console.ReadLine());
        BigInteger k = BigInteger.Parse(Console.ReadLine());

        BigInteger faktorialN = 1;
        BigInteger faktorialK = 1;
        BigInteger counterForNK = n - k; 
        BigInteger faktorialNK = 1;
        BigInteger number = 0;


        for (int i = 1; i <= n; i++)
        {
            faktorialN = faktorialN * i;
            if (i <= k)
	        {
		        faktorialK = faktorialK * i;
	        }
        }
            // (N - K)!
        for (int i = 1; i <= counterForNK; i++)
			{
			    faktorialNK = faktorialNK * i;
			}    
            
        // N! / (K! * (N - K)!)

        number = faktorialN / (faktorialK * faktorialNK);
        Console.WriteLine(number);
    }
}

