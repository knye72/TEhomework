using RestSharp;
using System.Collections.Generic;
using AuctionApp.Models;
using System.Net.Http;

namespace AuctionApp.Services
{
    public class AuctionApiService
    {
        public IRestClient client;

        public AuctionApiService(string apiUrl)
        {
            client = new RestClient(apiUrl);
        }

        public List<Auction> GetAllAuctions()
        {
            RestRequest request = new RestRequest("auctions");
            IRestResponse<List<Auction>> response = client.Get<List<Auction>>(request);
            if (!response.IsSuccessful)
            {
                throw new HttpRequestException("Something went wrong communicating with the server");
            }
            return response.Data;
            throw new System.NotImplementedException();
        }

        public Auction GetDetailsForAuction(int auctionId)
        {
            RestRequest request = new RestRequest($"auctions/{ auctionId }");
            IRestResponse<Auction> response = client.Get<Auction>(request);
            if (!response.IsSuccessful)
            {
                throw new HttpRequestException("Something went wrong communicating with the server");
            }
            return response.Data;
           
        }

        public List<Auction> GetAuctionsSearchTitle(string searchTerm)
        {
            RestRequest request = new RestRequest($"auctions?title_like={ searchTerm }");
            IRestResponse<List<Auction>> response = client.Get<List<Auction>>(request);
            if (!response.IsSuccessful)
            {
                throw new HttpRequestException("Something went wrong communicating with the server");
            }
            return response.Data;
    
        }

        public List<Auction> GetAuctionsSearchPrice(double searchPrice)
        {
            RestRequest request = new RestRequest($"auctions?currentBid_lte={searchPrice}");
            IRestResponse<List<Auction>> response = client.Get<List<Auction>>(request);
            if (!response.IsSuccessful)
            {
                throw new HttpRequestException("Something went wrong communicating with the server");
            }
            return response.Data;

        }
    }
}
