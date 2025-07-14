using _BussinessLayerClinics;
using _DataAccessLayerClinics.Booking;
using _DataAccessLayerClinics.BookingDeletes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _ClinicsManaegment.Controllers
{
    [Route("api/[controller]")]
[ApiController]
    [Authorize]

    public class FinesController : ControllerBase
{
        [HttpGet("Fines")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<DTOBookingDeletesRead>> GetAllFines()
        {
            var Fines = ClsFineBooking.GetAllFine();
            if (Fines == null || Fines.Count == 0)
            {
                return NotFound("No bookings found.");
            }
            return Ok(Fines);
        }
    }
}
