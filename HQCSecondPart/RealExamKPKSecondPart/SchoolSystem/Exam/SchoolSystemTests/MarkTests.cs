using System;
using NUnit.Framework;
using SchoolSystem.Models;

namespace SchoolSystemTests
{
    [TestFixture]
    public class MarkTests
    {
        [Test]
        public void Mark_whenValueParameterIsCorrect_ShoudMakeNewMark()
        {
            int minValue = 2;
            int maxValue = 6;

            for (int i = minValue; i <= maxValue; i++)
            {
                Mark mark = new Mark(Subjct.Bulgarian, i);

                Assert.IsInstanceOf<Mark>(mark);
            }
        }

        [Test]
        public void Mark_whenValueParameterIsCorrect_ShoudParametersSetCorrectly()
        {
            int value = 6;

            Mark mark = new Mark(Subjct.Bulgarian, value);

            Assert.AreEqual(mark.Subject, Subjct.Bulgarian);
            Assert.AreEqual(mark.Value, value);
        }

        [Test]
        public void Mark_whenValueParameterIsLowerThanАllowed_ShoudThrowArgumentException()
        {
            int value = 1;

            Assert.Throws<ArgumentException>(() => new Mark(Subjct.Bulgarian, value));
        }

        [Test]
        public void Mark_whenValueParameterIsBiggerThanАllowed_ShoudThrowArgumentException()
        {
            int value = 7;

            Assert.Throws<ArgumentException>(() => new Mark(Subjct.Bulgarian, value));
        }
    }
}
