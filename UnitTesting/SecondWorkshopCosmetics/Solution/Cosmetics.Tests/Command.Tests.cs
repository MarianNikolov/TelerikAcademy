namespace Cosmetics.Tests
{
    using Cosmetics.Engine;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class CommandTests
    {
        // ### Class - Cosmetics.Engine.Command
        //#### Test cases:

        // - **Parse** should **return new Command**, when the "input" string is in the required valid format.
        [Test]
        public void Parse_WhenTheStringIsInTheRequiredValidFormat_ShouldReturnNewCommand()
        {
            var input = "CreateCategory";
            var command = Command.Parse(input);

            //Assert.IsInstanceOf(typeof(Command), command);
            Assert.IsInstanceOf<Command>(command);
        }

        // - **Parse** should set correct values to the newly returned Command object's Properties ("Name" & "Parameters"), 
        // when the "input" string is in the valid required format.  
        [Test]
        public void Parse_WhenTheStringIsInTheRequiredValidFormat_ShouldSetCorrectValuesToTheObjectsProperties()
        {
            var input = "CreateCategory FirstParam SecondParam";
            var nameOfCommand = "CreateCategory";
            var firstParam = "FirstParam";
            var secondParam = "SecondParam";
            var command = Command.Parse(input);

            Assert.AreEqual(nameOfCommand, command.Name);
            Assert.AreEqual(firstParam, command.Parameters[0]);
            Assert.AreEqual(secondParam, command.Parameters[1]);
        }

        // - **Parse** should throw **ArgumentNullException** with a message that contains the string "Name",
        // when the "input" string that represents the Command Name is Null Or Empty.
        [Test]
        public void Parse_WhenTheStringNameIsNullOrEmpty_ShouldThrowArgumentNullException()
        {
            string nameOfCommand = " FirstParam";

            var ex = Assert.Throws<ArgumentNullException>(() => Command.Parse(nameOfCommand));
            // StringAssert.Contains("Name", ex.Message);
            Assert.IsTrue(ex.Message.Contains("Name"));
        }

        // - **Parse** should throw **ArgumentNullException** with a message that contains the string "List", 
        // when the "input" string that represents the Command Parameters is Null or Empty.
        [Test]
        public void Parse_WhenTheStringParametersIsNullOrEmpty_ShouldThrowArgumentNullException()
        {
            var nameAndParamsOfCommand = "CreateCategory ";

            var ex = Assert.Throws<ArgumentNullException>(() => Command.Parse(nameAndParamsOfCommand));
            // StringAssert.Contains("List", ex.Message);
            Assert.IsTrue(ex.Message.Contains("List"));
        }
    }
}
