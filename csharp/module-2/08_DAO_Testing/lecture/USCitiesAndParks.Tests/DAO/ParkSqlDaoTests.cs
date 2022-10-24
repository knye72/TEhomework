using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using USCitiesAndParks.DAO;
using USCitiesAndParks.Models;

namespace USCitiesAndParks.Tests
{
    [TestClass]
    public class ParkSqlDaoTests : BaseDaoTests
    {
        private static readonly Park PARK_1 = new Park(1, "Park 1", DateTime.Parse("1800-01-02"), 100, true);
        private static readonly Park PARK_2 = new Park(2, "Park 2", DateTime.Parse("1900-12-31"), 200, false);
        private static readonly Park PARK_3 = new Park(3, "Park 3", DateTime.Parse("2000-06-15"), 300, false);

        private ParkSqlDao dao; //declared up here. dao is the actual connection and we get a new parksqldao for each test. 

        [TestInitialize]
        public override void Setup()
        {
            dao = new ParkSqlDao(ConnectionString); //getting a new DAO and new connection before every test. 
            base.Setup(); //open a transaction before every test so that it rolls back at the end of the test. 
        }

        [TestMethod]
        public void GetPark_ReturnsCorrectParkForId()
        {
            //try getting park 2 from the test database
            Park park = dao.GetPark(2); //this should get the park with id 2 from test db. 
            AssertParksMatch(PARK_2, park); //compares and asserts that these two match. 
        }

        [TestMethod]
        public void GetPark_ReturnsNullWhenIdNotFound()
        {
            Park park = dao.GetPark(500); //doesn't exist, so it should come back null
            Assert.IsNull(park);
        }

        [TestMethod]
        public void GetParksByState_ReturnsAllParksForState()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void GetParksByState_ReturnsEmptyListForAbbreviationNotInDb()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void CreatePark_ReturnsParkWithIdAndExpectedValues()
        {
            Park testPark = new Park(0, "Test Park", DateTime.Now, 900, true); //0 as a park ID should get auto-incremented when it goes into the DB.
            Park newParkFromDB = dao.CreatePark(testPark); //try to create testPark in the DB

            //shouldn't be able to have a park ID of 0. 
            Assert.IsTrue(newParkFromDB.ParkId > 0);

            //check the rest of the values from the park that came out of the DB to see if they match testPark.
            Assert.AreEqual(testPark.ParkName, newParkFromDB.ParkName); //could do a bunch of these or could do it differently below.
            testPark.ParkId = newParkFromDB.ParkId; //set the id of test park to the new id
            AssertParksMatch(testPark, newParkFromDB);
        }

        [TestMethod]
        public void CreatedParkHasExpectedValuesWhenRetrieved()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void UpdatedParkHasExpectedValuesWhenRetrieved()
        {
            Park parkToUpdate = dao.GetPark(2); //getting a park so we can update it.

            parkToUpdate.HasCamping = true; 

            dao.UpdatePark(parkToUpdate); //updates the park

            Park retrievedPark = dao.GetPark(2); //get the park again now that it has (hopefully) updated

            AssertParksMatch(parkToUpdate, retrievedPark); //do they match?
        }

        [TestMethod]
        public void DeletedParkCantBeRetrieved()
        {
            dao.DeletePark(3);

            Park retrievedPark = dao.GetPark(3); //shouldn't work.
            Assert.IsNull(retrievedPark); //should be null sincei t doens't exist anymore.
        }

        [TestMethod]
        public void ParkAddedToStateIsInListOfParksByState()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void ParkRemovedFromStateIsNotInListOfParksByState()
        {
            Assert.Fail();
        }

        private void AssertParksMatch(Park expected, Park actual)
        {
            Assert.AreEqual(expected.ParkId, actual.ParkId);
            Assert.AreEqual(expected.ParkName, actual.ParkName);
            Assert.AreEqual(expected.DateEstablished.Date, actual.DateEstablished.Date);
            Assert.AreEqual(expected.Area, actual.Area);
            Assert.AreEqual(expected.HasCamping, actual.HasCamping);
        }
    }
}
