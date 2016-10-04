using IntergalacticTravel.Contracts;
using IntergalacticTravel.Exceptions;
using IntergalacticTravel.Tests.Mocks;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace IntergalacticTravel.Tests
{
    [TestFixture]
    public class TeleportStationTests
    {
        //Constructor should set up all of the provided fields(owner, galacticMap & location), 
        //when a new TeleportStation is created with valid parameters passed to the constructor.
        [Test]
        public void Constructor_WhenANewTeleportStationIsCreatedWithValidParameters_ShouldSetUpAllFields()
        {
            var mockedOwner = new Mock<IBusinessOwner>();
            var mockedGalacticMap = new Mock<IEnumerable<IPath>>();
            var mockedLocation = new Mock<ILocation>();

            var teleportStation = new MockedTeleportStation(mockedOwner.Object, mockedGalacticMap.Object, mockedLocation.Object);

            Assert.IsInstanceOf<TeleportStation>(teleportStation);
            Assert.AreSame(mockedOwner.Object, teleportStation.Owner);
            Assert.AreSame(mockedGalacticMap.Object, teleportStation.GalacticMap);
            Assert.AreSame(mockedLocation.Object, teleportStation.Location);
        }

        //TeleportUnit should throw ArgumentNullException, with a message that contains the string "unitToTeleport", 
        //when IUnit unitToTeleport is null.
        [Test]
        public void TeleportUnit_WhenIUnitUnitToTeleportIsNull_ShouldThrowArgumentNullExceptionAndMassageShouldContainSpecialString()
        {
            var exMassageShouldContains = "unitToTeleport";
            var mockedOwner = new Mock<IBusinessOwner>();
            var mockedGalacticMap = new Mock<IEnumerable<IPath>>();
            var mockedLocation = new Mock<ILocation>();

            var teleportStation = new MockedTeleportStation(mockedOwner.Object, mockedGalacticMap.Object, mockedLocation.Object);

            var ex = Assert.Throws<ArgumentNullException>(() => teleportStation.TeleportUnit(null, mockedLocation.Object));
            StringAssert.Contains(exMassageShouldContains, ex.Message);
        }

        //TeleportUnit should throw ArgumentNullException, with a message that contains the string "destination", 
        //when ILocation destination is null.
        [Test]
        public void TeleportUnit_WhenILocationIsNull_ShouldThrowArgumentNullExceptionAndMassageShouldContainSpecialString()
        {
            var exMassageShouldContains = "destination";

            var mockedOwner = new Mock<IBusinessOwner>();
            var mockedGalacticMap = new Mock<IEnumerable<IPath>>();
            var mockedLocation = new Mock<ILocation>();

            var mockedUnit = new Mock<IUnit>();

            var teleportStation = new MockedTeleportStation(mockedOwner.Object, mockedGalacticMap.Object, mockedLocation.Object);

            var ex = Assert.Throws<ArgumentNullException>(() => teleportStation.TeleportUnit(mockedUnit.Object, null));
            StringAssert.Contains(exMassageShouldContains, ex.Message);
        }

        //TeleportUnit should throw TeleportOutOfRangeException, with a message that contains the string "unitToTeleport.CurrentLocation",
        //when а unit is trying to use the TeleportStation from a distant location (another planet for example).
        [Test]
        public void TeleportUnit_WhenAUnitIsTryingToUseTheTeleportStationFromADistantLocation_ShouldThrowTeleportOutOfRangeExceptionAndMassageShouldContainSpecialString()
        {
            var exMassageShouldContains = "unitToTeleport.CurrentLocation";

            var mockedOwner = new Mock<IBusinessOwner>();
            var mockedGalacticMap = new Mock<IEnumerable<IPath>>();
            var mockedLocationForStation = new Mock<ILocation>();

            var mockedPlanetOne = new Mock<IPlanet>();
            var mockedPlanetTwo = new Mock<IPlanet>();
            var mockedGalaxy = new Mock<IGalaxy>();

            mockedGalaxy.Setup(x => x.Name).Returns("firstGalaxy");

            mockedPlanetOne.Setup(x => x.Galaxy).Returns(mockedGalaxy.Object);
            mockedPlanetOne.Setup(x => x.Galaxy.Name).Returns("Earth");

            mockedPlanetTwo.Setup(x => x.Galaxy.Name).Returns("Mars");
            mockedPlanetTwo.Setup(x => x.Galaxy).Returns(mockedGalaxy.Object);

            mockedLocationForStation.Setup(x => x.Planet).Returns(mockedPlanetOne.Object);

            var mockedUnit = new Mock<IUnit>();
            mockedUnit.Setup(x => x.CurrentLocation.Planet).Returns(mockedPlanetTwo.Object);

            var teleportStation = new TeleportStation(mockedOwner.Object, mockedGalacticMap.Object, mockedLocationForStation.Object);

            var ex = Assert.Throws<TeleportOutOfRangeException>(() => teleportStation.TeleportUnit(mockedUnit.Object, mockedLocationForStation.Object));
            StringAssert.Contains(exMassageShouldContains, ex.Message);
        }

        //TeleportUnit should throw InvalidTeleportationLocationException, with a message that contains the string "units will overlap" 
        //when trying to teleport a unit to a location which another unit has already taken.
            [Test]
            public void TeleportUnit_WhenTryingToTeleportAUnitToALocationWhichAnotherTaken_ShouldThrowInvalidTeleportationLocationExceptionAndMassageShouldContainSpecialString()
            {
                var exMassageShouldContains = "units will overlap";

                var mockedOwner = new Mock<IBusinessOwner>();
                var mockedGalacticMap = new Mock<IEnumerable<IPath>>();
                var mockedLocationForStation = new Mock<ILocation>();

                var mockedPlanetOne = new Mock<IPlanet>();
                var mockedPlanetTwo = new Mock<IPlanet>();
                var mockedGalaxy = new Mock<IGalaxy>();

                mockedGalaxy.Setup(x => x.Name).Returns("firstGalaxy");
                mockedPlanetOne.Setup(x => x.Galaxy).Returns(mockedGalaxy.Object);
                mockedPlanetOne.Setup(x => x.Galaxy.Name).Returns("Earth");

                mockedPlanetTwo.Setup(x => x.Galaxy.Name).Returns("Mars");
                mockedPlanetTwo.Setup(x => x.Galaxy).Returns(mockedGalaxy.Object);
                mockedLocationForStation.Setup(x => x.Planet).Returns(mockedPlanetOne.Object);

                var mockedUnit = new Mock<IUnit>();
                mockedUnit.Setup(x => x.CurrentLocation.Planet).Returns(mockedPlanetTwo.Object);

                var teleportStation = new TeleportStation(mockedOwner.Object, mockedGalacticMap.Object, mockedLocationForStation.Object);

                var ex = Assert.Throws<InvalidTeleportationLocationException>(() => teleportStation.TeleportUnit(mockedUnit.Object, mockedLocationForStation.Object));
                StringAssert.Contains(exMassageShouldContains, ex.Message);
            }

        //TeleportUnit should throw LocationNotFoundException, with a message that contains the string "Galaxy", when trying to teleport a unit to a Galaxy, which is not found in the locations list of the teleport station.


        //TeleportUnit should throw LocationNotFoundException, with a message that contains the string "Planet", when trying to teleport a unit to a Planet, which is not found in the locations list of the teleport station.


        //TeleportUnit should throw InsufficientResourcesException, with a message that contains the string "FREE LUNCH", when trying to teleport a unit to a given Location, but the service costs more than the unit's current available resources.


        //TeleportUnit should require a payment from the unitToTeleport for the provided services, when all of the validations pass successfully and the unit is ready for teleportation.


        //TeleportUnit should obtain a payment from the unitToTeleport for the provided services, when all of the validations pass successfully and the unit is ready for teleportation, and as a result - the amount of Resources of the TeleportStation must be increased by the amount of the payment.


        //TeleportUnit should Set the unitToTeleport's previous location to unitToTeleport's current location, when all of the validations pass successfully and the unit is being teleported.


        //TeleportUnit should Set the unitToTeleport's current location to targetLocation, when all of the validations pass successfully and the unit is being teleported.


        //TeleportUnit should Add the unitToTeleport to the list of Units of the targetLocation (Planet.Units), when all of the validations pass successfully and the unit is on its way to being teleported.


        //TeleportUnit should Remove the unitToTeleport from the list of Units of the unit's current location (Planet.Units), when all of the validations pass successfully and the unit is on its way to being teleported.

        //PayProfits should return the total amount of profits(Resources) generated using the TeleportUnit service, when the argument passed represents the actual owner of the TeleportStation.


    }
}
