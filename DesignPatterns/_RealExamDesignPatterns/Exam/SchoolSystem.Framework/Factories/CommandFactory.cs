using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using SchoolSystem.Framework.Core.Commands;
using SchoolSystem.Framework.Core.Commands.Contracts;

namespace SchoolSystem.Framework.Factories
{
    public class CommandFactory : ICommandFactory
    {
        private ISchoolRegister register;
        private ISchoolSystemFactory factory;
        public CommandFactory(ISchoolRegister register, ISchoolSystemFactory factory)
        {
            this.register = register;
            this.factory = factory;
        }

        public ICommand CretaCurrenCommand(TypeInfo typeInfo)
        {
            if (typeInfo.Name == "CreateStudentCommand")
            {
                return new CreateStudentCommand(this.factory, this.register);
            }

            else if (typeInfo.Name == "CreateTeacherCommand")
            {
                return new CreateTeacherCommand(this.factory, this.register);
            }

            else if (typeInfo.Name == "RemoveStudentCommand")
            {
                return new RemoveStudentCommand(this.register);
            }

            else if (typeInfo.Name == "RemoveTeacherCommand")
            {
                return new RemoveTeacherCommand(this.register);
            }

            else if (typeInfo.Name == "StudentListMarksCommand")
            {
                return new StudentListMarksCommand(this.register);
            }
            else
            {
                return new TeacherAddMarkCommand(this.register);
            }
        }
    }
}
