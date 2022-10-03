using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestableClasses.Classes.Tests
{
    [TestClass()] //signifies that this class contains automated tests. 
    public class LoopsAndArrayExercisesTests
    {
        //CollectionAssert
        //.AllItemsAreNotNull() - Looks at each item in actual collection for not null
        //.AllItemsAreUnique() - Checks for uniqueness among actual collection
        //.AreEqual() - Checks to see if two collections are equal (same order and quantity)
        //.AreEquilavent() - Checks to see if two collections have same element in same quantity, any order
        //.AreNotEqual() - Opposite of AreEqual
        //.AreNotEquilavent() - Opposite or AreEqualivent
        //.Contains() - Checks to see if collection contains a value/object

        [TestMethod]
        public void MiddleWayTest()
        {
            //Arrange - set up what we need for the test. 
            LoopsAndArrayExercises loopsAndArrayExercises = new LoopsAndArrayExercises(); //you'll get red squiggles here until you add a using thing at top and add project reference in the project.
            int[] firstInput = { 1, 2, 3 };
            int[] secondInput = { 4, 5, 6 };

            //Act - run the code we're testing to get the result.
            int[] actualResult = loopsAndArrayExercises.MiddleWay(firstInput, secondInput);

            //Assert - make sure that our expectations and reality line up.
            int[] expectedResult = { 2, 5 };
            CollectionAssert.AreEqual(expectedResult, actualResult);

            // Run one more in this TestMethod

            //Arrange - gonna keep using the LoopsAndArrayExercised object from earlier.

            int[] thirdInput = { 7, 7, 7 };
            int[] fourthInput = { 3, 8, 0 };

            //Act

            int[] actualResultTwo = loopsAndArrayExercises.MiddleWay(thirdInput, fourthInput);

            //Assert
            int[] expectedResultTwo = { 7, 8 };
            CollectionAssert.AreEqual(expectedResultTwo, actualResultTwo);
            CollectionAssert.AllItemsAreNotNull(actualResultTwo); //just making sure it's not null.
            //we can run multiple of these assertions on the same test. 

            
        }

    }
}