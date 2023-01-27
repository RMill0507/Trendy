using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Trendy.Models;
using Trendy.Data;

namespace Trendy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HairCutBookingController : ControllerBase
    {
        private readonly ApiContext _context;

        public HairCutBookingController(ApiContext context)
        {
            _context = context;
        }

        //Creating and editing haircut bookings
        [HttpPost]
        public JsonResult CreateEdit(HairCutBooking booking)
        {
            if(booking.Id == 0)
            {
                _context.Bookings.Add(booking);
            }
            else
            {
                var bookingInDb = _context.Bookings.Find(booking.Id);

                if (bookingInDb == null)
                    return new JsonResult(NotFound());

                bookingInDb = booking;
            }
            _context.SaveChanges();

            return new JsonResult(Ok(booking));
        }
        //Get
        [HttpGet]
        public JsonResult Get(int id)
        {
            var result = _context.Bookings.Find(id);

            if (result == null)
                return new JsonResult(NotFound());

            return new JsonResult(Ok(result));
        }
        [HttpDelete]
        public JsonResult Delete(int id)
        {
            var result = (_context.Bookings.Find(id));

            if (result == null)
                return new JsonResult(NotFound());

            _context.Bookings.Remove(result);
            _context.SaveChanges();

            return new JsonResult(NoContent());
        }

    }
}
