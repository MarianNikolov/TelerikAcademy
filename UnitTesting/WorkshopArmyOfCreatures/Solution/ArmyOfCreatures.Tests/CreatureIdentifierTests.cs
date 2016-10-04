using ArmyOfCreatures.Logic.Battles;
using NUnit.Framework;
using System;

namespace ArmyOfCreatures.Tests
{
    [TestFixture]
    public class CreatureIdentifierTests
    {
        [Test]
        public void CreatureIdentifier_WhenNullValueIsPassed_ShouldThrowArgumentNullException()
        {
            //  var identifier = CreatureIdentifier.CreatureIdentifierFromString(null); // new CreatureIdentifier() nqma go zashtoto e private

            Assert.Throws<ArgumentNullException>(() => CreatureIdentifier.CreatureIdentifierFromString(null));
        }

        [Test]
        public void CreatureIdentifier_WhenInvalidValueToParseIntIsPassed_ShouldThrowFormatException()
        {
            // valid: Angel(2); invalid: Angel(test); - 
            // pri invalid parsvaneto na dvoikata ne e vuzmojno i int.Pares() hvurlq FormatException

            Assert.Throws<FormatException>(() => CreatureIdentifier.CreatureIdentifierFromString("Angel(test)"));
        }

        [Test]
        public void CreatureIdentifier_WhenInvalidValueToParseIntIsPassed_ShouldThrowIndexOutOfRangeException()
        {
            Assert.Throws<IndexOutOfRangeException>(() => CreatureIdentifier.CreatureIdentifierFromString("Angel"));
        }

        [Test]
        public void CreatureIdentifier_WhenValidValueIsPassed_ShouldReturmExpectedType()
        {
            var identifier = CreatureIdentifier.CreatureIdentifierFromString("Angel(1)");

            Assert.IsInstanceOf<CreatureIdentifier>(identifier);
        }

        [Test]
        public void CreatureIdentifier_WhenValidValueIsPassed_ShouldReturmExpectedCreatureType()
        {
            var identifier = CreatureIdentifier.CreatureIdentifierFromString("Angel(1)");

            Assert.AreEqual("Angel", identifier.CreatureType);
        }

        [Test]
        public void CreatureIdentifier_WhenValidValueIsPassed_ShouldReturmExpectedArmyNumber()
        {
            var identifier = CreatureIdentifier.CreatureIdentifierFromString("Angel(1)");
            var expectedArmy = 1;

            Assert.AreEqual(expectedArmy, identifier.ArmyNumber);
        }

        [Test]
        public void CreatureIdentifier_WhenValidValueIsPassed_ToStringShouldReturmExpectedString()
        {
            var identifier = CreatureIdentifier.CreatureIdentifierFromString("Angel(1)");
            var result = identifier.ToString();

            Assert.AreEqual("Angel(1)", result);
        }
    }
}
