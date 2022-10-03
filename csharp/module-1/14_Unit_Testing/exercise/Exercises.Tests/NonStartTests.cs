using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Exercises.Tests
{
    [TestClass()]

    public class NonStartTests
    {
        [TestMethod]
        /*
        Given 2 strings, return their concatenation, except omit the first char of each. The strings will
        be at least length 1.
        GetPartialString("Hello", "There") → "ellohere"
        GetPartialString("java", "code") → "avaode"
        GetPartialString("shotl", "java") → "hotlava"
        */

        public void GetPartialString()
        {
            NonStart firstSetup = new NonStart();
            NonStart secondSetup = new NonStart();
            NonStart thirdSetup = new NonStart();

            string resultOne = firstSetup.GetPartialString("Hello", "There");
            string resultTwo = secondSetup.GetPartialString("java", "code");
            string resultThree = thirdSetup.GetPartialString("shotl", "java");

            Assert.AreEqual("ellohere", resultOne);
            Assert.AreEqual("avaode", resultTwo);
            Assert.AreEqual("hotlava", resultThree);
        }
    }
}
