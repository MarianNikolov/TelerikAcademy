using System;
using NUnit.Framework;
using Cosmetics.Engine;
using System.IO;
using Cosmetics.Contracts;
using Moq;
using Cosmetics.Products;
using System.Text;

namespace Cosmetics.Tests
{
    [TestFixture]
    public class CosmeticsEngineTests
    {
        // ### Class - Cosmetics.Engine.CosmeticsEngine
        // ### Test cases:

        // - **Start** should throw **ArgumentNullException**, when the "input" string of commands is not in the correct format.
        [Test]
        public void Start_WhenTheInputStringIsNotInTheCorrectFormat_ShouldThrowArgumentNullException()
        {
            var cosmeticsEngine = new CosmeticsEngine(null, null);
            string nameOfCommand = " FirstParam";
            StringReader sr = new StringReader(nameOfCommand);
            Console.SetIn(sr);

            Assert.Throws<ArgumentNullException>(() => cosmeticsEngine.Start());
        }

        // - **Start** should read, parse and execute**"CreateCategory" command**, 
        // when the passed input string is in the format that represents a CreateCategory command, 
        // which should result in adding the new Category in the list of categories.
        [Test]
        public void Start_WhenThePassedStringIsInTheFormatThatRepresentsACreateCategoryAndAddingTheNewCategory_ShouldReadParseAndExecute()
        {
            string nameOfCommand = "CreateCategory TestCategoty";
            var categoryName = "TestCategoty";

            StringReader sr = new StringReader(nameOfCommand);
            Console.SetIn(sr);

            var sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);
            Console.SetOut(sw);
            var mockedFactory = new Mock<ICosmeticsFactory>();

            mockedFactory.Setup(
                x => x.CreateCategory(It.IsAny<string>()))
                .Returns(() => 
                {
                    return new Category(categoryName);
                } );

            var cosmeticsEngine = new CosmeticsEngine(mockedFactory.Object, null);
            cosmeticsEngine.Start();

            Assert.AreEqual(sb.ToString().Trim(), string.Format("Category with name {0} was created!", categoryName));
        }

        // - **Start** should read, parse and execute**"AddToCategory" command**, 
        //when the passed input string is in the format that represents a AddToCategory command, 
        //which should result in adding the selected product in the respective category.

        // - **Start** should read, parse and execute**"RemoveFromCategory" command**, when the passed input string is in the format that represents a RemoveFromCategory command, which should result in removing the selected product from the respective category.  

        // - **Start** should read, parse and execute**"ShowCategory" command**, when the passed input string is in the format that represents a ShowCategory command, which should result in calling the Print() method of the respective cateogry.

        // - **Start** should read, parse and execute**"CreateShampoo" command**, when the passed input string is in the format that represents a CreateShampoo command, which should result in adding the newly created shampoo in the list of products.

        // - **Start** should read, parse and execute**"CreateToothpaste" command**, when the passed input string is in the format that represents a CreateToothpaste command, which should result in adding the newly created toothpaste in the list of products.    

        // - **Start** should read, parse and execute**"AddToShoppingCart" command**, when the passed input string is in the format that represents a AddToShoppingCart command, which should result in adding the selected product to the shopping cart.  

        // - **Start** should read, parse and execute**"RemoveFromShoppingCart" command**, when the passed input string is in the format that represents a RemoveFromShoppingCart command, which should result in removing the selected product from the shopping cart.


    }
}
