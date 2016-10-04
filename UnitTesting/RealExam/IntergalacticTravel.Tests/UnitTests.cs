using IntergalacticTravel.Tests.Mocks;
using NUnit.Framework;
using System;
namespace IntergalacticTravel.Tests
{
    [TestFixture]
    public class UnitTests
    {
        //Pay should throw NullReferenceException if the object passed is null.
        [Test]
        public void Pay_WhenObjectIsNull_ShouldThrowNullReferenceException()
        {
            var unit = new Unit(1, "Pesho");

            Assert.Throws<NullReferenceException>(() => unit.Pay(null));
        }

        //Pay should decrease the owner's amount of Resources by the amount of the cost.
        [Test]
        public void Pay_WhenIsInputIsValid_ShouldDecreaseTheOwnersAmount()
        {

            var resoursFactory = new ResourcesFactory();
            var resourses = resoursFactory.GetResources("create resources gold(20) silver(30) bronze(40)");

            var unit = new Unit(1, "Pesho");
            unit.Resources.Add(resourses);

            unit.Pay(resourses);

            Assert.AreEqual(0, unit.Resources.GoldCoins);
            Assert.AreEqual(0, unit.Resources.SilverCoins);
            Assert.AreEqual(0, unit.Resources.BronzeCoins);
        }

        //Pay should return Resource object with the amount of resources in the cost object.
        [Test]
        public void Pay_WhenIsInputIsValid_ShouldReturnResourceObjectWithTheAmountOfResources()
        {

            var resoursFactory = new ResourcesFactory();
            var resourses = resoursFactory.GetResources("create resources gold(20) silver(30) bronze(40)");

            var unit = new Unit(1, "Pesho");
            unit.Resources.Add(resourses);

            var resoursesAfterPay = unit.Pay(resourses);

            Assert.AreEqual(0, unit.Resources.GoldCoins);
            Assert.AreEqual(0, unit.Resources.SilverCoins);
            Assert.AreEqual(0, unit.Resources.BronzeCoins);
            Assert.IsInstanceOf<Resources>(resoursesAfterPay);
        }

    }
}
