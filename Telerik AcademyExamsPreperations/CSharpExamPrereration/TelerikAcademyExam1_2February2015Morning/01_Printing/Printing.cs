using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Printing
{
    class Printing
    {
        static void Main(string[] args)
        {
            double numberOfStudents = double.Parse(Console.ReadLine());
            double shetsPerStudent = double.Parse(Console.ReadLine());
            double priceOfRealm = double.Parse(Console.ReadLine());

            double allShets = numberOfStudents * shetsPerStudent;
            double realm = allShets / 500;
            double amountOFMoney = realm * priceOfRealm;
            Console.WriteLine("{0:F2}", amountOFMoney);

        }
    }
}
