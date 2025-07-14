using _BussinessLayerClinics;
using _DataAccessLayerClinics.Speciallty;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _ClinicsManaegment.Controllers
{
    [Route("api/[controller]")]
[ApiController]
    [Authorize]

    public class SpecialtiesController : ControllerBase
{
        [HttpGet("GetAllSpecialties")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<DtoSpecialltyReadUpdate>> GetAllSpecialties()
        {
            var specialties = ClsSpeciallty.GetAllSpecialties();
            if (specialties == null || !specialties.Any())
            {
                return NotFound("No specialties found.");
            }
            return Ok(specialties);
        }
        [HttpGet("GetSpecialtyById/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<DtoSpecialltyReadUpdate> GetSpecialtyById(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid specialty ID.");
            }
            var specialty = ClsSpeciallty.GetSpecialtyById(id);
            if (specialty == null)
            {
                return NotFound($"No specialty found with ID {id}.");
            }
            return Ok(specialty.dtoSpecialltyReadUpdate);
        }
        [HttpPost("AddSpecialty")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<DtoSpecialltyReadUpdate> AddSpecialty( DTOSpecialltyAdd dtoSpecialltyAdd)
        {
            if (dtoSpecialltyAdd == null || string.IsNullOrWhiteSpace(dtoSpecialltyAdd.Name))
            {
                return BadRequest("Invalid specialty data.");
            }
            ClsSpeciallty clsSpeciallty = new ClsSpeciallty(dtoSpecialltyAdd, ClsSpeciallty.enMode.add);
            if (clsSpeciallty.Save())
            {
                return CreatedAtAction(nameof(GetSpecialtyById), new { id = clsSpeciallty.Id }, clsSpeciallty.dtoSpecialltyReadUpdate);
            }
            return BadRequest("Failed to add specialty.");
        }
        [HttpPut("UpdateSpecialty")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<DtoSpecialltyReadUpdate> UpdateSpecialty(DtoSpecialltyReadUpdate dtoSpecialltyReadUpdate)
        {
            if (dtoSpecialltyReadUpdate == null || dtoSpecialltyReadUpdate.Id <= 0 || string.IsNullOrWhiteSpace(dtoSpecialltyReadUpdate.Name))
            {
                return BadRequest("Invalid specialty data.");
            }
            ClsSpeciallty clsSpeciallty = ClsSpeciallty.GetSpecialtyById(dtoSpecialltyReadUpdate.Id);
            if (clsSpeciallty.Save())
            {
                return Ok(clsSpeciallty.dtoSpecialltyReadUpdate);
            }
            return NotFound($"No specialty found with ID {dtoSpecialltyReadUpdate.Id}.");
        }

        [HttpDelete("DeleteSpecialty/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult DeleteSpecialty(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid specialty ID.");
            }
            ClsSpeciallty clsSpeciallty = ClsSpeciallty.GetSpecialtyById(id);
            if (clsSpeciallty == null)
            {
                return NotFound($"No specialty found with ID {id}.");
            }
            if (clsSpeciallty.DeleteSpecialty())
            {
                return Ok($"Specialty with ID {id} deleted successfully.");
            }
            return BadRequest("Failed to delete specialty.");
        }


    }
}
