using IntergalacticTravel.Contracts;
using NUnit.Framework;
using System;

namespace IntergalacticTravel.Tests
{
    [TestFixture]
    public class ResourcesFactoryTests
    {
        //GetResources should return a newly created Resources object with correctly set up properties
        //(Gold, Bronze and Silver coins), no matter what the order of the parameters is, 
        //when the input string is in the correct format. (Check with all possible cases):
        [TestCase("create resources gold(20) silver(30) bronze(40)")]
        [TestCase("create resources gold(20) bronze(40) silver(30)")]
        [TestCase("create resources silver(30) bronze(40) gold(20)")]
        [TestCase("create resources silver(30) gold(20) bronze(40)")]
        [TestCase("create resources bronze(40) gold(20) silver(30)")]
        [TestCase("create resources bronze(40) silver(30) gold(20)")]
        public void GetResources_WhenTheInputIsValid_ShouldReturnANewlyCreatedResourcesObjectWithCorrectlyProperties(string command)
        {
            var resoursFactory = new ResourcesFactory();

            var resourses = resoursFactory.GetResources(command);

            Assert.IsInstanceOf<IResources>(resourses);
            Assert.IsTrue(resourses.GoldCoins == 20);
            Assert.IsTrue(resourses.SilverCoins == 30);
            Assert.IsTrue(resourses.BronzeCoins == 40);
        }

        // GetResources should throw InvalidOperationException, which contains the string "command", 
        //when the input string represents an invalid command. (Check with at least 2 different cases).
        //Invalid commands are any commands that does not follow the pattern described above.
        [TestCase("create resources x y z")]
        [TestCase("tansta resources a b")]
        [TestCase("absolutelyRandomStringThatMustNotBeAValidCommand")]
        public void GetResources_WhenTheInputIsInvalid_ShouldThrowInvalidOperationException(string command)
        {
            var resoursFactory = new ResourcesFactory();

            Assert.Throws<InvalidOperationException>(() => resoursFactory.GetResources(command));
        }

        // GetResources should throw OverflowException, when the input string command is in the correct format, 
        //but any of the values that represent the resource amount is larger than uint.MaxValue. (Check with at least 2 different cases)
        [TestCase("create resources silver(10) gold(97853252356623523532) bronze(20)")]
        [TestCase("create resources silver(555555555555555555555555555555555) gold(97853252356623523532999999999) bronze(20)")]
        [TestCase("create resources silver(10) gold(20) bronze(4444444444444444444444444444444444444)")]
        public void GetResources_WhenTheInputIsInValidFormatButValuesThatRepresentTheResourceIsInvalid_ShouldThrowOverflowException(string command)
        {
            var resoursFactory = new ResourcesFactory();

            Assert.Throws<OverflowException>(() => resoursFactory.GetResources(command));
        }
    }
}
