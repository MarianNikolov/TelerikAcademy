using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolSystem.Contracts;

namespace SchoolSystem.Core.Commands
{
    public class StudentListMarksCommand : ICommand
    {
        public string Execute(IList<string> commandParameters)
        {
            return Engine.Students[int.Parse(commandParameters[0])].ListMarks();
        }
    }
}
