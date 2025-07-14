using _3_DataAccessLayerClinics.Models;
using _BussinessLayerClinics;
using _DataAccessLayerClinics.Doctor;
using _DataAccessLayerClinics.Nurse;
using Doctor;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _ClinicsManaegment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class NursesController : ControllerBase
    {
        [HttpGet("GetallNurses")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<DTONurseRead>> GetNurses()
        {
            List<DTONurseRead> nurses = ClsNurse.GetallNurse();
            if (nurses.Count == 0)
            {
                return NotFound("No nurses found.");
            }
            return Ok(nurses);
        }

        [HttpGet("GetNurseDetailsById/{id}", Name = "GetNurseByID")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<DTONurseRead> GetNurseDetailsById(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid nurse ID.");
            }
            ClsNurse nurse = ClsNurse.GetNurseByID(id);
            if (nurse == null)
            {
                return NotFound($"Nurse with ID {id} not found.");
            }
            return Ok(nurse.DTONurseRead);
        }
        [HttpPut("UpdateNurse")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<DTONurseUpdate> UpdateNurse(DTONurseUpdate nurse)
        {
            if (nurse == null)
            {
                return BadRequest("Nurse update data is null.");
            }
            ClsNurse existingNurse = ClsNurse.GetNurseByID(nurse.ID);
            if (existingNurse == null)
            {
                return NotFound($"Nurse with ID {nurse.ID} not found.");
            }
            else if (nurse.ID <= 0)
            {
                return BadRequest("Invalid nurse ID.");
            }
            else if (ClsValidation.IsPhoneExist(nurse.Phone,existingNurse.ID))
            {
                return BadRequest($"Phone number {nurse.Phone} already exists.");
            }
            else if (ClsValidation.IsEmailExist(nurse.Email,existingNurse.ID))
            {
                return BadRequest($"Email {nurse.Email} already exists.");
            }
            else if (ClsValidation.IsUserNameExist(nurse.Username,existingNurse.ID))
            {
                return BadRequest($"Username {nurse.Username} already exists.");
            }
            else
            {

                existingNurse.dTONurseUpdate = nurse;
                if (!existingNurse.Save())
                {
                    return BadRequest("Failed to update nurse.");
                }
                return Ok(existingNurse.dTONurseUpdate);
            }
        }


        [HttpPut("UpdateNursepassword")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<DTODoctorUpdate> UpdateNursePassword([FromBody] DtoUpdatePasswordNurse doctorUpdate)
        {
            if (doctorUpdate == null)
                return BadRequest("Must Fill Object Data");
            if (ClsNurse.UpdatePassword(doctorUpdate))
                return Ok("Successfuly Password Updated.");
            return BadRequest("OldPassword Is Not Correct");

        }



        [HttpDelete("DeleteNurse/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult DeleteNurse(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid nurse ID.");
            }
            if (ClsNurse.DeleteNurse(id))
            {
                return Ok($"Nurse with ID {id} deleted successfully.");
            }
            return BadRequest("Failed to delete nurse. Please check the ID and try again.");
        }
        [HttpPost("AddNurse")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<DTONurseUpdate> AddNurse(DTONurseCreate nurseCreate)
        {
            if (nurseCreate == null)
            {
                return BadRequest("Nurse creation data is null.");
            }
            else if (ClsValidation.IsPhoneExist(nurseCreate.Phone))
            {
                return BadRequest($"Phone number {nurseCreate.Phone} already exists.");
            }
            else if (ClsValidation.IsEmailExist(nurseCreate.Email))
            {
                return BadRequest($"Email {nurseCreate.Email} already exists.");
            }
            else if (ClsValidation.IsUserNameExist(nurseCreate.Username))
            {
                return BadRequest($"Username {nurseCreate.Username} already exists.");
            }
                ClsNurse newNurse = new ClsNurse(nurseCreate, ClsNurse.enMode.add);
            string Salt= PasswordServices.GenerateSaltString();
            string Password=PasswordServices.GenerateHashedPassword(nurseCreate.password, Salt);
            nurseCreate.Salt = Salt;
            nurseCreate.password = Password;

            if (!newNurse.Save())
            {
                return BadRequest("Failed to add nurse.");
            }

            return CreatedAtAction(nameof(GetNurseDetailsById), new { id = newNurse.ID }, newNurse.dTONurseUpdate);
        }

    }
}
