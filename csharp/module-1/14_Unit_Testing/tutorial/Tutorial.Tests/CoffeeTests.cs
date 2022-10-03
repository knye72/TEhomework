using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using TechElevator.Bookstore;

namespace Tutorial.Tests
{  
    [TestClass]
    public class CoffeeTests
    {
        [TestMethod]
        public void Constructor_ValidParameters_SetsProperties()
        {
            //Arrange. not much to do here.

            //Act. make the code.
            Coffee coffee = new Coffee("Large", "Decaf", new string[] { "cream", "sugar" }, 2.99M);

            //Assert. Verify the properties.
            Assert.AreEqual("Large", coffee.Size);
            Assert.AreEqual("Decaf", coffee.Blend);
            Assert.AreEqual(2.99M, coffee.Price);
            Assert.AreEqual(2, coffee.Additions.Length);
            

        }
    }


}
