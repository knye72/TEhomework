using HotelApp.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace HotelApp.Services
{
    public class HotelApiService
    {
        protected static RestClient client = null; 

        public HotelApiService(string apiUrl) //apiurl is the local host, per program.cs. it's where the API we want to interact with lives
                                                // in this case it's http://localhost:3000. 
        {
            if (client == null) //client = something that asks for and retreives data.
            {
                client = new RestClient(apiUrl); //build a new client that interacts with this API. 
            }
        }

        public List<Hotel> GetHotels() //should be at localhost:3000/hotels
        {
            //we need to build a request to the API
            RestRequest request = new RestRequest("hotels"); //makes a request to /hotels.
            //send the request to the API
            IRestResponse<List<Hotel>> response = client.Get<List<Hotel>>(request); //client = client up above in previous constructor.
                                                                                    //IRestReponse<T> is container for data coming back fro mthe API
                                                                                    //use the client (RestClient), make a GET request for specific type of data.
                                                                                    //use the request object that we built.
            if (!response.IsSuccessful) //check to see if it's unsuccessful so we can fix it.
            {
                throw new HttpRequestException("Something went wrong communicating with the server");
            }

            return response.Data; //the data is just the stuff we want, and it's wrapped up in the response object. 
        }

        public List<Review> GetReviews()
        {
            RestRequest request = new RestRequest("reviews");
            IRestResponse<List<Review>> response = client.Get<List<Review>>(request);
            if (!response.IsSuccessful)
            {
                throw new HttpRequestException("Something went wrong communicating with the server");
            }
            return response.Data;
        }

        public Hotel GetHotel(int hotelId) // http://localhost:3000/hotels/1 where 1 is the hotel id
        {
            RestRequest request = new RestRequest($"hotels/{ hotelId }");
            IRestResponse<Hotel> response = client.Get<Hotel>(request);
            if (!response.IsSuccessful)
            {
                throw new HttpRequestException("Something went wrong communicating with the server");
            }
            return response.Data;
           
        }

        public List<Review> GetHotelReviews(int hotelId) //http://localhost:3000/reviews?hotelId=1 where 1 is hotel ID.
        {
            RestRequest request = new RestRequest($"reviews?hotelId={ hotelId }"); //add the query parameter (?) + id onto the end.
            IRestResponse<List<Review>> response = client.Get<List<Review>>(request);
            if (!response.IsSuccessful)
            {
                throw new HttpRequestException("Something went wrong communicating with the server");
            }
            return response.Data;
        }

        public List<Hotel> GetHotelsWithRating(int starRating)
        {
            RestRequest request = new RestRequest($"hotels?stars={ starRating }");
            IRestResponse<List<Hotel>> response = client.Get<List<Hotel>>(request);
            if (!response.IsSuccessful)
            {
                throw new HttpRequestException("Something went wrong communicating with the server");
            }
            return response.Data;
        }

        public City GetPublicAPIQuery()
        {
            RestRequest request = new RestRequest($"https://api.teleport.org/api/cities/geonameid:5128581/"); //this is out on some website's API.
            IRestResponse<City> response = client.Get<City>(request);
            if (!response.IsSuccessful)
            {
                throw new HttpRequestException("Something went wrong communicating with the server");
            }
            return response.Data;
        }
    }
}
