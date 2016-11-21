using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10_ShortestSequenceOfOperations.OperationProcessors
{
    public interface IOperationProcessor
    {
        Func<int, int> Operation { get; }

        IOperationProcessor LeftSuccesor { get; set; }

        IOperationProcessor RightSuccesor { get; set; }

        int GetProcessedResult(int number, int goal);

        bool CanProcess(int number, int goal);
    }
}
