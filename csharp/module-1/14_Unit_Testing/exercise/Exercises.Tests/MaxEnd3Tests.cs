using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Exercises.Tests
{
    [TestClass()]
    public class MaxEnd3Tests
    {
        [TestMethod]
        /*
        Given an array of ints length 3, figure out which is larger between the first and last elements
        in the array, and set all the other elements to be that value. Return the changed array.
        MakeArray([1, 2, 3]) → [3, 3, 3]
        MakeArray([11, 5, 9]) → [11, 11, 11]
        MakeArray([2, 11, 3]) → [3, 3, 3]
        */

        public void MakeArray()
        {
            //arrange
            int[] firstNewArray = { 1, 2, 3 };
            int[] secondResponseArray = { 11, 5, 9 };
            int[] thirdTry = { 2, 11, 3 };
            MaxEnd3 firstAttempt = new MaxEnd3();
            MaxEnd3 secondAttempt = new MaxEnd3();
            MaxEnd3 thirdAttempt = new MaxEnd3();

            //act
            int[] firstResult = firstAttempt.MakeArray(firstNewArray);
            int[] secondResult = secondAttempt.MakeArray(secondResponseArray);
            int[] thirdResult = thirdAttempt.MakeArray(thirdTry);

            //assert
            int[] expectationsOne = { 3, 3, 3 };
            int[] expectationsTwo = { 11, 11, 11 };
            int[] expectationsThree = { 3, 3, 3 };
            Assert.AreEqual(expectationsOne, firstResult);
            Assert.AreEqual(expectationsTwo, secondResult);
            Assert.AreEqual(expectationsThree, thirdResult);


        }

    }
}
