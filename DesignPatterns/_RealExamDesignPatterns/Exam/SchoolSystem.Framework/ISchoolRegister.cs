using System.Collections.Generic;
using SchoolSystem.Framework.Models.Contracts;

namespace SchoolSystem.Framework
{
    public interface ISchoolRegister
    {
        IDictionary<int, ITeacher> Teachers { get; set; }

        IDictionary<int, IStudent> Students { get; set; }
    }
}