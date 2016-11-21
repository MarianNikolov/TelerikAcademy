using System;
using System.Collections.Generic;
using _04_LongestSubsequenceOfEqualNumbers;
using NUnit.Framework;

namespace _04__LongestSubsequenceOfEqualNumbersTests
{
    [TestFixture]
    public class LongestSubsequenceTests
    {
        private IList<int> testNumbers;

        [Test]
        public void LongestSubsequenceMethod_ShoudReturnLongestSubsequenceOfListOfInt_First()
        {
            // Arrange 
            testNumbers = new List<int>() { 2, 2, 2, 2, 2, 3, 34, 13, 1, 2423, 5, 5, 5, 5, 123, 1, 6};

            // Act
            var result = Startup.LongestSubsequence(testNumbers);
            var stringResult = string.Join(", ", result);

            // Assert
            Assert.AreEqual("2, 2, 2, 2, 2", stringResult);
        }

        [Test]
        public void LongestSubsequenceMethod_ShoudReturnLongestSubsequenceOfListOfInt_Second()
        {
            // Arrange 
            testNumbers = new List<int>() { 4, 1, 5, 345, 345, 3, 6, 7, 8, 23, 111, 523, 2, 6, 6, 6, 6, 6 };

            // Act
            var result = Startup.LongestSubsequence(testNumbers);
            var stringResult = string.Join(", ", result);

            // Assert
            Assert.AreEqual("6, 6, 6, 6, 6", stringResult);
        }

        [Test]
        public void LongestSubsequenceMethod_ShoudReturnLongestSubsequenceOfListOfInt_Third()
        {
            // Arrange 
            testNumbers = new List<int>() { 4, 5, 7, 11, 43, 4, 4, 4, 4, 4, 4, 3, 432, 1, 44, 44, 44, 1, 1, 1, 1, 1 };

            // Act
            var result = Startup.LongestSubsequence(testNumbers);
            var stringResult = string.Join(", ", result);

            // Assert
            Assert.AreEqual("4, 4, 4, 4, 4, 4", stringResult);
        }
    }
}
