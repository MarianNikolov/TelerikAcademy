using System;

namespace _01_BinaryPasswords
{
    public class Startup
    {
        public static void Main()
        {
            string password = Console.ReadLine();

            long counter = 0;

            for (int i = 0; i < password.Length; i++)
            {
                if (password[i] == '*')
                {
                    counter++;
                }
            }

            long result = (long)Math.Pow(2, counter);

            Console.WriteLine(result);
        }
    }
}
