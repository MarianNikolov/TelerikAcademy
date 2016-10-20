using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Core.Commands
{
    public class RemoveTeacherCommand
    {
        public string Execute(IList<string> commandParameters)
        {
            Engine.Teachers.Remove(int.Parse(commandParameters[0]));
            return $"Teacher with ID {int.Parse(commandParameters[0])} was sucessfully removed.";
        }
    }
}
