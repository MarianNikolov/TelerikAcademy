namespace Cosmetics.Tests
{
    using Contracts;
    using Cosmetics.Common;
    using Cosmetics.Products;
    using Moq;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class ValidatorTests
    {
        //### Class - Cosmetics.Common.Validator
        //#### Test cases:

        // - **CheckIfNull** should throw **NullReferenceException**, when the parameter**"obj"** is null.  
        [Test]
        public void CheckIfNull_WhenTheParameterIsNull_ShouldThrowNullReferenceException()
        {
            // var validator = new Validator();
            Assert.Throws<NullReferenceException>(() => Validator.CheckIfNull(null));
        }

        // - **CheckIfNull** should **NOT throw** any Exceptions, when the parameter **"obj"** is NOT null.  
        [Test]
        public void CheckIfNull_WhenTheParameterIsNotNull_ShouldNotThrowException()
        {
            var mockedShampoo = new Mock<IShampoo>();
           //var shampoo = new Shampoo("aaa", "bbb", 2, GenderType.Men, 2, UsageType.EveryDay);
           Assert.DoesNotThrow(() => Validator.CheckIfNull(mockedShampoo.Object));
        }

        // - **CheckIfStringIsNullOrEmpty** should throw **NullReferenceException**, when the parameter**"text"** is null or empty.
        [Test]
        public void CheckIfStringIsNullOrEmpty_WhenTheParameterIsNull_ShouldThrowNullReferenceException()
        {
            Assert.Throws<NullReferenceException>(() => Validator.CheckIfStringIsNullOrEmpty(null));
        }

        // - **CheckIfStringIsNullOrEmpty** should **NOT throw** any Exceptions, when the parameter**"text"** is NOT null or empty.  
        [Test]
        public void CheckIfStringIsNullOrEmpty_WhenTheParameterIsNotNull_ShouldNOTThrowAnyExceptions()
        {
            var parameter = "Pesho";

            Assert.DoesNotThrow(() => Validator.CheckIfStringIsNullOrEmpty(parameter));
        }

        // - **CheckIfStringLengthIsValid** should throw **IndexOutOfRangeException**, 
        // when the length of the parameter **"text"** is lower than the minimum allowed value 
        // or greater than the maximum allowed value.
        [TestCase ("PeshoGoshoIvanDragan")]
        [TestCase ("Ivo")]
        public void CheckIfStringLengthIsValid_WhenTheLengthOfParameterIsLowerThanTheMinimumOrGreaterThanTheMaximumAllowedValue_ShouldThrowIndexOutOfRangeException(string parameter)
        {
            var max = 10;
            var min = 5;

            Assert.Throws<IndexOutOfRangeException>(() => Validator.CheckIfStringLengthIsValid(parameter, max, min));
        }

        // - **CheckIfStringLengthIsValid** should **NOT throw** any Exceptions, when the length of the parameter "text" is in the allowed boundaries.
        [Test]
        public void CheckIfStringLengthIsValid_WhenTheLengthOfParameterIsInTheAllowedBoundaries_ShouldNOTThrowAnyExceptions()
        {
            var parameter = "Petkan";
            var max = 10;
            var min = 5;

            Assert.DoesNotThrow(() => Validator.CheckIfStringLengthIsValid(parameter, max, min));
        }
    }
}
