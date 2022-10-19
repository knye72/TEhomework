using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using USCitiesAndParks.Models;

namespace USCitiesAndParks.DAO
{
    public class ParkSqlDao : IParkDao
    {
        private readonly string connectionString;

        public ParkSqlDao(string connString)
        {
            connectionString = connString;
        }

        public Park GetPark(int parkId)
        {
            Park park = null;

            using(SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM park WHERE park_id = @park_id", conn);
                command.Parameters.AddWithValue("@park_id", parkId);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read()) //if only one row is expected back, use if to check if it can be read insted of a while loop. 
                {
                    park = CreateParkFromReader(reader);
                }
            }
            return park;
        }

        public IList<Park> GetParksByState(string stateAbbreviation)
        {
            IList<Park> parks = new List<Park>(); //not entirely sure why IList instead of List but the former works here due to the thing above it

            using(SqlConnection parkConnection = new SqlConnection(connectionString))
            {
                parkConnection.Open();
                SqlCommand parkCommand = new SqlCommand("SELECT * FROM park JOIN park_state ON park_state.park_id = park.park_id WHERE state_abbreviation = @state_abbreviation", parkConnection);
                parkCommand.Parameters.AddWithValue("@state_abbreviation", stateAbbreviation);

                SqlDataReader reader = parkCommand.ExecuteReader(); //executes the select query

                //create park object(s) from the data we grabbed from the reader.
                while (reader.Read())
                {
                    Park park = CreateParkFromReader(reader);
                    parks.Add(park);
                }

            }
            return parks;

        }

        public Park CreatePark(Park park)
        {
            throw new NotImplementedException();
        }

        public void UpdatePark(Park park)
        {
            throw new NotImplementedException();
        }

        public void DeletePark(int parkId)
        {
            throw new NotImplementedException();
        }

        public void AddParkToState(int parkId, string state_abbreviation)
        {
            throw new NotImplementedException();
        }

        public void RemoveParkFromState(int parkId, string state_abbreviation)
        {
            throw new NotImplementedException();
        }

        private Park CreateParkFromReader(SqlDataReader reader)
        {
            Park park = new Park();
            park.ParkId = Convert.ToInt32(reader["park_id"]);
            park.ParkName = Convert.ToString(reader["park_name"]);
            park.DateEstablished = Convert.ToDateTime(reader["date_established"]);
            park.Area = Convert.ToDecimal(reader["area"]);
            park.HasCamping = Convert.ToBoolean(reader["has_camping"]);

            return park;
            
        }
    }
}
