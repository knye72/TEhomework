using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AuctionApp.Models;
using AuctionApp.DAO;

namespace AuctionApp.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuctionsController : ControllerBase
    {
        private readonly IAuctionDao dao;

        public AuctionsController(IAuctionDao auctionDao = null)
        {
            if (auctionDao == null)
            {
                dao = new AuctionMemoryDao();
            }
            else
            {
                dao = auctionDao;
            }
        }

        /*[HttpGet()]
        public List<Auction> GetAllAuctions()
        {
            return dao.List();
        }*/

        [HttpGet("{id}")]
        public ActionResult<Auction> GetAuctionById(int id)
        {
            Auction auction = dao.Get(id);
            if(auction != null)
            {
                return auction;
            }
            else
            {
                return auction;
            }
        }
        [HttpPost()]

        public ActionResult<Auction> AddAuction(Auction newAuction)
        {
            Auction addedAuction = dao.Create(newAuction);
            if(addedAuction != null)
            {
                return Created($"/auctions/{addedAuction.Id}", addedAuction);
            }
            else
            {
                return Problem("Can't do it.");
            }
        }


        [HttpGet()]

        public List<Auction> GetAuctionsByTermAndPrice(string title_like = "", double currentBid_lte = 0)
        {

            if(title_like != "" && currentBid_lte != 0)
            {
                return dao.SearchByTitleAndPrice(title_like, currentBid_lte);
            }
            else if(title_like != "" && currentBid_lte == 0)
            {
                return dao.SearchByTitle(title_like);
            }
            else if (title_like == "" && currentBid_lte != 0)
            {
                return dao.SearchByPrice(currentBid_lte);
            }
            else
            {
                return dao.List();
            }

        }

        /*[HttpGet("/auctions?title_like=")]

        public List<Auction> GetAuctionsBySearchTerm(string title_like = "")
        {

            if (dao.SearchByTitle(title_like) != null)
            {
                return dao.SearchByTitle(title_like);
            }
            else
            {
                return dao.List();
            }
        }*/

    }
}
