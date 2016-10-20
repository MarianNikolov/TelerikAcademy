using System;
using Moq;
using NUnit.Framework;
using SchoolSystem.Models;

namespace SchoolSystemTests
{
    [TestFixture]
    public class StudentTests
    {
        [Test]
        public void Student_whenValueParameterIsCorrect_ShoudMakeNewStudent()
        {
            string firstName = "Pesho";
            string lastName = "Peshov";

                Student testStudent = new Student(firstName, lastName, Grade.Four);

                Assert.IsInstanceOf<Student>(testStudent);
        }

        [Test]
        public void Student_whenValueParameterIsCorrect_ShoudParametersSetCorrectly()
        {
            string firstName = "Pesho";
            string lastName = "Peshov";
            Grade grade = Grade.Four;

            Student testStudent = new Student(firstName, lastName, grade);

            Assert.AreEqual(testStudent.FirstName, firstName);
            Assert.AreEqual(testStudent.LastName, lastName);
            Assert.AreEqual(testStudent.Grads, grade);
        }

        [Test]
        public void Student_whenValueParameterFirstNameIsNull_ShoudThrowArgumentNullException()
        {
            string lastName = "Peshov";
            Grade grade = Grade.Four;

            Assert.Throws<ArgumentNullException>(() => new Student(null, lastName, grade));
        }

        [Test]
        public void Student_whenValueParameterLastNameIsNull_ShoudThrowArgumentNullException()
        {
            string firstName = "Pesho";
            Grade grade = Grade.Four;

            Assert.Throws<ArgumentNullException>(() => new Student(firstName, null, grade));
        }

        [Test]
        public void Student_whenValueParameterFirstNameIsWithIncorrectLowerLength_ShoudThrowArgumentException()
        {
            string firstName = "P";
            string lastName = "Peshov";
            Grade grade = Grade.Four;

            Assert.Throws<ArgumentException>(() => new Student(firstName, lastName, grade));
        }

        [Test]
        public void Student_whenValueParameterFirstNameIsWithIncorrectBiggerLength_ShoudThrowArgumentException()
        {
            string firstName = "Peshosssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssss";
            string lastName = "Peshov";
            Grade grade = Grade.Four;

            Assert.Throws<ArgumentException>(() => new Student(firstName, lastName, grade));
        }

        [Test]
        public void Student_whenValueParameterLastNameIsWithIncorrectLowerLength_ShoudThrowArgumentException()
        {
            string firstName = "Pesho";
            string lastName = "P";
            Grade grade = Grade.Four;

            Assert.Throws<ArgumentException>(() => new Student(firstName, lastName, grade));
        }

        [Test]
        public void Student_whenValueParameterLastNameIsWithIncorrectBiggerLength_ShoudThrowArgumentException()
        {
            string firstName = "Pesho";
            string lastName = "Pessssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssshov";
            Grade grade = Grade.Four;

            Assert.Throws<ArgumentException>(() => new Student(firstName, lastName, grade));
        }

        [Test]
        public void ListMark_ShoudReturnCorectMessage()
        {
            string expectedResult = "English => 6";

            string firstName = "Pesho";
            string lastName = "Peshov";
            Subjct subject = Subjct.English;
            Grade grade = Grade.Four;
            int valueMark = 6;

            Student testStuden = new Student(firstName, lastName, grade);
            Mark mark = new Mark(subject, valueMark);

            testStuden.Mark.Add(mark);

            string result = testStuden.ListMarks();

            Assert.AreEqual(result, expectedResult);
        }
    }
}
