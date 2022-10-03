using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Exercises.Tests
{
    [TestClass()]
    public class SameFirstLastTests
    {
        [TestMethod]
        /*
        Given an array of ints, return true if the array is length 1 or more, and the first element and
        the last element are equal.
        IsItTheSame([1, 2, 3]) → false
        IsItTheSame([1, 2, 3, 1]) → true
        IsItTheSame([1, 2, 1]) → true
        */

        public void IsItTheSame()
        {
            SameFirstLast numberOne = new SameFirstLast();
            int[] firstArray = { 1, 2, 3 };
            SameFirstLast numberTwo = new SameFirstLast();
            int[] secondArray = { 1, 2, 3, 1 };
            SameFirstLast numberThree = new SameFirstLast();
            int[] thirdArray = { 1, 2, 1 };

            bool resultOne = numberOne.IsItTheSame(firstArray);
            bool resultTwo = numberTwo.IsItTheSame(secondArray);
            bool resultThree = numberThree.IsItTheSame(thirdArray);

            Assert.AreEqual(false, resultOne);
            Assert.AreEqual(true, resultTwo);
            Assert.AreEqual(true, resultThree);
        }
    }
}
