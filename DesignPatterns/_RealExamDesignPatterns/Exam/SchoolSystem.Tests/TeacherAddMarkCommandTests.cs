using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using SchoolSystem.Framework;
using SchoolSystem.Framework.Core.Commands;
using SchoolSystem.Framework.Models;
using SchoolSystem.Framework.Models.Contracts;
using SchoolSystem.Framework.Models.Enums;

namespace SchoolSystem.Tests
{
    [TestFixture]
    public class TeacherAddMarkCommandTests
    {
        [Test]
        public void ConstructorWithParametersShouldSetCorrect()
        {
            Mock<ISchoolRegister> mockedSchoolRegister = new Mock<ISchoolRegister>();

            TeacherAddMarkCommand removeStudentCommand = new TeacherAddMarkCommand(mockedSchoolRegister.Object);

            Assert.IsInstanceOf<TeacherAddMarkCommand>(removeStudentCommand);
        }

        [Test]
        public void MethodExecuteWithCorectParametersShouldAddMarkOnStudent()
        {
            IList<string> studentAndTeacherIdsAndMark = new List<string>() { "5", "5", "2" };

            Mock<ITeacher> mockedTeacher = new Mock<ITeacher>();
            mockedTeacher.Setup(x => x.FirstName).Returns("Gosho");
            mockedTeacher.Setup(x => x.LastName).Returns("Goshov");
            mockedTeacher.Setup(x => x.Subject).Returns(Subject.Programming);

            Mock<IMark> mockedMark = new Mock<IMark>();
            mockedMark.Setup(x => x.Subject).Returns(Subject.Programming);
            mockedMark.Setup(s => s.Value).Returns(2);
            var marksList = new List<Mark>();
            Mock<IStudent> mockedStudent = new Mock<IStudent>();
            mockedStudent.Setup(x => x.FirstName).Returns("Pesho");
            mockedStudent.Setup(x => x.LastName).Returns("Petrov");
            mockedStudent.Setup(x => x.Grade).Returns(Grade.Eighth);
            mockedStudent.Setup(x => x.Marks);

            var students = new Dictionary<int, IStudent>();
            students.Add(5, mockedStudent.Object);

            var teachers = new Dictionary<int, ITeacher>();
            teachers.Add(5, mockedTeacher.Object);

            Mock <ISchoolRegister> mockedSchoolRegister = new Mock<ISchoolRegister>();
            mockedSchoolRegister.Setup(x => x.Students).Returns(students);
            mockedSchoolRegister.Setup(x => x.Teachers).Returns(teachers);

            TeacherAddMarkCommand addMark = new TeacherAddMarkCommand(mockedSchoolRegister.Object);
            addMark.Execute(studentAndTeacherIdsAndMark);

            Assert.AreEqual(2, mockedMark.Object.Value);
        }
    }
}
