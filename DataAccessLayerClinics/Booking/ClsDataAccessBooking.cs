using _3_DataAccessLayerClinics.Models;
using _DataAccessLayerClinics.Payment;
using _DataAccessLayerClinics.Validation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _DataAccessLayerClinics.Booking
{
    public class ClsDataAccessBooking
    {
        public static List<DTOBookingRead> GetallBooking()
        {
            using (ClinicDBContext context = new ClinicDBContext())
            {
                var res = context.Bookings.Include(b => b.Doctor).ThenInclude(d => d.Specialty).Include(b => b.Patient).Include(b => b.CreatedByNurse).Select(b =>
                    new DTOBookingRead(b.ID, b.Doctor.FirstName + " " + b.Doctor.LastName,
                        b.Doctor.Specialty.Name,
                        b.Patient.FirstName + " " + b.Patient.SecondName + " " + b.Patient.ThirdName + " " + b.Patient.LastName,
                       Convert.ToInt32(b.Patient.Age),
                        b.Patient.Gender,
                       Convert.ToInt32(b.DetectionCost),
                        b.CreatedAt,
                        b.BookingTime, b.BookingDate, b.IsPaid,
                        b.CreatedByNurse.FirstName)

                      ).ToList();

                return res;
            }
        }
        public static List<DTOBookingRead> GetallBookingWithDoctorbyID(int DoctorID)
        {
            using (ClinicDBContext context = new ClinicDBContext())
            {
                var res = context.Bookings.Include(b => b.Doctor).ThenInclude(d => d.Specialty).Include(b => b.Patient).Include(b => b.CreatedByNurse).Where(b => b.Doctor.ID == DoctorID).Select(b =>
                    new DTOBookingRead(b.ID, b.Doctor.FirstName + " " + b.Doctor.LastName,
                        b.Doctor.Specialty.Name,
                        b.Patient.FirstName + " " + b.Patient.SecondName + " " + b.Patient.ThirdName + " " + b.Patient.LastName,
                       Convert.ToInt32(b.Patient.Age),
                        b.Patient.Gender,
                       Convert.ToInt32(b.DetectionCost),
                        b.CreatedAt,
                        b.BookingTime, b.BookingDate, b.IsPaid,
                        b.CreatedByNurse.FirstName)

                      ).ToList();

                return res;
            }
        }
        public static DTOBookingRead GetBookByPatientPhoneNumber(string patientNumber)
        {
            using (ClinicDBContext context = new ClinicDBContext())
            {
                var res = context.Bookings.Include(b => b.Doctor).ThenInclude(d => d.Specialty).Include(b => b.Patient).Include(b => b.CreatedByNurse).Where(b => b.Patient.Phone == patientNumber).Select(b =>
                    new DTOBookingRead(b.ID, b.Doctor.FirstName + " " + b.Doctor.LastName,
                        b.Doctor.Specialty.Name,
                        b.Patient.FirstName + " " + b.Patient.SecondName + " " + b.Patient.ThirdName + " " + b.Patient.LastName,
                       Convert.ToInt32(b.Patient.Age),
                        b.Patient.Gender,
                       Convert.ToInt32(b.DetectionCost),
                        b.CreatedAt,
                        b.BookingTime, b.BookingDate, b.IsPaid,
                        b.CreatedByNurse.FirstName)

                      ).SingleOrDefault();

                return res;
            }
        }
        public static DTOBookingRead GetBookByID(int ID)
        {
            using (ClinicDBContext context = new ClinicDBContext())
            {
                var res = context.Bookings.Include(b => b.Doctor).ThenInclude(d => d.Specialty).Include(b => b.Patient).Include(b => b.CreatedByNurse).Where(b => b.ID == ID).Select(b =>
                    new DTOBookingRead(b.ID, b.Doctor.FirstName + " " + b.Doctor.LastName,
                        b.Doctor.Specialty.Name,
                        b.Patient.FirstName + " " + b.Patient.SecondName + " " + b.Patient.ThirdName + " " + b.Patient.LastName,
                       Convert.ToInt32(b.Patient.Age),
                        b.Patient.Gender,
                       Convert.ToInt32(b.DetectionCost),
                        b.CreatedAt,
                        b.BookingTime, b.BookingDate, b.IsPaid,
                        b.CreatedByNurse.FirstName)

                      ).SingleOrDefault();

                return res;
            }
        }
        public static DTOBookingUpdateContent GetBookWithoutdetailsByID(int ID)
        {
            using (ClinicDBContext context = new ClinicDBContext())
            {
                var res = context.Bookings.Where(b => b.ID == ID).Select(b =>
                    new DTOBookingUpdateContent(b.ID,Convert.ToInt32(b.DoctorID) ,Convert.ToInt32( b.PatientID), b.CreatedAt, b.BookingTime, b.BookingDate,Convert.ToInt32(b.CreatedByNurseID))).SingleOrDefault();
                return res;

            }
        }
        public static int AddBooking(DTOBookingAdd bookingAdd)
        {
            int bookingID = -1;
            try
            {
                using (ClinicDBContext ctx = new ClinicDBContext())
                {
                    var Book = new _3_DataAccessLayerClinics.Models.Booking()
                    {
                        DoctorID = bookingAdd.DoctorID,
                        PatientID = bookingAdd.PatientID,
                        CreatedAt = bookingAdd.CreatedAt,
                        BookingDate = bookingAdd.BookingDate,
                        BookingTime = bookingAdd.BookingTime,
                        IsPaid = bookingAdd.IsPaid,
                        CreatedByNurseID = bookingAdd.CreatedBy,
                        DetectionCost = bookingAdd.DetectionCost,


                    };

                    ctx.Add(Book);
                    ctx.SaveChanges();
                    bookingID = Book.ID;

                }
            } 
            catch(Exception)
            {
                return -1;
            }
            return bookingID;

        }
        public static bool UpdateBooking(DTOBookingUpdateContent bookingUpdate)
        {
            using (ClinicDBContext db = new ClinicDBContext())
            {
                var Book = db.Bookings.Find(bookingUpdate.ID);
                if (Book == null)
                    return false;
                Book.CreatedAt = bookingUpdate.CreatedAt;
                Book.DoctorID = bookingUpdate.DoctorID;
                Book.PatientID = bookingUpdate.PatientID;
                Book.CreatedByNurseID = bookingUpdate.CreatedBy;
                Book.BookingDate = bookingUpdate.BookingDate;
                Book.BookingTime = bookingUpdate.BookingTime;
                db.SaveChanges();
                return true;
            }
        }
        public static bool UpdateBookingTemporary(DTOBookUpatePayment bookingUpdate)
        {
            using (ClinicDBContext db = new ClinicDBContext())
            {
                var Book = db.Bookings.Find(bookingUpdate.BookingID);
                if (Book == null)
                    return false;
                Book.IsPaid = bookingUpdate.ispaid;
                Book.DetectionCost = bookingUpdate.DetectionCost;
                db.SaveChanges();

                return true;
            }
        }
       
        public static bool DeleteBooking(int ID)
        {
            using (ClinicDBContext db = new ClinicDBContext())
            {
                var Book = db.Bookings.Find(ID);
                if (Book == null)
                    return false;
                _DataAccessLayerClinics.Models.BookingDeletes book = new _DataAccessLayerClinics.Models.BookingDeletes()
                {
                    BookingID = Book.ID,
                    BookingTime = Book.BookingTime,
                    BookingDate = Book.BookingDate,
                    DoctorID = Book.DoctorID,
                    PatientID = Book.PatientID,
                    DetectionCost = Book.DetectionCost,
                    DateDelete = ClsDataAccessValidation.ToDateOnly(DateTime.Now),
                    BookingCreateAt = Book.CreatedAt,
                    IsPaid = Book.IsPaid,
                    CreatedByNurseID = Book.CreatedByNurseID,
                    Fine = Convert.ToInt32(Book.DetectionCost) / 2

                };
                db.BookingsDeletes.Add(book);
                db.SaveChanges();
                db.Bookings.Remove(Book);
                db.SaveChanges();
                return true;
            }
        }
        public static int GetMonthlyRevenueforDoctor(int DoctorID,DateOnly Datetoday)
        {
            DateOnly DateBeforeMonth=new DateOnly(Datetoday.Year, Datetoday.Month-1, 1);
            using (ClinicDBContext db = new ClinicDBContext())
            {
                var Sum=db.Bookings.Where(b => b.DoctorID == DoctorID && b.BookingDate.Year == Datetoday.Year && b.BookingDate.Month < Datetoday.Month&&b.BookingDate>=DateBeforeMonth).Sum(b => b.DetectionCost);
                return Convert.ToInt32(Sum);
            }
        }


    }
}
