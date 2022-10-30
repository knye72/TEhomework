using HotelReservations.DAO;
using HotelReservations.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace HotelReservations.Controllers
{
    [Route("reservations")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private IReservationDao reservationDao; //using the interface just allows you to get the version of the DAO that works in this system.
        private IHotelDao hotelDao;
        public ReservationsController(IHotelDao hotelDao, IReservationDao reservationDao)
        {
            this.hotelDao = hotelDao;
            this.reservationDao = reservationDao;
        }

        [HttpGet()]
        public List<Reservation> ListReservations()
        {
            return reservationDao.List();
        }

        [HttpGet("{id}")]
        public ActionResult<Reservation> GetReservation(int id)
        {
            Reservation reservation = reservationDao.Get(id);

            if (reservation != null)
            {
                return reservation;
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("/hotels/{hotelId}/reservations")]
        public ActionResult<List<Reservation>> ListReservationsByHotel(int hotelId)
        {
            Hotel hotel = hotelDao.Get(hotelId);
            if (hotel == null)
            {
                return NotFound();
            }
            return reservationDao.FindByHotel(hotelId);
        }

        [HttpPost()]
        public ActionResult<Reservation> AddReservation(Reservation reservation)
        {
            Reservation added = reservationDao.Create(reservation);
            return Created($"/reservations/{added.Id}", added);
        }

        [HttpDelete("{id}")] //  /reservations/:id
        public ActionResult DeleteReservation(int id) //send back an untyped ActionResult b/c you're not sending a reservation back.
        {
            Reservation existingReservation = reservationDao.Get(id);
            if (existingReservation == null) //if it doesn't exist, it's a 404. can't delete what isn't there.
            {
                return NotFound();
            }
            bool result = reservationDao.Delete(id);

            if (result) //if true and it was deleted
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
