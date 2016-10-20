using SchoolSystem.Contracts;
using SchoolSystem.Core;

namespace SchoolSystem
{
    public class Startup
    {
        public static void Main()
        {
            IReader readerer = new ConsoleReaderProvider();
            IWriter writer = new ConsoleWriteProvider();
            IEngine engine = new Engine(readerer, writer);

            engine.Start();
        }
    }
}
