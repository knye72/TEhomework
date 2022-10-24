using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using EmployeeProjects.DAO;
using EmployeeProjects.Models;

namespace EmployeeProjects.Tests.DAO
{
    [TestClass]
    public class TimesheetSqlDaoTests : BaseDaoTests
    {
        private static readonly Timesheet TIMESHEET_1 = new Timesheet(1, 1, 1, DateTime.Parse("2021-01-01"), 1.0M, true, "Timesheet 1");
        private static readonly Timesheet TIMESHEET_2 = new Timesheet(2, 1, 1, DateTime.Parse("2021-01-02"), 1.5M, true, "Timesheet 2");
        private static readonly Timesheet TIMESHEET_3 = new Timesheet(3, 2, 1, DateTime.Parse("2021-01-01"), 0.25M, true, "Timesheet 3");
        private static readonly Timesheet TIMESHEET_4 = new Timesheet(4, 2, 2, DateTime.Parse("2021-02-01"), 2.0M, false, "Timesheet 4");

        private TimesheetSqlDao dao;


        [TestInitialize]
        public override void Setup()
        {
            dao = new TimesheetSqlDao(ConnectionString);
            base.Setup();
        }

        [TestMethod]
        public void GetTimesheet_ReturnsCorrectTimesheetForId()
        {
            Timesheet timesheet = dao.GetTimesheet(1);
            AssertTimesheetsMatch(TIMESHEET_1, timesheet);
        }

        [TestMethod]
        public void GetTimesheet_ReturnsNullWhenIdNotFound()
        {
            Timesheet timesheet = dao.GetTimesheet(99);
            Assert.IsNull(timesheet);
        }

        [TestMethod]
        public void GetTimesheetsByEmployeeId_ReturnsListOfAllTimesheetsForEmployee() //1 of non-working 4. 

        {
            IList<Timesheet> timesheets = dao.GetTimesheetsByEmployeeId(1);
            Assert.AreEqual(2, timesheets.Count);

        }

        [TestMethod]
        public void GetTimesheetsByProjectId_ReturnsListOfAllTimesheetsForProject() //2 of non-working 4.
        {
            IList<Timesheet> timesheets = dao.GetTimesheetsByProjectId(1);
            Assert.AreEqual(3, timesheets.Count);
            AssertTimesheetsMatch(TIMESHEET_1, timesheets[0]);
            AssertTimesheetsMatch(TIMESHEET_2, timesheets[1]);
            AssertTimesheetsMatch(TIMESHEET_3, timesheets[2]);

            timesheets = dao.GetTimesheetsByProjectId(2);
            Assert.AreEqual(1, timesheets.Count);

        }

        [TestMethod]
        public void CreateTimesheet_ReturnsTimesheetWithIdAndExpectedValues() 
        {
            Timesheet testTimesheet = new Timesheet(0, 2, 1, DateTime.Parse("2021-02-01"), 10, true, "Timesheet 5");
            Timesheet newTimesheet = dao.CreateTimesheet(testTimesheet);

            Assert.IsTrue(newTimesheet.TimesheetId > 0);

            testTimesheet.TimesheetId = newTimesheet.TimesheetId;
            AssertTimesheetsMatch(testTimesheet, newTimesheet);
        }

        [TestMethod]
        public void CreatedTimesheetHasExpectedValuesWhenRetrieved()
        {
            Timesheet testTimesheet = new Timesheet(5, 2, 1, DateTime.Parse("2021-02-01"), 10, true, "Timesheet 5");

            Timesheet   timesheet = dao.CreateTimesheet(testTimesheet);
            int newId = timesheet.TimesheetId;

            Timesheet retrievedTimesheet = dao.GetTimesheet(newId);

            AssertTimesheetsMatch(timesheet, retrievedTimesheet);
            
        }

        [TestMethod]
        public void UpdatedTimesheetHasExpectedValuesWhenRetrieved() //3 of non-working 4.
        {
            Timesheet sheetToUpdate = dao.GetTimesheet(1);
            sheetToUpdate.IsBillable = false;
            dao.UpdateTimesheet(sheetToUpdate);

            Timesheet newTimesheet = dao.GetTimesheet(1);
            AssertTimesheetsMatch(sheetToUpdate, newTimesheet);
        }

        [TestMethod]
        public void DeletedTimesheetCantBeRetrieved()
        {
            dao.DeleteTimesheet(1);
            Timesheet retrievedTimesheet = dao.GetTimesheet(1);

            Assert.IsNull(retrievedTimesheet);
        }

        [TestMethod]
        public void GetBillableHours_ReturnsCorrectTotal() //passes but only when you pass in the specific number
                                                           //for first part of Assert.AreEqual.
                                                           //4 of non-working 4.
        {
            decimal billableHours = dao.GetBillableHours(2, 2);
            Assert.AreEqual(2.5M, billableHours);
        }

        private void AssertTimesheetsMatch(Timesheet expected, Timesheet actual)
        {
            Assert.AreEqual(expected.TimesheetId, actual.TimesheetId);
            Assert.AreEqual(expected.EmployeeId, actual.EmployeeId);
            Assert.AreEqual(expected.ProjectId, actual.ProjectId);
            Assert.AreEqual(expected.DateWorked, actual.DateWorked);
            Assert.AreEqual(expected.HoursWorked, actual.HoursWorked);
            Assert.AreEqual(expected.IsBillable, actual.IsBillable);
            Assert.AreEqual(expected.Description, actual.Description);
        }
    }
}
