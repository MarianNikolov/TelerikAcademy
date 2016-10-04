using Cosmetics.Contracts;
using Cosmetics.Common;
using Cosmetics.Engine;
using NUnit.Framework;
using System;

namespace Cosmetics.Tests
{
    [TestFixture]
    public class CosmeticsFactoryTests
    {
        // ### Class - Cosmetics.Engine.CosmeticsFactory
        // ### Test cases:

        // - **CreateShampoo** should throw **ArgumentNullException**, when the passed "name" parameter is invalid. (Null or Empty, or with length out of range)  
        [Test]
        public void CreateShampoo_WhenThePassedParameterIsInvalid_ShouldThrowArgumentNullException()
        {
            // MISHO MAY BE => MOQ
           // var shampoo = CosmeticsFactory.CreateShampoo("aa", "aa", 22, GenderType.Men, 5, UsageType.EveryDay);
        }

        // - **CreateShampoo** should throw **ArgumentNullException**, when the passed "brand" parameter is invalid. (Null or Empty, or with length out of range)  

        // - **CreateShampoo** should return a** new Shampoo**, when the passed parameters are all valid.

        // - **CreateCategory** should throw **ArgumentNullException**, when the passed "name" parameter is invalid. (Null or Empty, or with length out of range)

        // - **CreateCategory** should return a** new Category**, when the passed parameters are all valid.

        // - **CreateToothpaste** should throw **ArgumentNullException**, when the passed "name" parameter is invalid. (Null or Empty, or with length out of range)

        // - **CreateToothpaste** should throw **ArgumentNullException**, when the passed "brand" parameter is invalid. (Null or Empty, or with length out of range)

        // - **CreateToothpaste** should throw **IndexOutOfRangeException**, when the count of items in the list of ingredients is not in the allowed boundaries.

        // - **CreateShoppingCart** should always return a new ** ShoppingCart**.



    }
}
