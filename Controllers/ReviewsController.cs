using _BussinessLayerClinics;
using _BussinessLayerClinics.Global;
using _DataAccessLayerClinics.Review;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _ClinicsManaegment.Controllers
{
    [Route("api/[controller]")]
[ApiController]
    [Authorize]

    public class ReviewsController : ControllerBase
{
        [HttpGet("GetAllReviews")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]

        public ActionResult<IEnumerable<DTOReviewRead>> GetAllReviews()
        {
            var Res=ClsReview.GetAllReviews();
            if (Res == null || Res.Count == 0)
            {
                return NotFound("No reviews found.");
            }
            return Ok(Res);
        }
        [HttpGet("GetReviewByPatientIDandDoctorID/{PatientID}/{DoctorID}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]

        public ActionResult<DTOReviewRead> GetReviewByPatientIDandDoctorID(int PatientID,int DoctorID)
        {
            if (PatientID <= 0)
            {
                return BadRequest("Invalid patient ID.");
            }
            var review = ClsReview.GetReviewByPatientIDDoctorID(PatientID, DoctorID);
            if (review == null)
            {
                return NotFound($"No review found for patient ID {PatientID}.");
            }
            else if (ClsGlobal.Currentuser.Id != DoctorID)
            {
                return BadRequest($"error,Doctor {ClsDoctor.GetDoctorReadByID(DoctorID).FirstName} Cannot See Review For Doctor {ClsGlobal.Currentuser.Name}");
            }
            return Ok(review);
        }

        [HttpPost("AddReview")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]

        public ActionResult<DToReviewUpdatee> AddReview([FromBody] DTOReviewAdd dtoReviewAdd)
        {
            if (dtoReviewAdd == null || dtoReviewAdd.BookingID <= 0 || dtoReviewAdd.PatientID <= 0 || string.IsNullOrWhiteSpace(dtoReviewAdd.Notes) || dtoReviewAdd.ReviewDate == default || dtoReviewAdd.DoctorID <= 0)
            {
                return BadRequest("Invalid review data.");
            }
            if (dtoReviewAdd == null)
            {
                return BadRequest("Invalid review data.");
            }
            ClsReview clsReview = new ClsReview(dtoReviewAdd, ClsReview.enMode.add);
            if (clsReview.Save())
            {
                return CreatedAtAction(nameof(GetReviewByPatientIDandDoctorID), new { id = clsReview.ID }, clsReview.dtoReviewUpdate);
            }
            return BadRequest("Failed to add review.");
        }
        [HttpPut("UpdateReview")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]

        public ActionResult<DToReviewUpdatee> UpdateReview([FromBody] DToReviewUpdatee dtoReviewUpdate)
        {
            if (dtoReviewUpdate == null || dtoReviewUpdate.ID <= 0 || dtoReviewUpdate.BookingID <= 0 || dtoReviewUpdate.PatientID <= 0 || string.IsNullOrWhiteSpace(dtoReviewUpdate.Notes) || dtoReviewUpdate.ReviewDate == default || dtoReviewUpdate.DoctorID <= 0)
            {
                return BadRequest("Invalid review data.");
            }
            ClsReview clsReview = ClsReview.GetReviewByPatientID(dtoReviewUpdate.PatientID,dtoReviewUpdate.DoctorID);
            if (clsReview == null)
            {
                return NotFound($"No review found for patient ID {dtoReviewUpdate.PatientID}.");
            }
            else if (ClsGlobal.Currentuser.Id != dtoReviewUpdate.DoctorID)
            {
                return BadRequest($"error,Doctor {ClsDoctor.GetDoctorReadByID(dtoReviewUpdate.DoctorID).FirstName} Cannot Update Review For Doctor {ClsGlobal.Currentuser.Name}");
            }

            if (!clsReview.Save())
            {
                return BadRequest("Error When Update Review");
            }
            return Ok(clsReview.dtoReviewUpdate);
        }
        [HttpDelete("DeleteReview/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]

        public ActionResult DeleteReview(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid review ID.");
            }
            if (ClsReview.DeleteReviewById(id))
            {
                return Ok("Deleted Successfuly"); // Successfully deleted
            }
            return NotFound($"No review found with ID {id}.");
        }
    }
}
