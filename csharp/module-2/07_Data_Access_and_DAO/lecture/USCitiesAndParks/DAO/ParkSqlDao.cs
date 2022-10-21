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
            //returning a park object
            //we also take in a park object.
            //do we want to return the same park object as the one we took in? no
            // we want to put the park object we took in into the database, then make sure it got there OK by retrieving the data and giving it back instead.
            //it has all the same information as the original park object, but now it includes the park_id from SQL, and THAT makes it a new object.

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO park(park_name, date_established, area, has_camping) " +
                    "OUTPUT INSERTED.park_id VALUES(@park_name, @date_established, @area, @has_camping);", conn);
                cmd.Parameters.AddWithValue("@park_name", park.ParkName);
                cmd.Parameters.AddWithValue("@date_established", park.DateEstablished);
                cmd.Parameters.AddWithValue("@area", park.Area);
                cmd.Parameters.AddWithValue("@has_camping", park.HasCamping);

                //executeScalar() since we expect the id back from the query.
                int newParkId = Convert.ToInt32(cmd.ExecuteScalar()); //have to conver to a data type that C# understands.

                Park newPark = GetPark(newParkId); //we wrote a method for getting a specific park from the DB yesterday, so we may as well use it.
                return newPark;
            }

        }

        public void UpdatePark(Park park)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("UPDATE park SET park_name = @park_name, date_established = @date_established, area = @area, has_camping = @has_camping WHERE park_id = @park_id", conn);
                cmd.Parameters.AddWithValue("@park_name", park.ParkName);
                cmd.Parameters.AddWithValue("@date_established", park.DateEstablished);
                cmd.Parameters.AddWithValue("@area", park.Area);
                cmd.Parameters.AddWithValue("@has_camping", park.HasCamping);
                cmd.Parameters.AddWithValue("@park_id", park.ParkId);
                

                cmd.ExecuteNonQuery(); //don't need to save the number of rows changed anywhere. 
            }
        }

        public void DeletePark(int parkId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("DELETE FROM park_state WHERE park_id = @park_id;" + "DELETE FROM park WHERE park_id = @park_id; ", conn);
                cmd.Parameters.AddWithValue("@park_id", parkId);

                cmd.ExecuteNonQuery(); //no results needed.
            }        
        }



        public void AddParkToState(int parkId, string state_abbreviation)
        {
            //INSERT INTO park_state(park_id, state_abbreviation) VALUES(67, OH);
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("INSERT INTO park_state(park_id, state_abbreviation) VALUES(@park_id, @state_abbreviation); ", conn);
                cmd.Parameters.AddWithValue("@park_id", parkId);
                cmd.Parameters.AddWithValue("state_abbreviation", state_abbreviation);

                cmd.ExecuteNonQuery();//no results back. just want to run the command against the DB.

            }
        }

        public void RemoveParkFromState(int parkId, string state_abbreviation)//have to remove the relationship b/w park and state before you delete the park altogether.
        {
            //DELETE * FROM park_state WHERE park_id = 68;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("DELETE * FROM park_state WHERE park_id = @park_id AND state_abbreviation = @state_abbreviation; ", conn);
                cmd.Parameters.AddWithValue("@park_id", parkId);
                cmd.Parameters.AddWithValue("state_abbreviation", state_abbreviation);

                cmd.ExecuteNonQuery();

        } }

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
