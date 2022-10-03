using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.Collections.Generic;
using System.Text;

namespace Exercises.Tests
{
    [TestClass()]
    public class AnimalGroupNameTests
    {
        /*
         * Given the name of an animal, return the name of a group of that animal
         * (e.g. "Elephant" -> "Herd", "Rhino" - "Crash").
         *
         * The animal name should be case insensitive so "elephant", "Elephant", and
         * "ELEPHANT" should all return "Herd".
         *
         * If the name of the animal is not found, null, or empty, return "unknown".
         *
         * Rhino -> Crash
         * Giraffe -> Tower
         * Elephant -> Herd
         * Lion -> Pride
         * Crow -> Murder
         * Pigeon -> Kit
         * Flamingo -> Pat
         * Deer -> Herd
         * Dog -> Pack
         * Crocodile -> Float
         *
         * GetHerd("giraffe") → "Tower"
         * GetHerd("") -> "unknown"
         * GetHerd("walrus") -> "unknown"
         * GetHerd("Rhino") -> "Crash"
         * GetHerd("rhino") -> "Crash"
         * GetHerd("elephants") -> "unknown"
         *
         */
        [TestMethod]
        public void GetHerd()
        {
            //arrange
            AnimalGroupName firstAnimalGroup = new AnimalGroupName();
            AnimalGroupName secondAnimalGroup = new AnimalGroupName();
            AnimalGroupName thirdAnimalGroup = new AnimalGroupName();
            AnimalGroupName fourthAnimalGroup = new AnimalGroupName();
            AnimalGroupName fifthAnimalGroup = new AnimalGroupName();
            AnimalGroupName sixthAnimalGroup = new AnimalGroupName();


            //act
            string firstAnimalResult = firstAnimalGroup.GetHerd("rhino");
            string secondAnimalResult = secondAnimalGroup.GetHerd("Rhino");
            string thirdAnimalResult = thirdAnimalGroup.GetHerd("");
            string fourthAnimalResult = fourthAnimalGroup.GetHerd("giraffe");
            string fifthAnimalResult = fifthAnimalGroup.GetHerd("walrus");
            string sixthAnimalResult = sixthAnimalGroup.GetHerd("elephants");

            //assert

            Assert.AreEqual("Crash", firstAnimalResult);
            Assert.AreEqual("Crash", secondAnimalResult);
            Assert.AreEqual("unknown", thirdAnimalResult);
            Assert.AreEqual("Tower", fourthAnimalResult);
            Assert.AreEqual("unknown", fifthAnimalResult);
            Assert.AreEqual("unknown", sixthAnimalResult);

        }
    }
}
