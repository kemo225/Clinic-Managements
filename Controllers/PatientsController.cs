using _3_DataAccessLayerClinics.Models;
using _BussinessLayerClinics;
using _DataAccessLayerClinics.Patient;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _ClinicsManaegment.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        [HttpGet("GetallPatients")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<DTOPatientReadUpdate>> GetPatients()
        {
            List<DTOPatientReadUpdate> patients = ClsPatient.GetPatients();
            if (patients.Count == 0)
            {
                return NotFound("No patients found.");
            }
            return Ok(patients);
        }
        [HttpGet("GetPatientById/{id}", Name = "GetPatientByID")]

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<DTOPatientReadUpdate> GetPatientById(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid patient ID.");
            }
            ClsPatient patient = ClsPatient.GetPatientByID(id);
            if (patient == null)
            {
                return NotFound($"Patient with ID {id} not found.");
            }
            return Ok(patient.DtoReadUpdate);
        }
        [HttpDelete("DeletePatient/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult DeletePatient(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid patient ID.");
            }
            if (ClsPatient.DeletePatientbyID(id))
            {
                return Ok($"Patient with ID {id} deleted successfully.");
            }
            return NotFound("Patient not found.");

        }

        [HttpPost("AddPatient")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<DTOPatientReadUpdate> AddPatient(DTOPatientAdd patient)
        {
            if (patient == null)
            {
                return BadRequest("Patient data is null.");
            }
            else if (ClsValidation.IsPhoneExist(patient.Phone))
            {
                return BadRequest($"Phone number {patient.Phone} already exists.");
            }
            else if (ClsValidation.IsEmailExist(patient.Email))
            {
                return BadRequest($"Email {patient.Email} already exists.");
            }
          
            var createdPatient = new ClsPatient(patient, ClsPatient.enMode.Add);

            if (!createdPatient.Save())
            {
                return BadRequest("Failed to create patient.");
            }

            return CreatedAtRoute(nameof(GetPatientById), new { id = createdPatient.ID }, createdPatient.DtoReadUpdate);

        }
        [HttpPut("UpdatePatient")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType (StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<DTOPatientReadUpdate> UpdatePatient(DTOPatientReadUpdate patientUpdate)
        {
            if (patientUpdate == null)
            {
                return BadRequest("Patient update data is null.");
            }
            else if (patientUpdate.ID <= 0)
            {
                return BadRequest("Invalid patient ID.");
            }
            else if (ClsValidation.IsPhoneExist(patientUpdate.Phone))
            {
                return BadRequest($"Phone number {patientUpdate.Phone} already exists.");
            }
            else if (ClsValidation.IsEmailExist(patientUpdate.Email))
            {
                return BadRequest($"Email {patientUpdate.Email} already exists.");
            }
            else
            {
                ClsPatient existingPatient = ClsPatient.GetPatientByID(patientUpdate.ID);
                if (existingPatient == null)
                {
                    return NotFound($"Patient with ID {patientUpdate.ID} not found.");
                }
                existingPatient.DtoReadUpdate = patientUpdate;
                if (!existingPatient.Save())
                {
                    return BadRequest("Failed to update patient.");
                }
                return Ok(existingPatient.DtoReadUpdate);
            }
        }

        [HttpGet("GetPatientByPhoneNumber")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<DTOPatientReadUpdate> GetPatientByPhoneNumber(string Number)
        {
            if (Number.Length <= 11)
            {
                return BadRequest("Invalid patient ID.");
            }
            ClsPatient patient = ClsPatient.GetPatientByPhone(Number);
            if (patient == null)
            {
                return NotFound($"Patient with ID {Number} not found.");
            }
            return Ok(patient.DtoReadUpdate);
        }
    }
}
