using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImplementTheADTStack
{
    // 12. Implement the ADT stack as auto-resizable array.
        // Resize the capacity on demand (when no space is available to add / insert a new element).

    public class Startup
    {
        static void Main()
        {
            var customStack = new CustomStack<int>();

            new List<int> { 1, 2, 3, 4, 5 }.ForEach(x => customStack.Push(x));

            Console.WriteLine("CustomStack:");
            Console.WriteLine();

            while (customStack.Count > 0)
            {
                Console.WriteLine(customStack.Pop());
            }
        }
    }
}
