using System.Collections.Generic;

namespace Dealership.Reporters
{
    public interface IReporter
    {
        void MakeReport(IList<string> commandResult);
    }
}