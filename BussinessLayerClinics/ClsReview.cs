using _DataAccessLayerClinics.Booking;
using _DataAccessLayerClinics.Review;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _BussinessLayerClinics
{
    public class ClsReview
{
        public int ID { get; set; }
        public int PatientID {  get; set; }
        public string PatientName { get; set; }
        public int Age { get; set; }
        public string Notes { get; set; }
        public int DoctorID {  get; set; }
        public string DoctorName { get; set; }
        public string specialty { get; set; }
        public DateTime ReviewDate { get; set; }
        public DateOnly BookingDate { get; set; }
        public TimeOnly BookingTime { get; set; }
        public int BookingID {  get; set; }
        public DToReviewUpdatee dtoReviewUpdate
        {
            get
            {
                return new DToReviewUpdatee(this.ID,this.BookingID,this.PatientID,this.Notes,this.ReviewDate,this.DoctorID);
            }
            set
            {
                this.ID= value.ID;  
                this.BookingID= value.BookingID;
                this.PatientID= value.PatientID;
                this.Notes= value.Notes;
                this.ReviewDate= value.ReviewDate;
                this.DoctorID= value.DoctorID;
            }
        }
        public DTOReviewAdd dtoReviewAdd
        {
            get
            {
                return new DTOReviewAdd(this.BookingID, this.PatientID, this.Notes, this.ReviewDate, this.DoctorID);
            }
            set
            {
                this.BookingID = value.BookingID;
                this.PatientID = value.PatientID;
                this.Notes = value.Notes;
                this.ReviewDate = value.ReviewDate;
                this.DoctorID = value.DoctorID;
            }
        }
        public DTOReviewRead dtoReviewRead
        {
            get
            {
                return new DTOReviewRead(this.ID, this.PatientName, this.Age, this.Notes, this.DoctorName, this.specialty, this.ReviewDate, this.BookingDate, this.BookingTime);
            }
            set
            {
                this.ID= value.ID;
                this.PatientName = value.PatientName;
                this.Age= value.Age;
                this.Notes= value.Notes;
                this.ReviewDate= value.ReviewDate;
                this.DoctorName= value.DoctorName;
                this.BookingTime= value.BookingTime;
                this.specialty=value.specialty;
                this.BookingDate= value.BookingDate;
                

            }
        }
        public enum enMode { update,add}
        public enMode Mode { get;set;}
        public static List<DTOReviewRead> GetAllReviews()
        {
            return ClsDataAccessReview.GetallReviews();
        }
        public ClsReview(DTOReviewRead dtoReviewRead, enMode Mode)
        {
            this.dtoReviewRead= dtoReviewRead;
            this.Mode= Mode;
        }
        public ClsReview(DTOReviewAdd dtoreviewAdd, enMode Mode)
        {
            this.dtoReviewAdd = dtoreviewAdd;
            this.Mode = Mode;
        }
        public static bool DeleteReviewById(int Id)
        {
            return ClsDataAccessReview.DeleteReview(Id);
        }
        private bool UpdateReview()
        {
            return ClsDataAccessReview.UpdateReview(this.dtoReviewUpdate);
        }
        private bool addReview()
        {
           this.ID= ClsDataAccessReview.AddReview(this.dtoReviewAdd);
            return (this.ID>0);
        }
        public static ClsReview GetReviewByPatientID(int Id)
        {
            DTOReviewRead dtoReviewRead = ClsDataAccessReview.GetReviewByPatientID(Id);
            if (dtoReviewRead == null)
            {
                return null; // Review not found
            }
            return new ClsReview(dtoReviewRead, enMode.update);
        }

        public bool Save()
        {
            switch
                (this.Mode)
            {
                case enMode.update:
                    return UpdateReview();
                case enMode.add:
                    this.Mode = enMode.update;
                    return addReview();
                default:
                    return false; // Invalid mode
            }







        }
    }
}
