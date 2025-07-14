using _3_DataAccessLayerClinics.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _DataAccessLayerClinics.Review
{
    public class ClsDataAccessReview
    {
        public static List<DTOReviewRead> GetallReviews()
        {
            using (ClinicDBContext context = new ClinicDBContext())

            {
                var res = context.Reviews.Include(R => R.Doctor).
                    ThenInclude(R => R.Specialty).
                    Include(R => R.Patient).Include(R => R.Booking).Select(R => new DTOReviewRead(R.ID,
                    R.Patient.FirstName + " " + R.Patient.SecondName + " " + R.Patient.ThirdName,
                    Convert.ToInt32(R.Patient.Age), R.Notes, R.Doctor.FirstName + " " + R.Doctor.SecondName, R.Doctor.Specialty.Name,Convert.ToDateTime(R.ReviewDate), R.Booking.BookingDate,
                    R.Booking.BookingTime
                     )).ToList();
                return res;
            }
        }
        public static DTOReviewRead GetReviewByPatientID(int ID)
        {
            using (ClinicDBContext context = new ClinicDBContext())

            {
                var res = context.Reviews.Include(R => R.Doctor).
                    ThenInclude(R => R.Specialty).
                    Include(R => R.Patient).Include(R => R.Booking).Where(R => R.PatientID == ID).Select(R => new DTOReviewRead(R.ID,
                    R.Patient.FirstName + " " + R.Patient.SecondName + " " + R.Patient.ThirdName,
                   Convert.ToInt32(R.Patient.Age), R.Notes, R.Doctor.FirstName + " " + R.Doctor.SecondName, R.Doctor.Specialty.Name, Convert.ToDateTime(R.ReviewDate), R.Booking.BookingDate,
                    R.Booking.BookingTime
                     )).SingleOrDefault();
                return res;
            }
        }
        public static DTOReviewRead GetReviewByPatientPhoneNumber(string PhoneNumber)
        {
            using (ClinicDBContext context = new ClinicDBContext())

            {
                var res = context.Reviews.Include(R => R.Doctor).
                    ThenInclude(R => R.Specialty).
                    Include(R => R.Patient).Include(R => R.Booking).Where(R => R.Patient.Phone == PhoneNumber).Select(R => new DTOReviewRead(R.ID,
                    R.Patient.FirstName + " " + R.Patient.SecondName + " " + R.Patient.ThirdName,
                   Convert.ToInt32(R.Patient.Age), R.Notes, R.Doctor.FirstName + " " + R.Doctor.SecondName, R.Doctor.Specialty.Name, Convert.ToDateTime(R.ReviewDate), R.Booking.BookingDate,
                    R.Booking.BookingTime
                     )).SingleOrDefault();
                return res;
            }
        }

        public static bool UpdateReview(DToReviewUpdatee dtoRevewUp)
        {
            using (ClinicDBContext ctx = new ClinicDBContext())
            {
                var res = ctx.Reviews.Find(dtoRevewUp.ID);
                if (res == null)
                    return false;
                res.Notes = dtoRevewUp.Notes;
                res.ReviewDate = dtoRevewUp.ReviewDate;
                res.BookingID = dtoRevewUp.BookingID;
                res.DoctorID = dtoRevewUp.DoctorID;
                res.PatientID = dtoRevewUp.PatientID;
                ctx.SaveChanges();
                return true;
            }
        }

        public static int AddReview(DTOReviewAdd ReviewAdd)
        {
            using (ClinicDBContext db = new ClinicDBContext())
            {
                var res = new _3_DataAccessLayerClinics.Models.Review()
                {
                    PatientID = ReviewAdd.PatientID,
                    ReviewDate = ReviewAdd.ReviewDate,
                    BookingID = ReviewAdd.BookingID,
                    Notes = ReviewAdd.Notes,
                    DoctorID = ReviewAdd.DoctorID,

                };
                db.SaveChanges();
                return res.ID;

            }
        }

        public static bool DeleteReview(int id)
        {
            using (ClinicDBContext context = new ClinicDBContext())
            {
                var review = context.Reviews.Find(id);
                if (review != null)
                {
                    context.Reviews.Remove(review);
                    context.SaveChanges();
                    return true;
                }
                return false;
            }
        }

    }
}
