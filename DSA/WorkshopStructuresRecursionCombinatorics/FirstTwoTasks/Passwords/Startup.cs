using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Passwords
{
    public class Startup
    {
        private static int lengthOfPassword;
        private static string directions;
        private static int k;

        private static int counterOfPasswords = 0;
        private static string currnetPassword;
        private static int currnetPosition = 0;

        private static bool isFind = false;

        public static void Main()
        {
            lengthOfPassword = int.Parse(Console.ReadLine());
            directions = Console.ReadLine();
            k = int.Parse(Console.ReadLine());

            FindDigit();
        }

        private static void FindDigit()
        {
            if (counterOfPasswords == k)
            {
                isFind = true;
                Console.WriteLine(currnetPassword);
                return;
            }

            for (int i = 0; i < lengthOfPassword; i++)
            {
                for (int j = 0; j < currnetPosition; j++)
                {
                    counterOfPasswords += j;


                }
            }

            if (isFind)
            {
                return;
            }
            else
            {
                FindDigit();
            }
        }
    }
}

// The length of the password - N(he heard N key presses)

// Whether his sister moved her finger left, right or kept it 
// in place in order to press the next key.
// E.g. if she pressed key 3 and moved her finger left - 
// the next key can only be either 1 or 2.

// Now he decided to find the K-th possible password of all possibilities 
// in lexicographically ascending order (where 0 is before 1; 1 is before 2 and so on).
