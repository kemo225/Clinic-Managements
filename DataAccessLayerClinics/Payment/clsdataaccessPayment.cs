using _3_DataAccessLayerClinics.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _DataAccessLayerClinics.Payment
{
    public class clsdataaccessPayment
{
        public static List<DtopaymentRead> GetallPayment()
        {
            using (ClinicDBContext context = new ClinicDBContext())
            {
                var res = context.Payments.Include(p=>p.Booking).ThenInclude(b=>b.Doctor).Include(p=>p.Booking).ThenInclude(b=>b.Patient).Select(p =>
                    new DtopaymentRead(p.ID, p.Booking.ID , Convert.ToInt32(p.DetectionCost), p.PaymentMethod, p.phoneNumberpaymentTo,Convert.ToBoolean( p.IsCash), 
                        p.Booking.Doctor.FirstName + " " + p.Booking.Doctor.LastName, 
                        p.Booking.Patient.FirstName + " " + p.Booking.Patient.SecondName + " " + p.Booking.Patient.ThirdName + " " + p.Booking.Patient.LastName,
                        p.Booking.CreatedByNurse.FirstName)).ToList();

                return res;
            }
        }

        public static DtopaymentRead GetallPaymentBookingbyID(int ID)
        {
            using (ClinicDBContext context = new ClinicDBContext())
            {
                var res = context.Payments.Include(p => p.Booking).ThenInclude(b => b.Doctor).Include(p => p.Booking).ThenInclude(b => b.Patient).Where(p => p.Booking.ID == ID).Select(p =>
                    new DtopaymentRead(p.ID, p.Booking.ID, Convert.ToInt32(p.DetectionCost), p.PaymentMethod, p.phoneNumberpaymentTo, Convert.ToBoolean(p.IsCash),
                        p.Booking.Doctor.FirstName + " " + p.Booking.Doctor.LastName,
                        p.Booking.Patient.FirstName + " " + p.Booking.Patient.SecondName + " " + p.Booking.Patient.ThirdName + " " + p.Booking.Patient.LastName,
                        p.Booking.CreatedByNurse.FirstName)).SingleOrDefault();
                return res;
            }
        }
        public static List<DtopaymentRead> GetallPaymentWithDoctorbyID(int DoctorID)
        {
            using (ClinicDBContext context = new ClinicDBContext())
            {
                var res = context.Payments.Include(p => p.Booking).ThenInclude(b => b.Doctor).Include(p => p.Booking).ThenInclude(b => b.Patient).Where(p => p.Booking.Doctor.ID == DoctorID).Select(p =>
                    new DtopaymentRead(p.ID, p.Booking.ID, Convert.ToInt32(p.DetectionCost), p.PaymentMethod, p.phoneNumberpaymentTo, Convert.ToBoolean(p.IsCash),
                        p.Booking.Doctor.FirstName + " " + p.Booking.Doctor.LastName,
                        p.Booking.Patient.FirstName + " " + p.Booking.Patient.SecondName + " " + p.Booking.Patient.ThirdName + " " + p.Booking.Patient.LastName,
                        p.Booking.CreatedByNurse.FirstName)).ToList();
                return res;
            }
        }

        public static int AddPayment(DTOPaymentAdd payment)
        {
            using (ClinicDBContext context = new ClinicDBContext())
            {
                var newPayment = new _3_DataAccessLayerClinics.Models.Payment
                {
                    BookingID = payment.BookingID,
                    DetectionCost = payment.DetectionCost,
                    PaymentMethod = payment.PaymentMethod,
                    phoneNumberpaymentTo = payment.phoneNumberpaymentTo,
                    IsCash = payment.IsCash
                };
                context.Payments.Add(newPayment);
                context.SaveChanges();
                return newPayment.ID;
            }
        }

        public static DtopaymentRead GetPaymentByID(int ID)
        {
            using (ClinicDBContext context = new ClinicDBContext())
            {
                var res = context.Payments.Include(p => p.Booking).ThenInclude(b => b.Doctor).Include(p => p.Booking).ThenInclude(b => b.Patient).Where(p => p.ID == ID).Select(p =>
                    new DtopaymentRead(p.ID, p.Booking.ID, Convert.ToInt32(p.DetectionCost), p.PaymentMethod, p.phoneNumberpaymentTo, Convert.ToBoolean(p.IsCash),
                        p.Booking.Doctor.FirstName + " " + p.Booking.Doctor.LastName,
                        p.Booking.Patient.FirstName + " " + p.Booking.Patient.SecondName + " " + p.Booking.Patient.ThirdName + " " + p.Booking.Patient.LastName,
                        p.Booking.CreatedByNurse.FirstName)).SingleOrDefault();
                return res;
            }
        }
        public static bool deletePayment(int ID)
        {
            using (ClinicDBContext context = new ClinicDBContext())
            {
                var payment = context.Payments.Find(ID);
                if (payment == null)
                {
                    return false; // Payment not found
                }
                if(payment.BookingID==null)
                {
                    return false; // Cannot delete payment without a booking
                }
                context.Payments.Remove(payment);
                context.SaveChanges();
                return true; // Payment deleted successfully
            }
        }
 
        public static bool UpdatePayment(DTOPaymentUpdate paymentUpdate)
        {
            using (ClinicDBContext context = new ClinicDBContext())
            {
                var payment = context.Payments.Find(paymentUpdate.ID);
                if (payment == null)
                {
                    return false; // Payment not found
                }
                payment.DetectionCost = paymentUpdate.DetectionCost;
                payment.PaymentMethod = paymentUpdate.PaymentMethod;
                payment.phoneNumberpaymentTo = paymentUpdate.phoneNumberpaymentTo;
                payment.IsCash = paymentUpdate.IsCash;
                context.SaveChanges();
                return true; // Payment updated successfully
            }
        }

    }
}
