using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02
{
    class Program
    {
        static void Main(string[] args)
        {

            var a = new SortedSet<string>();
            a.Add("motsarela - 122g");
            a.Add("domaten sos - 104g");
            a.Add("presni domati - 30g");
            a.Add("zeleni chushki - 69g");
            a.Add("krave sirene - 195g");
            a.Add("maslini - 56g");

            a.Add("testo: 256g");


            

            foreach (var item in a)
            {
                Console.WriteLine(item);
            }


        }
    }
}
