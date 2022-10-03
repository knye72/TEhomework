using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Exercises.Tests
{
    [TestClass()]

    public class FrontTimesTests
    {
        /*
       Given a string and a non-negative int n, we'll say that the front of the string is the first 3 chars, or
       whatever is there if the string is less than length 3. Return n copies of the front;
       frontTimes("Chocolate", 2) → "ChoCho"
       frontTimes("Chocolate", 3) → "ChoChoCho"
       frontTimes("Abc", 3) → "AbcAbcAbc"
       */

        [TestMethod]
        public void FrontTimes()
        {
            //arrange
            FrontTimes firstFront = new FrontTimes();
            FrontTimes secondFront = new FrontTimes();
            FrontTimes thirdFront = new FrontTimes();

            //act
            string firstFrontResult = firstFront.GenerateString("Chocolate", 2);
            string secondFrontResult = secondFront.GenerateString("Chocolate", 3);
            string thirdFrontResult = thirdFront.GenerateString("Abc", 3);

            //assert
            Assert.AreEqual("ChoCho", firstFrontResult);
            Assert.AreEqual("ChoChoCho", secondFrontResult);
            Assert.AreEqual("AbcAbcAbc", thirdFrontResult);
        }
    }
}
