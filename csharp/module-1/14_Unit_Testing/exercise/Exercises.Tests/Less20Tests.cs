using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Exercises.Tests
{
    [TestClass()]
    public class Less20Tests
    {
        /*
        Return true if the given non-negative number is 1 or 2 less than a multiple of 20. So for example 38
        and 39 return true, but 40 returns false.
        (Hint: Think "mod".)
        less20(18) → true
        less20(19) → true
        less20(20) → false
        */
        [TestMethod]

        public void Less20Test()
        {
            //arrange
            Less20 firstLessTest = new Less20();
            Less20 secondLessTest = new Less20();
            Less20 thirdLessTest = new Less20();

            //act
            bool firstResult = firstLessTest.IsLessThanMultipleOf20(18);
            bool secondResult = secondLessTest.IsLessThanMultipleOf20(19);
            bool thirdResult = thirdLessTest.IsLessThanMultipleOf20(20);

            //assert
            Assert.AreEqual(true, firstResult);
            Assert.AreEqual(true, secondResult);
            Assert.AreEqual(false, thirdResult);
        }
    }
}
