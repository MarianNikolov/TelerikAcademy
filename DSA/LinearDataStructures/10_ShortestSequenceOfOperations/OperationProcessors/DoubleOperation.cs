using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10_ShortestSequenceOfOperations.OperationProcessors
{
    public class DoubleOperation : IOperationProcessor
    {

        public Func<int, int> Operation
        {
            get
            {
                return x => x / 2;
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
            if (this.CanProcess(number, goal))
            {
                if (this.ShouldProcess(number))
                {
                    return this.Operation(number);
                }
                else
                {
                    return this.RightSuccesor.GetProcessedResult(number, goal);
                }
            }
            else
            {
                return this.LeftSuccesor.GetProcessedResult(number, goal);
            }
        }

        private bool ShouldProcess(int number)
        {
            return number % 2 == 0;
        }
    }
}
