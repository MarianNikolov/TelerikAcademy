using System;
using NUnit.Framework;
using SchoolSystem.Models;

namespace SchoolSystemTests
{
    [TestFixture]
    public class TeacherTests
    {
        [Test]
        public void Teacher_whenValueParameterIsCorrect_ShoudMakeNewStudent()
        {
            string firstName = "Cecka";
            string lastName = "Cacheva";
            Subjct sybject = Subjct.Bulgarian;

            Teacher testTeacher = new Teacher(firstName, lastName, sybject);

            Assert.IsInstanceOf<Teacher>(testTeacher);
        }

        [Test]
        public void Teacher_whenValueParameterIsCorrect_ShoudParametersSetCorrectly()
        {
            string firstName = "Cecka";
            string lastName = "Cacheva";
            Subjct sybject = Subjct.Bulgarian;

            Teacher tsetTeacher = new Teacher(firstName, lastName, sybject);

            Assert.AreEqual(tsetTeacher.FirstName, firstName);
            Assert.AreEqual(tsetTeacher.LastName, lastName);
            Assert.AreEqual(tsetTeacher.Subject, sybject);
        }

        [Test]
        public void Teacher_whenValueParameterFirstNameIsNull_ShoudThrowArgumentNullException()
        {
            string lastName = "Cacheva";
            Subjct sybject = Subjct.Bulgarian;

            Assert.Throws<ArgumentNullException>(() => new Teacher(null, lastName, sybject));
        }

        [Test]
        public void Teacher_whenValueParameterLastNameIsNull_ShoudThrowArgumentNullException()
        {
            string firstName = "Cecka";
            Subjct sybject = Subjct.Bulgarian;

            Assert.Throws<ArgumentNullException>(() => new Teacher(firstName, null, sybject));
        }

        [Test]
        public void Teacher_whenValueParameterFirstNameIsWithIncorrectLowerLength_ShoudThrowArgumentException()
        {
            string firstName = "C";
            string lastName = "Cacheva";
            Subjct sybject = Subjct.Bulgarian;

            Assert.Throws<ArgumentException>(() => new Teacher(firstName, lastName, sybject));
        }

        [Test]
        public void Teacher_whenValueParameterFirstNameIsWithIncorrectBiggerLength_ShoudThrowArgumentException()
        {
            string firstName = "Cessssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssscka";
            string lastName = "Cacheva";
            Subjct sybject = Subjct.Bulgarian;

            Assert.Throws<ArgumentException>(() => new Teacher(firstName, lastName, sybject));
        }

        [Test]
        public void Teacher_whenValueParameterLastNameIsWithIncorrectLowerLength_ShoudThrowArgumentException()
        {
            string firstName = "Cecka";
            string lastName = "C";
            Subjct sybject = Subjct.Bulgarian;

            Assert.Throws<ArgumentException>(() => new Teacher(firstName, lastName, sybject));
        }

        [Test]
        public void Teacher_whenValueParameterLastNameIsWithIncorrectBiggerLength_ShoudThrowArgumentException()
        {
            string firstName = "Cecka";
            string lastName = "Cacssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssheva";
            Subjct sybject = Subjct.Bulgarian;

            Assert.Throws<ArgumentException>(() => new Teacher(firstName, lastName, sybject));
        }

        [Test]
        public void AddMark_ShoudAddCorrectlyMark()
        {
            string firstName = "Cecka";
            string lastName = "Cacheva";
            Subjct sybject = Subjct.Bulgarian;
            string firstStudentName = "Pesho";
            string lastStudentName = "Peshov";
            Grade grade = Grade.Four;
            float valueMark = 4;

            Teacher testTeacher = new Teacher(firstName, lastName, sybject);
            Student testStudent = new Student(firstStudentName, lastStudentName, grade);

            testTeacher.AddMark(testStudent, valueMark);

            Assert.AreEqual(testStudent.Mark[0].Value, valueMark);
        }
    }
}
