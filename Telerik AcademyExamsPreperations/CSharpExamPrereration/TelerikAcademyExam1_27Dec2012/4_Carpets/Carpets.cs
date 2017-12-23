using System;

class Carpets
{
    static void Main()
    {

      
         
        int n = int.Parse(Console.ReadLine());

        /*
       12 /
      ...../\.....
      ..../  \....
      .../ /\ \...
      ../ /  \ \..
      ./ / /\ \ \.
      / / /  \ \ \
        */

        for (int row = 1; row <= n / 2 ; row++)
        {
            for (int y = 0; y < ((n / 2) - row); y++)
            {
                Console.Write('.');
            }
            for (int r = 0; r < 1; r++)
            {
                Console.Write('/');
            }

            for (int a = 0; a < (row - 1) * 2; a++)
            {
                Console.Write("-");
            }

            for (int t = 0; t < 1; t++)
            {
                Console.Write('\\');
            }
            for (int y = 0; y < ((n / 2) - row); y++)
            {
                Console.Write('.');
            }
            Console.WriteLine();
        }


        /*
         12
         
        \ \ \  / / /
        .\ \ \/ / /.
        ..\ \  / /..
        ...\ \/ /...
        ....\  /....
        .....\/.....
        
          */
    }
}

