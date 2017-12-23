using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class HarryPotter4D
{
    static void Main()
    {
        int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

        int[] inputHarry = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();


        string[, , ,] cube = new string[input[0], input[1], input[2], input[3]];
        string curentBasilisk = "";
        cube[inputHarry[0], inputHarry[1], inputHarry[2], inputHarry[3]] = "@";
        char first  = ' ';
        //read Basilisk
        int numberBasilisk = int.Parse(Console.ReadLine());
        for (int i = 0; i < numberBasilisk; i++)
        {
             curentBasilisk = Console.ReadLine();
            cube[curentBasilisk[2] - '0', curentBasilisk[4] - '0', curentBasilisk[6] - '0', curentBasilisk[8] - '0'] = curentBasilisk[0].ToString();
        }

        int harryMoves = 0;

        // moves players
        string curentMove = Console.ReadLine();

        char name = curentMove[0];
        char dim = curentMove[2];
        int move = int.Parse(curentMove.Substring(4));
      while (curentMove != "END")
      {

     curentMove = Console.ReadLine();

          }
      Console.WriteLine("{0}: \"You thought you could escape, didn't you?\" - 0", curentBasilisk[0]);  // proba

      //  for (int A = 0; A < input[0]; A++)
      //  {
      //      for (int B = 0; B < input[1]; B++)
      //      {
      //          for (int C = 0; C < input[2]; C++)
      //          {
      //              for (int D = 0; D < input[3]; D++)
      //              {
      //                  if (cube[A, B, C, D] == "@") /// problem
      //                  {
      //                      if (name == '@')
      //                      {
      //                          harryMoves++;
      //                      }
      //                      cube[A, B, C, D] = string.Empty;
      //
      //                      if (dim == 'A')
      //                      {
      //                          if (A + move >= input[0])
      //                          {
      //                              A = input[0];
      //                             
      //                              cube[A, B, C, D] += name;
      //                          }
      //                          else
      //                          {
      //                              cube[A + move, B, C, D] += name;
      //                          }
      //
      //                          if (cube[A, B, C, D] == "@")
      //                          {
      //                              Console.WriteLine("{0}: You thought you could escape, didn't you?\" - {1}", name, harryMoves);
      //                              return;
      //                          }
      //                      }
      //                      if (dim == 'B')
      //                      {
      //                          if (B + move >= input[1])
      //                          {
      //                              B = input[1];
      //
      //                              cube[A, B, C, D] += name;
      //                          }
      //                          else
      //                          {
      //                              cube[A, B + move, C, D] += name;
      //                          }
      //
      //                          if (cube[A, B, C, D] == "@")
      //                          {
      //                              Console.WriteLine("{0}: You thought you could escape, didn't you?\" - {1}", name, harryMoves);
      //                              return;
      //                          }
      //                      }
      //                      if (dim == 'C')
      //                      {
      //                          if (C + move >= input[2])
      //                          {
      //                              C = input[2];
      //
      //                              cube[A, B, C, D] += name;
      //                          }
      //                          else
      //                          {
      //                              cube[A, B, C + move, D] += name;
      //                          }
      //
      //                          if (cube[A, B, C, D] == "@")
      //                          {
      //                              Console.WriteLine("{0}: You thought you could escape, didn't you?\" - {1}", name, harryMoves);
      //                              return;
      //                          }
      //                      }
      //                      if (dim == 'D')
      //                      {
      //                          if (D + move >= input[3])
      //                          {
      //                              D = input[3];
      //
      //                              cube[A, B, C, D] += name;
      //                          }
      //                          else
      //                          {
      //                              cube[A, B, C, D + move] += name;
      //                          }
      //
      //                          if (cube[A, B, C, D] == "@")
      //                          {
      //                              Console.WriteLine("{0}: You thought you could escape, didn't you?\" - {1}", name, harryMoves);
      //                              return;
      //                          }
      //                      }
      //
      //                  }
      //              }
      //          }
      //      }
      //     }
      //
      // }
    }
}

