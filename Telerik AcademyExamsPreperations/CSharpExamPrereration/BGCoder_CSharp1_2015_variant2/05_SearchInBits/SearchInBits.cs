using System;

class SearchInBits
{
    static void Main()
    {
        int s = int.Parse(Console.ReadLine());
        int n = int.Parse(Console.ReadLine());

        int counter = 0;

        for (int i = 0; i < n; i++)
        {

            int num = int.Parse(Console.ReadLine());

            for (int pos = 0; pos <= 26; pos++)
            {
                bool match = true;

                for (int j = 0; j <= 3; j++)
                {
                    int posInNumber = pos + j;
                    int posInS = j;
                    int bitInNum = (num & (1 << posInNumber)) >> posInNumber;
                    int bitInS = (s & (1 << posInS)) >> posInS;
                    
                    if (bitInNum != bitInS)
                    {
                        match = false;
                        break;
                    }
                }
                if (match)
                {
                    counter++;
                }
            }
        }
        Console.WriteLine(counter);
    }
}

