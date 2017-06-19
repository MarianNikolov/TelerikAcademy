using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using SchoolSystem.Framework;
using SchoolSystem.Framework.Core.Commands;
using SchoolSystem.Framework.Models.Contracts;
using SchoolSystem.Framework.Models.Enums;

namespace SchoolSystem.Tests
{
    [TestFixture]
    public class RemoveStudentCommandTests
    {
        [Test]
        public void ConstructorWithParametersShouldSetCorrect()
        {
            Mock<ISchoolRegister> mockedSchoolRegister = new Mock<ISchoolRegister>();

            RemoveStudentCommand removeStudentCommand = new RemoveStudentCommand(mockedSchoolRegister.Object);

            Assert.IsInstanceOf<RemoveStudentCommand>(removeStudentCommand);
        }

        [Test]
        public void MethodExecuteWithCorectParametersShouldRemoveStudentFromRegister()
        {
            IList<string> studentId =  new List<string>() { "1" } ;
            Mock<IStudent> mockedStudent = new Mock<IStudent>();
            mockedStudent.Setup(x => x.FirstName).Returns("Pesho");
            mockedStudent.Setup(x => x.LastName).Returns("Petrov");
            mockedStudent.Setup(x => x.Grade).Returns(Grade.Eighth);

            ISchoolRegister schoolRegister = new SchoolRegister();
            schoolRegister.Students.Add(int.Parse(studentId[0]), mockedStudent.Object);
            RemoveStudentCommand removeStudentCommand = new RemoveStudentCommand(schoolRegister);
            removeStudentCommand.Execute(studentId);

            Assert.AreEqual(0, schoolRegister.Students.Count);
        }

        [Test]
        public void MethodExecuteWithCorectParametersShouldReturnCorrectOutput()
        {
            IList<string> studentId = new List<string>() { "11" }; ;
            string expectedResult = "Student with ID 11 was sucessfully removed.";

            Mock<IStudent> mockedStudent = new Mock<IStudent>();
            mockedStudent.Setup(x => x.FirstName).Returns("Pesho");
            mockedStudent.Setup(x => x.LastName).Returns("Petrov");
            mockedStudent.Setup(x => x.Grade).Returns(Grade.Eighth);

            ISchoolRegister schoolRegister = new SchoolRegister();
            schoolRegister.Students.Add(int.Parse(studentId[0]), mockedStudent.Object);

            RemoveStudentCommand removeStudentCommand = new RemoveStudentCommand(schoolRegister);
            var result = removeStudentCommand.Execute(studentId);

            Assert.AreEqual(expectedResult, result);
        }

    }
}
