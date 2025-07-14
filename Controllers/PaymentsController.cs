using _BussinessLayerClinics;
using _DataAccessLayerClinics.Payment;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _ClinicsManaegment.Controllers
{
    [Route("api/[controller]")]
[ApiController]
    [Authorize]

    public class PaymentsController : ControllerBase
{
        [HttpGet("GetAllPayments")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]

        public ActionResult<IEnumerable<DtopaymentRead>> GetAllPayments()
        {
            var payments =ClsPayment.GetAllPayments();
            if (payments == null || payments.Count == 0)
            {
                return NotFound("No payments found.");
            }
            return Ok(payments);
        }
        [HttpGet("GetPaymentByID/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]

        public ActionResult<DtopaymentRead> GetPaymentByID(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid payment ID.");
            }
            ClsPayment payment = ClsPayment.GetPaymentByID(id);
            if (payment == null)
            {
                return NotFound($"Payment with ID {id} not found.");
            }
            return Ok(payment.DtoPaymentread);
        }
        [HttpGet("GetAllPaymentsWithDoctorByID/{doctorId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]

        public ActionResult<IEnumerable<DtopaymentRead>> GetAllPaymentsWithDoctorByID(int doctorId)
        {
            if (doctorId <= 0)
            {
                return BadRequest("Invalid doctor ID.");
            }
            var payments = ClsPayment.GetAllPaymentsWithDoctorByID(doctorId);
            if (payments == null || payments.Count == 0)
            {
                return NotFound($"No payments found for doctor with ID {doctorId}.");
            }
            return Ok(payments);
        }
        [HttpPost("AddPayment")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<DtopaymentRead> AddPayment( DTOPaymentAdd payment)
        {
            if (payment == null)
            {
                return BadRequest("Payment data is required.");
            }
            ClsPayment clsPayment = new ClsPayment(payment, ClsPayment.enMode.add);
            if (clsPayment.Save())
            {
                return CreatedAtAction(nameof(GetPaymentByID), new { id = clsPayment.ID }, ClsPayment.GetPaymentByID(clsPayment.ID));
            }
            return BadRequest("Failed to add payment.");
        }
        [HttpPut("UpdatePayment")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]

        public ActionResult<DtopaymentRead> UpdatePayment([FromBody]DTOPaymentUpdate paymentUpdate)
        {
            if (paymentUpdate == null || paymentUpdate.ID <= 0)
            {
                return BadRequest("Invalid payment data.");
            }
            ClsPayment clsPayment = ClsPayment.GetPaymentByID(paymentUpdate.ID);
            if (clsPayment == null)
            {
                return NotFound($"Payment with ID {paymentUpdate.ID} not found.");
            }
            if (clsPayment.Save())
            {
                return Ok(clsPayment.DtoPaymentread);
            }
            return NotFound($"Payment with ID {paymentUpdate.ID} not found.");
        }
        [HttpDelete("DeletePayment/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]

        public ActionResult DeletePayment(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid payment ID.");
            }
            if (ClsPayment.DeletePayment(id))
            {
                return Ok(); // 204 No Content
            }
            return NotFound($"Payment with ID {id} not found.");
        }
        [HttpGet("GetPaymentByBookingID/{bookingId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]

        public ActionResult<DtopaymentRead> GetPaymentByBookingID(int bookingId)
        {
            if (bookingId <= 0)
            {
                return BadRequest("Invalid booking ID.");
            }
            DtopaymentRead payment = ClsPayment.GetPaymentByBookingID(bookingId);
            if (payment == null)
            {
                return NotFound($"Payment for booking with ID {bookingId} not found.");
            }
            return Ok(payment);
        }


    }
}
