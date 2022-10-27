using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using HotelReservations.Models;
using HotelReservations.DAO;

namespace HotelReservations.Controllers
{
    [Route("hotels")] //route attribute defines the location of the controller ("localhost:5001/hotels" or whatever)
    // could also do [Route([controller])] would do the same thing since this is the HotelsController
    [ApiController] //API controller. 

    //anything that comes through the "hotels" path gets handled by the controller.
    public class HotelsController : ControllerBase //inherts from ControllerBase.
    {
        private static IHotelDao hotelDao;

        public HotelsController() //our DAO for the hotels is in here. below.
        {
            if (hotelDao == null)
            {
                hotelDao = new HotelMemoryDao();
            }
        }

        [HttpGet()] //this attribute says that this method handles GET requests. 
        public List<Hotel> ListHotels()
        {
            return hotelDao.List(); //the GET request was for getting a list of hotels, so this method goes and gets it.
        }

        [HttpGet("{id}")] //this is just hotels/:id  <- id hsa been added onto the route.
        public ActionResult<Hotel> GetHotel(int id) //controller methods and controller actions are the same thing.
            // action result means we could return a hotel OR we could return a status code, or a JSON string
            //  or a few other things. you want to return this thing that we asked for (hotel in this case) or a 404/401 error.

        {
            Hotel hotel = hotelDao.Get(id); //go to the DAO and get the hotel.

            if (hotel != null) //if we did get a hotel back/it's not null.
            {
                return hotel; //gimme the hotel.
            }
            else
            {
                return NotFound(); //didn't find it? gimme a notfound code, a 404
            }
        }
    }
}
