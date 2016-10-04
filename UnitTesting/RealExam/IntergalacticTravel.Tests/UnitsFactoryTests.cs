using System;
using NUnit.Framework;
using IntergalacticTravel.Exceptions;

namespace IntergalacticTravel.Tests
{
    [TestFixture]
    public class UnitsFactoryTests
    {
        //GetUnit should return new Procyon unit, when a valid corresponding command is passed
        //(i.e. "create unit Procyon Gosho 1");
        [Test]
        public void GetUnit_WhenCommandIsValid_ShouldReturnNewProcyonUnit()
        {
            var unitFactory = new UnitsFactory();

            var unit = unitFactory.GetUnit("create unit Procyon Gosho 1");

            Assert.IsInstanceOf<Procyon>(unit);  
        }

        //GetUnit should return new Luyten unit, when a valid corresponding command is passed
        //(i.e. "create unit Luyten Pesho 2");
        [Test]
        public void GetUnit_WhenCommandIsValid_ShouldReturnNewLuytenUnit()
        {
            var unitFactory = new UnitsFactory();

            var unit = unitFactory.GetUnit("create unit Luyten Pesho 2");

            Assert.IsInstanceOf<Luyten>(unit);
        }

        //GetUnit should return new Lacaille unit, when a valid corresponding command is passed
        //(i.e. "create unit Lacaille Tosho 3");
        [Test]
        public void GetUnit_WhenCommandIsValid_ShouldReturnNewLacailleUnit()
        {
            var unitFactory = new UnitsFactory();

            var unit = unitFactory.GetUnit("create unit Lacaille Tosho 3");

            Assert.IsInstanceOf<Lacaille>(unit);
        }

        //GetUnit should throw InvalidUnitCreationCommandException, 
        //when the command passed is not in the valid format described above. 
        //(Check for at least 2 different cases)
        [TestCase("createUnitLacailleTosho3")]
        [TestCase(null)]
        [TestCase("")]
        public void GetUnit_WhenCommandIsInvalid_ShouldThrowInvalidUnitCreationCommandException(string command)
        {
            var unitFactory = new UnitsFactory();

            Assert.Throws<InvalidUnitCreationCommandException>(() => unitFactory.GetUnit(command));
        }
    }
}
