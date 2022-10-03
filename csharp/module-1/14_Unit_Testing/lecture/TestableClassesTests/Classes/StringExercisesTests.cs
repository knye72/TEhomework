using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestableClasses.Classes.Tests
{
    [TestClass()]
    public class StringExercisesTests
    {
        //Assert
        //.AreEqual() - compares expected and actual value for equality
        //.AreSame() - verifies two object variables refer to same object
        //.AreNotSame() - verifies two object variables refer to different objects
        //.Fail() - fails without checking conditions
        //.IsFalse()
        //.IsTrue()
        //.IsNotNull()
        //.IsNull()

        /*
        Given two strings, a and b, return the result of putting them together in the order abba,
        e.g. "Hi" and "Bye" returns "HiByeByeHi".
        makeAbba("Hi", "Bye") → "HiByeByeHi"
        makeAbba("Yo", "Alice") → "YoAliceAliceYo"
        makeAbba("What", "Up") → "WhatUpUpWhat"
        */

        [TestMethod]
        public void MakeAbba()
        {
            //Arrange
            StringExercises stringExercises = new StringExercises();

            //Act
            string result = stringExercises.MakeAbba("Hi", "Bye");

            //Assert
            //string expectedResult = "HiByeByeHi"; don't need this line.
            Assert.AreEqual("HiByeByeHi", result);

       
        }
        [TestMethod]
        public void MakeAbbaTestKnownFailure()
        {
 
            //arrange - we've already made an object.
            StringExercises stringExercises = new StringExercises();

            // Act
            string resultTwo = stringExercises.MakeAbba("What", "Up");

            //Assert
            Assert.AreEqual("UpWhatWhatUp", resultTwo, "Please try again"); //put this in wrong on purpose. add a 3rd item as a message in the test explorer

        }

    }
}