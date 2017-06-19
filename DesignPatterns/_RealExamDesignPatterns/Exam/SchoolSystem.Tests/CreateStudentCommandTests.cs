using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using SchoolSystem.Framework;
using SchoolSystem.Framework.Core.Commands;
using SchoolSystem.Framework.Factories;

namespace SchoolSystem.Tests
{
    [TestFixture]
    public class CreateStudentCommandTests
    {
        [Test]
        public void ConstructorWithParametersShouldSetCorrect()
        {
            Mock<ISchoolSystemFactory> mockedSchoolSystemFactory = new Mock<ISchoolSystemFactory>();
            Mock<ISchoolRegister> mockedSchoolRegister = new Mock<ISchoolRegister>();

            CreateStudentCommand createStudentCommand = new CreateStudentCommand(mockedSchoolSystemFactory.Object, mockedSchoolRegister.Object);

            Assert.IsInstanceOf<CreateStudentCommand>(createStudentCommand);
        }

        [Test]
        public void MethodExecuteWithCorectParametersShouldAddStudentInRegister()
        {
            IList<string> parameterForStudent = new List<string>() { "Pesho", "Petrov", "10" };
            string expectedResult = "A new student with name Pesho Petrov, grade 10 and ID 0 was created.";
            Mock<ISchoolSystemFactory> mockedSchoolSystemFactory = new Mock<ISchoolSystemFactory>();

            ISchoolRegister schoolRegister = new SchoolRegister();
            CreateStudentCommand createStudentCommand = new CreateStudentCommand(mockedSchoolSystemFactory.Object, schoolRegister);
            string result = createStudentCommand.Execute(parameterForStudent);

            Assert.AreEqual(schoolRegister.Students.Count, 1);
        }

        [Test]
        public void MethodExecuteWithCorectParametersShouldReturnCorrectOutput()
        {
            IList<string> parameterForStudent = new List<string>() { "Pesho", "Petrov", "10" };
            string expectedResult = "A new student with name Pesho Petrov, grade 10 and ID 0 was created.";
            Mock<ISchoolSystemFactory> mockedSchoolSystemFactory = new Mock<ISchoolSystemFactory>();
            Mock<ISchoolRegister> mockedSchoolRegister = new Mock<ISchoolRegister>();

            CreateStudentCommand createStudentCommand = new CreateStudentCommand(mockedSchoolSystemFactory.Object, mockedSchoolRegister.Object);
            string result = createStudentCommand.Execute(parameterForStudent);

            Assert.AreEqual(expectedResult, result);
        }

    }
}
