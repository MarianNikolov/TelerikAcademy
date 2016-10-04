using System;
using NUnit.Framework;
using ArmyOfCreatures.Logic.Battles;
using Moq;
using ArmyOfCreatures.Logic;

namespace ArmyOfCreatures.Tests
{
    [TestFixture]
    public class BattleManagerTests
    {
        [Test]
        public void AddCreatures_WhenCreatureIdentifierIsNull_ShouldThrowArgumentNullException()
        {
            var mockedFactory = new Mock<ICreaturesFactory>();
            var mockedLogger = new Mock<ILogger>();

            var battleManager = new BattleManager(mockedFactory.Object, mockedLogger.Object);

            Assert.Throws<ArgumentNullException>(() => battleManager.AddCreatures(null, 1));
        }

        public void AddCreatures_WhenValidIdentifierIsPassed_FactoryShouldCallCreateCreature()
        {
            var mockedFactory = new Mock<ICreaturesFactory>();
            var mockedLogger = new Mock<ILogger>();

            var battleManager = new BattleManager(mockedFactory.Object, mockedLogger.Object);

            Assert.Throws<ArgumentNullException>(() => battleManager.AddCreatures(null, 1));
        }
    }
}
