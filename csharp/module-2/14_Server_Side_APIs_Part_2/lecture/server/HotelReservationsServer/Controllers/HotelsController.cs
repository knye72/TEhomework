using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using HotelReservations.Models;
using HotelReservations.DAO;

namespace HotelReservations.Controllers
{
    [Route("hotels")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private IHotelDao hotelDao;

        public HotelsController(IHotelDao hotelDao) //passing in the interface and not a class because it wants anything that fits to do this
                                // if it fits the contract, run it.
                                //we just want somethign that gives a list of hotels. don't care if it's from memory dao or api dao or sql dao
                            //data isn't already in the controller, so we have to get the data from someplace. a dao, perhaps. 
                        //the controller depends on having some sort of dao. 
                        //don't care what fits in the hotelDAO box, but we want something. 
                        //in the configuration/startup we've delcared a hotelmemorydao, but it's done this way because of back-end magic.
                        //this is confusing but that's ok. 
        {
            this.hotelDao = hotelDao;
        }

        [HttpGet()]
        public List<Hotel> ListHotels()
        {
            return hotelDao.List();
        }

        [HttpGet("{id}")]
        public ActionResult<Hotel> GetHotel(int id)
        {
            Hotel hotel = hotelDao.Get(id);

            if (hotel != null)
            {
                return hotel;
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("filter")] //http://localhost:5001/hotels/filter?state=something&city?=something
        public List<Hotel> FilterByStateOrCity(string state, string city)//two parameters are keys for query params. 
        {
            List<Hotel> filteredHotels = new List<Hotel>();

            List<Hotel> hotels = ListHotels(); //this is getting all the hotels.

            // return hotels that match state
            foreach (Hotel hotel in hotels)
            {
                if (city != null)
                {
                    // if city was passed we don't care about the state filter
                    if (hotel.Address.City.ToLower().Equals(city.ToLower()))
                    {
                        filteredHotels.Add(hotel);
                    }
                }
                else
                {
                    if (hotel.Address.State.ToLower().Equals(state.ToLower()))
                    {
                        filteredHotels.Add(hotel);
                    }
                }
            }
            return filteredHotels;
        }

    }
}
