using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Exercises.Tests
{
    [TestClass()]
    public class Lucky13Tests
    {
        [TestMethod]
        /*
        Given an array of ints, return true if the array contains no 1's and no 3's.
        GetLucky([0, 2, 4]) → true
        GetLucky([1, 2, 3]) → false
        GetLucky([1, 2, 4]) → false
        */
        public void GetLucky()
        {
            //arrange
            int[] firstInput = { 0, 2, 4 };
            int[] secondInput = { 1, 2, 3 };
            int[] thirdInput = { 1, 2, 4 };
            Lucky13 firstTest = new Lucky13();
            Lucky13 secondTest = new Lucky13();
            Lucky13 thirdTest = new Lucky13();

            //act

            bool firstLuckyResult = firstTest.GetLucky(firstInput);
            bool secondLuckyResult = secondTest.GetLucky(secondInput);
            bool thirdLuckyResult = thirdTest.GetLucky(thirdInput);

            //assert
            Assert.AreEqual(true, firstLuckyResult);
            Assert.AreEqual(false, secondLuckyResult);
            Assert.AreEqual(false, thirdLuckyResult);

        }
    }
}
