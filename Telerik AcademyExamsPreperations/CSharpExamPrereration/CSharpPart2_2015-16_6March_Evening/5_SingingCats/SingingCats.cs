using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class SingingCats
{
    static void Main()
    {
        int c = int.Parse(Console.ReadLine());
        int s = int.Parse(Console.ReadLine());

        List<List<int>> catsAndSongs = new List<List<int>>(); 

        string curentRow = Console.ReadLine();

        while (curentRow != "Mew!")
        {
            curentRow = Console.ReadLine();
            int index = int.Parse(curentRow.Substring(4, 1));
              
        }

        // print
        if (true)
        {
            
        }
        else
        {
            Console.WriteLine("No concert!");
        }
    }
}

