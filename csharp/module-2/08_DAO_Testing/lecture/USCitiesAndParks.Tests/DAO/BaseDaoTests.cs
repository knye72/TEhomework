﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data.SqlClient;
using System.IO;
using System.Transactions;

namespace USCitiesAndParks.Tests
{
    [TestClass] //seen this in unit testing.
    public class BaseDaoTests
    {
        private const string DatabaseName = "UnitedStatesTesting";

        private const string AdminConnectionString = @"Server=.\SQLEXPRESS;Database=master;Trusted_Connection=True;";
        protected const string ConnectionString = @"Server=.\SQLEXPRESS;Database=" + DatabaseName + ";Trusted_Connection=True;";

        /// <summary>
        /// The transaction for each test.
        /// </summary>
        private TransactionScope transaction;

        [AssemblyInitialize] // this will run before any of the tests in the project. hence the name BeforeAllTests
        public static void BeforeAllTests(TestContext context)
        {
            string sql = File.ReadAllText("create-test-db.sql").Replace("test_db_name", DatabaseName); //get all the testing data from DB

            //this is what's actually going to make the UnitedStatesTesting DB.
            using (SqlConnection conn = new SqlConnection(AdminConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.ExecuteNonQuery();
            }

            //load the test data into UnitedStatesTesting
            sql = File.ReadAllText("test-data.sql");
            using (SqlConnection conn = new SqlConnection(ConnectionString)) //standard connection string. 
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader reader = cmd.ExecuteReader();
            }
        }

        [AssemblyCleanup] //runs after all the tests have completed and things are being disposed of.
        public static void AfterAllTests()
        {
            // drop the temporary database, which is named UnitedStatesTesting.
            string sql = File.ReadAllText("drop-test-db.sql").Replace("test_db_name", DatabaseName);

            using (SqlConnection conn = new SqlConnection(AdminConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
            }
        }


        [TestInitialize] //runs before each test
        public virtual void Setup()
        {
            // Begin the transaction
            transaction = new TransactionScope();

        }

        [TestCleanup] //runs after each test. 
        public void Cleanup()
        {
            // Roll back the transaction
            transaction.Dispose();
        }

    }
}
