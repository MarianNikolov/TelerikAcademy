using System.Reflection;
using SchoolSystem.Framework.Core.Commands.Contracts;
using SchoolSystem.Framework.Models.Contracts;
using SchoolSystem.Framework.Models.Enums;

namespace SchoolSystem.Framework.Factories
{
    public interface ISchoolSystemFactory
    {
        IStudent CreateStudent(string firstName, string lastName, Grade grade);

        ITeacher CreateTeacher(string firstName, string lastName, Subject subject);

        IMark CreateMark(Subject subject, float value);
    }
}