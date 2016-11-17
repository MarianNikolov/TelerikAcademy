using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dealership.Contracts.ReadersAndWriters;

namespace Dealership.Reporters
{
    public class Reporter : IReporter
    {
        private IWriter writer;

        public Reporter(IWriter writer)
        {
            this.writer = writer;
        }

        public void MakeReport(IList<string> commandResult)
        {
            var output = new StringBuilder();

            foreach (var result in commandResult)
            {
                output.AppendLine(result);
                output.AppendLine(new string('#', 20));
            }

            this.writer.Write(output.ToString());
        }
    }
}
