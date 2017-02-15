using System;

namespace _01_BinaryPasswords
{
    public class Startup
    {
        public static void Main()
        {

            Console.WriteLine(Math.Pow(2, 8));

            // 00000000000000000000000000000000
            Console.WriteLine("int");
            Console.WriteLine(int.MinValue);
            Console.WriteLine(int.MaxValue);
            Console.WriteLine();
            // 00000000
            // 00000000000000000000000000000000
            Console.WriteLine("uint");
            Console.WriteLine(uint.MinValue);
            Console.WriteLine(uint.MaxValue);
            Console.WriteLine();

            
            // 1111 
            //string password = Console.ReadLine();

            //long counter = 0;

            //for (int i = 0; i < password.Length; i++)
            //{
            //    if (password[i] == '*')
            //    {
            //        counter++;
            //    }
            //}

            //long result = (long)Math.Pow(2, counter);

            //Console.WriteLine(result);
        }
    }
}
