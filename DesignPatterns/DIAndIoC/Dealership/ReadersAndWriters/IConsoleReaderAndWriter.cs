using Dealership.Contracts.ReadersAndWriters;

namespace Dealership.ReadersAndWriters
{
    public interface IConsoleReaderAndWriter  
    {
        string ReadLine();

        void Write(string text = null);

        void WriteLine(string text = null);
    }
}