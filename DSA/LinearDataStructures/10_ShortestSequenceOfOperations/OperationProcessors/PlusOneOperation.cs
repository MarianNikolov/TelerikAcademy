using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10_ShortestSequenceOfOperations.OperationProcessors
{
    public class PlusOneOperation : IOperationProcessor
    {

        public Func<int, int> Operation
        {
            get
            {
                return x => x - 1;
            }
        }
        public IOperationProcessor LeftSuccesor { get; set; }

        public IOperationProcessor RightSuccesor { get; set; }

        public bool CanProcess(int number, int goal)
        {
            return this.Operation(number) >= goal;
        }

        public int GetProcessedResult(int number, int goal)
        {
            return this.Operation(number);
        }
    }
}
