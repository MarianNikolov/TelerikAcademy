using System;
using NUnit.Framework;
using ArmyOfCreatures.Logic;
using ArmyOfCreatures.Extended;

namespace ArmyOfCreatures.Tests
{
    [TestFixture]
    public class CreaturesfactoryTests
    {
        [TestCase("Angel")]
        [TestCase("Archangel")]
        [TestCase("ArchDevil")]
        [TestCase("Behemoth")]
        [TestCase("Devil")]
        public void CreaturesFactory_WhenValidNameIsPassed_ShouldReturnExpectedType(string name)
        {
            var factory = new ExtendedCreaturesFactory(); // new CreaturesFactory();
            var creature = factory.CreateCreature(name);

            Assert.AreEqual(name, creature.GetType().Name);
        }

        [Test]
        public void CreaturesFactory_WhenInvalidNameIsNotPassed_ShouldThrowArgumentException()
        {
            var factory = new ExtendedCreaturesFactory(); // new CreaturesFactory();
            // var creature = factory.CreateCreature(name);

            Assert.Throws<ArgumentException>(() => factory.CreateCreature("Gosho"));
        }

        [Test]
        public void CreaturesFactory_WhenInvalidNameIsNotPassed_ShouldThrowArgumentExceptionWithExpectedMassage()
        {
            var factory = new ExtendedCreaturesFactory();

            try
            {
                factory.CreateCreature("Gosho");
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual($"Invalid creature type \"Gosho\"!", ex.Message);
            } 
        }
    }
}
