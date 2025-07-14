using _3_DataAccessLayerClinics.Models;
using _BussinessLayerClinics;
using _BussinessLayerClinics.Global;
using _DataAccessLayerClinics.Booking;
using _DataAccessLayerClinics.Nurse;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;



namespace _ClinicsManaegment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class BookingsController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<DTOBookingRead>> GetAllBookings()
        {
            var bookings = ClsBooking.GetAllBookings();
            if (bookings == null || bookings.Count == 0)
            {
                return NotFound("No bookings found.");
            }
            return Ok(bookings);
        }
        [HttpGet("GetBookingForDoctorID/{doctorId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public ActionResult<IEnumerable<DTOBookingRead>> GetBookingByDoctorID(int doctorId)
        {
            if (doctorId <= 0)
            {
                return BadRequest("Invalid doctor ID provided.");
            }
            var bookings = ClsBooking.GetallBookingWithDoctorbyID(doctorId);
            if (bookings == null || bookings.Count == 0)
            {
                return NotFound($"No bookings found for doctor with ID {doctorId}.");
            }
            return Ok(bookings);
        }
        [HttpGet("GetBookingByPatientPhoneNumber/{patientNumber}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public ActionResult<DTOBookingRead> GetBookingByPatientPhoneNumber(string patientNumber)
        {
            var booking = ClsBooking.getBookingByPatientPhoneNumber(patientNumber);
            if (booking == null)
            {
                return NotFound($"No booking found for patient with phone number {patientNumber}.");
            }
            return Ok(booking.dtoBookingRead);
        }
        [HttpGet("GetbookingbyID/{id}", Name = "GetBookinGByID")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<DTOBookingRead> GetBookingByID(int id)
        {
            var booking = ClsBooking.GetBookByID(id);
            if (booking == null)
            {
                return NotFound($"No booking found with ID {id}.");
            }
            return Ok(booking.dtoBookingRead);
        }
        [HttpPost("AddBooking")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public ActionResult<DTOBookingRead> AddBooking(DTOBookingAdd bookingAdd)
        {
            if (bookingAdd == null)
            {
                return BadRequest("Booking data is required.");
            }
            else if(!ClsValidation.IsNurseExist(bookingAdd.CreatedBy))
            {
                return BadRequest($"Nurse with ID {bookingAdd.CreatedBy} does not exist.");
            }
            else if (!ClsValidation.IsDoctorExist(bookingAdd.DoctorID))
            {
                return BadRequest($"Doctor with ID {bookingAdd.DoctorID} does not exist.");
            }
            else if (!ClsValidation.IsPatientExist(bookingAdd.PatientID))
            {
                return BadRequest($"Patient with ID {bookingAdd.PatientID} does not exist.");
            }
            else if (!ClsValidation.IsDateValid(bookingAdd.BookingDate))
            {
                return BadRequest("Date Is Necessary in Future");
            }
            else if (!ClsValidation.IsTimeValid(bookingAdd.BookingTime, bookingAdd.DoctorID))
            {
                return BadRequest($"There is not Appointment for Doctor in This Time {bookingAdd.BookingTime}");
            }
            else if (ClsValidation.IsDoctorAvailinTime(bookingAdd.BookingTime, bookingAdd.DoctorID, bookingAdd.BookingDate) == false)
            {
                return BadRequest("Doctor Is Not Available At This Time");
            }
            else if (ClsValidation.IsPatientHasActiveBooking(bookingAdd.PatientID, bookingAdd.DoctorID))
            {
                return BadRequest("Patient Already Has Active Booking With This Doctor");
            }
            else if(!ClsValidation.IsNurseExist(bookingAdd.CreatedBy))
            {
                return BadRequest($"Nurse with ID {bookingAdd.CreatedBy} does not exist.");
            }
            else if (ClsGlobal.Currentuser.Id==bookingAdd.CreatedBy)
            {
                DTONurseRead nurse=ClsNurse.GetDTONurseReadByID(bookingAdd.CreatedBy);
                return BadRequest($"Error,Login on System By {ClsGlobal.Currentuser.Name} and You Want Sign in System Created Booking by {nurse.FirstName + " " + nurse.LastName} does not exist.");
            }

            ClsBooking newBooking = new ClsBooking(bookingAdd, ClsBooking.enMode.Add);
            if (newBooking.Save())
            {
                var patient = ClsPatient.GetPatientByID(bookingAdd.PatientID);
                var Email=new EmailServices();
                Email.SendEmail(patient.Email, "Confirm Booking", $"Dear : {patient.FirstName}<br><br> Your Booking Is Confirm At {bookingAdd.BookingDate.ToString()} in {bookingAdd.BookingTime}");

                return CreatedAtRoute("GetBookinGByID", new { id = newBooking.ID }, ClsBooking.GetBookByID(newBooking.ID).dtoBookingRead);
            }
            return BadRequest("Failed to add booking.");



        }
        [HttpPut("UpdateBooking")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]

        public ActionResult<DTOBookingUpdateContent> UpdateBooking([FromBody]DTOBookingUpdateContent bookingUpdate)
        {
            if (bookingUpdate == null || bookingUpdate.ID <= 0)
            {
                return BadRequest("Invalid booking data provided.");
            }
            else if (!ClsValidation.IsNurseExist(bookingUpdate.CreatedBy))
            {
                return BadRequest($"Nurse with ID {bookingUpdate.CreatedBy} does not exist.");
            }
            else if (!ClsValidation.IsDoctorExist(bookingUpdate.DoctorID))
            {
                return BadRequest($"Doctor with ID {bookingUpdate.DoctorID} does not exist.");
            }
            else if (!ClsValidation.IsPatientExist(bookingUpdate.PatientID))
            {
                return BadRequest($"Patient with ID {bookingUpdate.PatientID} does not exist.");
            }
            else if (ClsValidation.IsDateValid(bookingUpdate.BookingDate))
            {
                return BadRequest("Date Is Necessary in Future");
            }
            else if (!ClsValidation.IsTimeValid(bookingUpdate.BookingTime, bookingUpdate.DoctorID))
            {
                return BadRequest($"There is not Appointment for Doctor in This Time");
            }
            else if (ClsValidation.IsDoctorAvailinTime(bookingUpdate.BookingTime, bookingUpdate.DoctorID, bookingUpdate.BookingDate) == false)
            {
                return BadRequest("Doctor Is Not Available At This Time");
            }
            else if (ClsValidation.IsPatientHasActiveBooking(bookingUpdate.PatientID, bookingUpdate.DoctorID))
            {
                return BadRequest("Patient Already Has Active Booking With This Doctor");
            }
            else if (!ClsValidation.IsNurseExist(bookingUpdate.CreatedBy))
            {
                return BadRequest($"Nurse with ID {bookingUpdate.CreatedBy} does not exist.");
            }

            ClsBooking existingBooking = ClsBooking.GetBookByID(bookingUpdate.ID);
            if (existingBooking == null)
            {
                return NotFound($"No booking found with ID {bookingUpdate.ID}.");
            }
            existingBooking.DTOBookingUpdate = bookingUpdate;
            if (existingBooking.Save())
            {
                return Ok(existingBooking.DTOBookingUpdate);
            }
            return BadRequest("Failed to update booking.");
        }
        [HttpPut("ConfirmBooking")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]

        public ActionResult<DTOBookingRead> UpdateBookingPayment([FromBody]DTOBookUpatePayment bookingUpdate)
        {
            if (bookingUpdate == null || bookingUpdate.BookingID <= 0)
            {
                return BadRequest("Invalid booking data provided.");
            }
            else if (!ClsValidation.IsBookingExist(bookingUpdate.BookingID))
            {
                return BadRequest($"Booking with ID {bookingUpdate.BookingID} does not exist.");
            }
            else if (bookingUpdate.ispaid)
            {
                return BadRequest("You Already Paid And Confirm Booking");
             }

            ClsBooking existingBooking = ClsBooking.GetBookByID(bookingUpdate.BookingID);
            if (existingBooking == null)
            {
                return NotFound($"No booking found with ID {bookingUpdate.BookingID}.");
            }
            existingBooking.DTOBookUpatePayment = bookingUpdate;
            if (ClsBooking.UpdateBookingPayment(bookingUpdate))
            {
                return Ok(ClsBooking.GetBookByID(bookingUpdate.BookingID).dtoBookingRead);
            }
            return BadRequest("Failed to update booking.");
        }
        [HttpDelete("DeleteBooking/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]

        public ActionResult DeleteBooking(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid booking ID provided.");
            }else if (!ClsValidation.IsBookingExist(id))
            {
                return NotFound($"Booking with ID {id} does not exist.");
            }
            else 
            {
                var patient = ClsPatient.GetPatientByID(ClsBooking.GetBookWithoutDetailsByID(id).PatientID);
                var Email = new EmailServices();
                Email.SendEmail(patient.Email, "Cancel Booking", $"Dear : {patient.FirstName} <br><br> Your Booking Is Canceled");
                ClsBooking.DeleteBookingById(id);
                return Ok($"Booking with ID {id} has been deleted successfully.");
            }
        }
    }
}
