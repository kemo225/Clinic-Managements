using _BussinessLayerClinics;
using _DataAccessLayerClinics.Appoinemts;
using _DataAccessLayerClinics.Booking;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _ClinicsManaegment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class AppointmentsController : ControllerBase
    {
        [HttpDelete("DeleteAppoinmentByID/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult DeleteAppointmentByID(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid booking ID provided.");
            }
            if (ClsAppoinement.DeleteAppointment(id))
            {
                return Ok($"Booking with ID {id} has been deleted successfully.");
            }
            return NotFound("Failed to delete booking.");
        }

        [HttpGet("GetAppointmentbyID/{ID}", Name = "GetAppointmentID")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public ActionResult<DTOAppointmentRead> GetAppointmentByID(int ID)
        {
            if (ID <= 0)
            {
                return BadRequest("Invalid ID provided.");
            }
            var ClsApp = ClsAppoinement.GetAppointmenrByID(ID);
            if (ClsApp == null)
            {
                return NotFound($"No found ID : {ID}.");
            }
            return Ok(ClsApp.dToAppoinmentRead);
        }

        [HttpPost("AddAppointments")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<DTOAppointmentRead> addAppointments(DToAddAppoinment DTOappAdd)
        {
            if (DTOappAdd == null)
            {
                return BadRequest(" data is required.");
            }
            ClsAppoinement clsapp = new ClsAppoinement(DTOappAdd, ClsAppoinement.enMode.Add);
            if (clsapp.Save())
            {
                return CreatedAtRoute("GetAppointmentID", new { id = clsapp.Id }, clsapp.dToAppoinmentRead);
            }
            return BadRequest("Failed to add booking.");






        }
    }
}
