using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using USCitiesAndParks.Models;

namespace USCitiesAndParks.DAO
{
    public class CitySqlDao : ICityDao  //class plus interface. c# stuff.
    {
        private readonly string connectionString;

        public CitySqlDao(string connString)  //CitySqlDao instantiated in program.cs, which is where the connection string comes from.
        {
            connectionString = connString;
        }

        //method to retrieve city data from database.
        public City GetCity(int cityId)
        {
            City city = null;

            using (SqlConnection conn = new SqlConnection(connectionString)) //'using' automatically closes connection when finished
                //               name   new     connection  use this connection string (which is in program.cs)
            {
                conn.Open(); //opens connection to DB. 
                SqlCommand cmd = new SqlCommand("SELECT city_id, city_name, state_abbreviation, population, area FROM city WHERE city_id = @city_id;", conn);
                // builds a sql query, names it, and then we define it ^^ here. select columns from table where __ and then connect         ^placeholder/SQL parameter

                cmd.Parameters.AddWithValue("@city_id", cityId); //adds a value for the SQL parameter of @city_id in the query string above.
                //^sql command. params. add a param. placeholder. actual value.
                //alternately could've selected all from city in the original SqlCommand, but the point is getting a specific city.

                SqlDataReader reader = cmd.ExecuteReader(); //actually runs your query against the SQL database.

                if (reader.Read()) //if we can read the result set (no errors, data rows exist)
                {
                    city = CreateCityFromReader(reader); //create a city object from the results
                }
            }
            return city; //the city object
        }

        public IList<City> GetCitiesByState(string stateAbbreviation)
        {
            IList<City> cities = new List<City>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT city_id, city_name, state_abbreviation, population, area FROM city WHERE state_abbreviation = @state_abbreviation;", conn);
                cmd.Parameters.AddWithValue("@state_abbreviation", stateAbbreviation);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    City city = CreateCityFromReader(reader);
                    cities.Add(city);
                }
            }

            return cities;
        }

        public City CreateCity(City city)
        {
            int newCityId;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("INSERT INTO city (city_name, state_abbreviation, population, area) " +
                                                "OUTPUT INSERTED.city_id " +
                                                "VALUES (@city_name, @state_abbreviation, @population, @area);", conn);
                cmd.Parameters.AddWithValue("@city_name", city.CityName);
                cmd.Parameters.AddWithValue("@state_abbreviation", city.StateAbbreviation);
                cmd.Parameters.AddWithValue("@population", city.Population);
                cmd.Parameters.AddWithValue("@area", city.Area);

                newCityId = Convert.ToInt32(cmd.ExecuteScalar());
            }
            return GetCity(newCityId);
        }

        public void UpdateCity(City city)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("UPDATE city SET city_name = @city_name, state_abbreviation = @state_abbreviation, population = @population, area = @area WHERE city_id = @city_id;", conn);
                cmd.Parameters.AddWithValue("@city_name", city.CityName);
                cmd.Parameters.AddWithValue("@state_abbreviation", city.StateAbbreviation);
                cmd.Parameters.AddWithValue("@population", city.Population);
                cmd.Parameters.AddWithValue("@area", city.Area);
                cmd.Parameters.AddWithValue("@city_id", city.CityId);

                cmd.ExecuteNonQuery(); // returns the number of rows changed but we're not doing anything with that information.
            }
        }

        public void DeleteCity(int cityId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("DELETE FROM city WHERE city_id = @city_id;", conn);
                cmd.Parameters.AddWithValue("@city_id", cityId);

                cmd.ExecuteNonQuery();
            }
        }

        private City CreateCityFromReader(SqlDataReader reader)
        {
            City city = new City();
            city.CityId = Convert.ToInt32(reader["city_id"]);
            city.CityName = Convert.ToString(reader["city_name"]);
            city.StateAbbreviation = Convert.ToString(reader["state_abbreviation"]);
            city.Population = Convert.ToInt32(reader["population"]);
            city.Area = Convert.ToDecimal(reader["area"]);

            return city;
        }
    }
}
