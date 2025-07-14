using _BussinessLayerClinics;
using _DataAccessLayerClinics.ScheduleDoctorMapping;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _ClinicsManaegment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class AppoinmentDoctorsController : ControllerBase
    {
        [HttpGet("GetAppoinmentSDoctors")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<DTOScheduleDoctorRead>> GetAllAppoinmentDoctors()
        {
            var appoinmentDoctors = ClsScheduleDoctorMapping.GetAllScheduleDoctors();
            if (appoinmentDoctors == null || !appoinmentDoctors.Any())
            {
                return NotFound("No appointment doctors found.");
            }
            return Ok(appoinmentDoctors);
        }
        [HttpGet("GetAppointmentByDoctorID/{DoctorID}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<IEnumerable<DTOScheduleDoctorRead>> GetAppointmentsForDoctorID(int DoctorID)
        {
           if(DoctorID<0)
            {
                return BadRequest("Doctor ID Is Not Correct");
            }
            var res = ClsScheduleDoctorMapping.GetScheduleForDoctorID(DoctorID);
            if (res == null || res.Count == 0)
            {
                return BadRequest("There is Error in Getting Data");
            }
            return Ok(res);
        }
        [HttpPost("AddAppointmentDoctor")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<DTOScheduleDoctorAdd> AddAppointmentDoctor(DTOScheduleDoctorAdd dtoScheduleDoctorCreate)
        {
            if (dtoScheduleDoctorCreate == null || dtoScheduleDoctorCreate.DoctorID <= 0)
            {
                return BadRequest("Invalid appointment doctor data.");
            }
            if (!ClsValidation.IsAppointmentExist(dtoScheduleDoctorCreate.AppointmentID))
            {
                return BadRequest($"Doctor with ID {dtoScheduleDoctorCreate.AppointmentID} does not exist.");
            }
            ClsScheduleDoctorMapping clsScheduleDoctorMapping = new ClsScheduleDoctorMapping(dtoScheduleDoctorCreate, ClsScheduleDoctorMapping.enMode.add);
            if (clsScheduleDoctorMapping.Save())
            {
                return CreatedAtAction(nameof(GetAppointmentsForDoctorID), new { id = clsScheduleDoctorMapping.ID }, clsScheduleDoctorMapping.dtoScheduleDoctorAdd);
            }
            return BadRequest("Failed to add appointment doctor.");
        }
        [HttpPut("UpdateAppointmentDoctor")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<DTOScheduleDoctorRead> UpdateAppointmentDoctor(DTOScheduleDoctorUpdate dtoScheduleDoctorUpdate)
        {
            if (dtoScheduleDoctorUpdate == null || dtoScheduleDoctorUpdate.ID <= 0)
            {
                return BadRequest("Invalid appointment doctor data.");
            }
            ClsScheduleDoctorMapping clsScheduleDoctorMapping = ClsScheduleDoctorMapping.GetScheduleBYID(dtoScheduleDoctorUpdate.ID);
           clsScheduleDoctorMapping.dtoScheduleDoctorUpdate = dtoScheduleDoctorUpdate;
            if (clsScheduleDoctorMapping.Save())
            {
                return Ok(ClsScheduleDoctorMapping.GetScheduleBYID(dtoScheduleDoctorUpdate.ID));
            }
            return NotFound($"Appointment doctor with ID {dtoScheduleDoctorUpdate.ID} not found.");
        }
    }
}
