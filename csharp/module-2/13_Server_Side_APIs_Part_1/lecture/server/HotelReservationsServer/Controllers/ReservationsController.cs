using HotelReservations.DAO;
using HotelReservations.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace HotelReservations.Controllers
{
    [Route("reservations")] // localhost:5001/reservations
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private static IReservationDao reservationDao;
        private static IHotelDao hotelDao;
        public ReservationsController()
        {
            if (hotelDao == null)
            {
                hotelDao = new HotelMemoryDao();
            }
            if (reservationDao == null)
            {
                reservationDao = new ReservationMemoryDao();
            }
        }

        [HttpGet()]
        public List<Reservation> GetAllReservations() //need 1 method to get all reservations.
        {
            return reservationDao.List();
        }


        [HttpGet("{id}")]        //GET request goes to /reservations/:ID 
            //curly brackets mean it's a placeholder

        public ActionResult<Reservation> GetReservationById(int id) // "id" needs to match whatever we put as placeholder in HttpGet

        {
            Reservation reservation = reservationDao.Get(id);

            if(reservation != null)
            {
                return reservation;
            }
            else
            {
                return NotFound();
            }
        }

        //get reservations by hotel ID - tori thinks it should go in the reservations controller
        //the expected route would be /hotels/:id/reservations
        [HttpGet("/hotels/{hotelid}/reservations")] //starting with slash takes control of the toute away from the route attribute
                //and changes the path to what we've changed it to.
        public ActionResult<List<Reservation>> ListReservationByHotel(int hotelid) //must match names.
        {
            Hotel hotel = hotelDao.Get(hotelid); //find the hotel first
            if(hotel == null) // return 404 if the hotel doesn't exist.
            {
                return NotFound();
            }
            return reservationDao.FindByHotel(hotelid); //empty list is fine if there are no reservations, so don't need a 404 here.
        }



        [HttpPost()] //add reservation
                     // POST requests just go to /reservations, which is defined at the top.
        public ActionResult<Reservation> AddReservation(Reservation newReservation) //if expecting a data jobject from the request,
                                                                                    //it goes in the parameters.
        {
            Reservation addedReservation = reservationDao.Create(newReservation); //try to add the new reservation to wherever our data comes from
            if(addedReservation != null)
            {
                //return the reservation here + 201 Created status.
                //this needs to have hte route to the newly created thing.
                //Created(URL of the new thing, the new thing)
                return Created($"/reservations/{addedReservation.Id}", addedReservation); 
            }
            else
            {
                return Problem("Can't create this reservation");
            }
        }


        //update reservation
        [HttpPut("{id}")] //  /reservations/:id
        public ActionResult<Reservation> UpdateReservation(int id, Reservation reservation) 
        {
            Reservation existingReservation = reservationDao.Get(id);
            if(existingReservation == null) //if it doesn't exist
            {
                return NotFound();
            }

            // do the updating
            Reservation updatedReservation = reservationDao.Update(existingReservation.Id, reservation);

            return updatedReservation;
        }

        //delete reservation
        [HttpDelete("{id}")] //  /reservations/:id
        public ActionResult DeleteReservation(int id) //send back an untyped ActionResult b/c you're not sending a reservation back.
        {
            Reservation existingReservation = reservationDao.Get(id);
            if (existingReservation == null) //if it doesn't exist, it's a 404. can't delete what isn't there.
            {
                return NotFound();
            }
            bool result = reservationDao.Delete(id);

            if(result) //if true and it was deleted
            {
                return NoContent(); //204 No Content. shows that it was a success but nothing is there.
            }
            else
            {
                return StatusCode(500);
            }
            
        }
    }
}
