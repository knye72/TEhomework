using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Exercises.Tests
{
    [TestClass()]
    public class DateFashionTests
    {
        /*
        You and your date are trying to get a table at a restaurant. The parameter "you" is the stylishness
        of your clothes, in the range 0..10, and "date" is the stylishness of your date's clothes. The result
        getting the table is encoded as an int value with 0=no, 1=maybe, 2=yes. If either of you is very
        stylish, 8 or more, then the result is 2 (yes). With the exception that if either of you has style of
        2 or less, then the result is 0 (no). Otherwise the result is 1 (maybe).
        dateFashion(5, 10) → 2
        dateFashion(5, 2) → 0
        dateFashion(5, 5) → 1
        */

        [TestMethod]
        public void dateFashion()
        {
            //arrange
            DateFashion firstFashionTest = new DateFashion();
            DateFashion secondFashionTest = new DateFashion();
            DateFashion thirdFashionTest = new DateFashion();

            //act

            int firstFashionResult = firstFashionTest.GetATable(5, 10);
            int secondFashionResult = secondFashionTest.GetATable(5, 2);
            int thirdFashionResult = thirdFashionTest.GetATable(5, 5);

            //assert
            Assert.AreEqual(2, firstFashionResult);
            Assert.AreEqual(0, secondFashionResult);
            Assert.AreEqual(1, thirdFashionResult);

        }
    }
}
