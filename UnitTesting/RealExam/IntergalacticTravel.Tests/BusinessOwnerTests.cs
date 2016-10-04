using System;
using NUnit.Framework;
using System.Collections.Generic;
using Moq;
using IntergalacticTravel.Contracts;

namespace IntergalacticTravel.Tests
{
    [TestFixture]
    public class BusinessOwnerTests
    {
        //CollectProfits should increase the owner Resources by the total amount of Resources
        //generated from the Teleport Stations that are in his possession.
        [Test]
        public void CollectProfits_ShouldIncreaseTheOwnerResourcesByTheTotalAmountOfResourcesGeneratedFromTheTeleportStations()
        {
            var mockedGalacticMap = new Mock<IEnumerable<IPath>>();
            var mockedLocationForStation = new Mock<ILocation>();

            var resoursFactory = new ResourcesFactory();
            var resourses = resoursFactory.GetResources("create resources gold(20) silver(30) bronze(40)");

            var mockedColectionOfTeleportStation = new Mock<ICollection<ITeleportStation>>();

            var owner = new BusinessOwner(1, "Pesho", mockedColectionOfTeleportStation.Object);

            var teleportStation = new TeleportStation(owner, mockedGalacticMap.Object, mockedLocationForStation.Object);
            owner.CollectProfits();

            Assert.AreEqual(resourses.GoldCoins, owner.Resources.GoldCoins);

        }
    }
}
