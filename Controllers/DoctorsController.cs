using _BussinessLayerClinics;
using _DataAccessLayerClinics.Doctor;
using DataAccessLayerClinics.DTOS;
using Doctor;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace _ClinicsManaegment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DoctorsController : ControllerBase
    {
        [HttpGet("GetallDoctors")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<DTODoctorRead>> GetDoctors()
        {
            List<DTODoctorRead> doctors = ClsDoctor.GetAllDoctors();

            if (doctors.Count == 0)
            {
                return NotFound("No doctors found.");
            }

            return Ok(doctors);
        }
        [HttpGet("GetDoctorDetailsById/{id}", Name = "GetDoctorByID")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<DTODoctorRead> GetDoctorDetailsById(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid doctor ID.");
            }
            ClsDoctor doctor = ClsDoctor.GetDoctorReadByID(id);
            if (doctor == null)
            {
                return NotFound($"Doctor with ID {id} not found.");
            }
            return Ok(doctor.DtoDoctorRead);
        }
        [HttpPut("UpdateDoctor")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<DTODoctorUpdate> UpdateDoctor(DTODoctorUpdate doctorUpdate)
        {
            if (doctorUpdate == null)
            {
                return BadRequest("Doctor update data is null.");
            }
            ClsDoctor doctor = ClsDoctor.GetDoctorReadByID(doctorUpdate.ID);
            if (doctor == null)
            {
                return NotFound($"Doctor with ID {doctorUpdate.ID} not found.");
            }
            else if (doctorUpdate.ID <= 0)
            {
                return BadRequest("Invalid doctor ID.");
            }
            else if (ClsValidation.IsPhoneExist(doctorUpdate.Phone,doctor.ID))
            {
                return BadRequest($"Phone number {doctorUpdate.Phone} already exists.");
            }
            else if (ClsValidation.IsEmailExist(doctorUpdate.Email,doctor.ID))
            {
                return BadRequest($"Email {doctorUpdate.Email} already exists.");
            }
            else if (ClsValidation.IsUserNameExist(doctorUpdate.Username, doctor.ID))
            {
                return BadRequest($"Username {doctorUpdate.Username} already exists.");
            }

            else
            {
                doctor.DtoDoctorUpdate = doctorUpdate;

                if (!doctor.Save())
                {
                    return BadRequest("Can Not Add Doctor");
                }
                return Ok(doctor.DtoDoctorUpdate);
            }


        }
        [HttpPut("UpdateDoctorpassword")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<DTODoctorUpdate> UpdateDoctorPassword([FromBody]DToUpdatePasswordDoctor doctorUpdate)
        {
            if (doctorUpdate == null)
                return BadRequest("Must Fill Object Data");
            if (ClsDoctor.UpdatePassword(doctorUpdate))
                return Ok("Successfuly Password Updated.");
            return BadRequest("OldPassword Is Not Correct");

        }


        [HttpPost("AddDoctor")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<DTODoctorUpdate> AddDoctor(DTODoctorCreate doctorCreate)
        {
            if (doctorCreate == null)
            {
                return BadRequest("Doctor data is null.");
            }
            else if (ClsValidation.IsPhoneExist(doctorCreate.Phone))
            {
                return BadRequest($"Phone number {doctorCreate.Phone} already exists.");
            }
            else if (ClsValidation.IsEmailExist(doctorCreate.Email))
            {
                return BadRequest($"Email {doctorCreate.Email} already exists.");
            }
            else if (ClsValidation.IsUserNameExist(doctorCreate.Username))
            {
                return BadRequest($"Username {doctorCreate.Username} already exists.");
            }
            ClsDoctor doctor = new ClsDoctor(doctorCreate, ClsDoctor.enMode.Add);
            string Salt = PasswordServices.GenerateSaltString();
            string Password = PasswordServices.GenerateHashedPassword(doctorCreate.password, Salt);
            doctorCreate.Salt = Salt;
            doctorCreate.password = Password;
            if (!doctor.Save())
            {
                return BadRequest("Can Not Add Doctor");
            }
            return CreatedAtRoute("GetDoctorByID", new { id = doctor.DtoDoctorUpdate.ID }, doctor.DtoDoctorUpdate);
        }

        [HttpDelete("DeleteDoctor/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult DeleteDoctor(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid doctor ID.");
            }
            ClsDoctor doctor = ClsDoctor.GetDoctorReadByID(id);
            if (doctor == null)
            {
                return NotFound($"Doctor with ID {id} not found.");
            }
            else if (ClsValidation.IsDoctorHasActiveBooking(id))
            {
                return BadRequest($"Doctor with ID {id} has active bookings and cannot be deleted.");
            }
       
            if (!ClsDoctor.DeleteDoctor(id))
            {
                return BadRequest("Can Not Delete Doctor");
            }
            return Ok($"Doctor with ID {id} deleted successfully.");
        }
    }

}

