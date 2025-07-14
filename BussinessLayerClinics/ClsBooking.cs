using _DataAccessLayerClinics.Booking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _BussinessLayerClinics
{
    public class ClsBooking
    {
        public int ID { get; set; }
        public string DoctorName { get; set; }
        public int DoctorID { get; set; }
        public int PatientID { get; set; }
        public int DetectionCost { get; set; }
        public DateOnly CreatedAt { get; set; }
        public TimeOnly BookingTime { get; set; }
        public DateOnly BookingDate { get; set; }
        public bool IsPaid { get; set; }
        public int CreatedBy { get; set; }
        public string Speciallity { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string CreatedNurse { get; set; }
        public string PaymentMethod { get; set; }
        public string phoneNumberpaymentTo { get; set; }
        public bool IsCash { get; set; }
        public DTOBookUpatePayment DTOBookUpatePayment
        {
            get
            {
                return new DTOBookUpatePayment(this.ID, this.IsPaid, this.DetectionCost);
            }
            set
            {
                this.ID = value.BookingID;
                this.IsPaid = value.ispaid;
                this.DetectionCost = value.DetectionCost;

            }
        }
        public DTOBookingRead dtoBookingRead
        {
            get
            {
                return new DTOBookingRead(this.ID, this.DoctorName, this.Speciallity, this.Name, this.Age, this.Gender, this.DetectionCost, this.CreatedAt, this.BookingTime, this.BookingDate, this.IsPaid, this.CreatedNurse);
            }
            set
            {
                this.ID = value.ID;
                this.DoctorName = value.DoctorName;
                this.Speciallity = value.Speciallity;
                this.Name = value.Name;
                this.Age = value.Age;
                this.Gender = value.Gender;
                this.DetectionCost = value.DetectionCost;
                this.CreatedAt = value.CreatedAt;
                this.BookingTime = value.BookingTime;
                this.BookingDate = value.BookingDate;
                this.CreatedNurse = value.CreatedNurse;
                this.IsPaid = value.IsPaid;


            }
        }

        public DTOBookingAdd dtbookAdd
        {
            get
            {
                return new DTOBookingAdd(this.DoctorID, this.PatientID, this.DetectionCost, this.IsPaid, this.CreatedAt, this.BookingTime, this.BookingDate, this.CreatedBy);
            }
            set
            {
                this.DoctorID = value.DoctorID;
                this.PatientID = value.PatientID;
                this.DetectionCost = value.DetectionCost;
                this.IsPaid = value.IsPaid;
                this.CreatedAt = value.CreatedAt;
                this.BookingTime = value.BookingTime;
                this.BookingDate = value.BookingDate;
                this.CreatedBy = value.CreatedBy;
            }
        }

        public DTOBookingUpdateContent DTOBookingUpdate
        {
            get
            {
                return new DTOBookingUpdateContent(this.ID, this.DoctorID, this.PatientID, this.CreatedAt, this.BookingTime, this.BookingDate, this.CreatedBy);
            }
            set
            {
                this.ID = value.ID;
                this.DoctorID = value.DoctorID;
                this.PatientID = value.PatientID;
                this.CreatedAt = value.CreatedAt;
                this.BookingTime = value.BookingTime;
                this.BookingDate = value.BookingDate;
                this.CreatedBy = value.CreatedBy;

            }
        }
        public enum enMode
        {
            Add,
            Update
        }
        public enMode Mode { get; set; }

        public ClsBooking(DTOBookingRead dTO, enMode mode)
        {
            this.dtoBookingRead = dTO;
            this.Mode = mode;

        }
        public ClsBooking(DTOBookingAdd dTOadd, enMode mode)
        {
            this.dtbookAdd = dTOadd;
            this.Mode = mode;

        }
        public static bool UpdateBookingPayment(DTOBookUpatePayment bookingUpdate)
        {
            return ClsDataAccessBooking.UpdateBookingTemporary(bookingUpdate);
        }

        public static List<DTOBookingRead> GetAllBookings()
        {
            return ClsDataAccessBooking.GetallBooking();
        }
        public static List<DTOBookingRead> GetallBookingWithDoctorbyID(int DoctorId)
        {
            return ClsDataAccessBooking.GetallBookingWithDoctorbyID(DoctorId);
        }
        public static DTOBookingRead GetBookByPatientNumber(string patientNumber)
        {
            return ClsDataAccessBooking.GetBookByPatientPhoneNumber(patientNumber);
        }
        public static ClsBooking GetBookByID(int ID)
        {
            DTOBookingRead booking = ClsDataAccessBooking.GetBookByID(ID);
            if (booking == null)
            {
                return null;
            }
            return new ClsBooking(booking, enMode.Update);


        }
        public static DTOBookingUpdateContent GetBookWithoutDetailsByID(int ID)
        {
            return ClsDataAccessBooking.GetBookWithoutdetailsByID(ID);
        }
        public static ClsBooking getBookingByPatientPhoneNumber(string patientNumber)
        {
            DTOBookingRead booking = ClsDataAccessBooking.GetBookByPatientPhoneNumber(patientNumber);
            if (booking == null)
            {
                return null;
            }
            return new ClsBooking(booking, enMode.Update);
        }
        private bool AddBooking()
        {
            this.ID = ClsDataAccessBooking.AddBooking(this.dtbookAdd);
            return (this.ID > 0);
        }
        private bool UpdateBooking()
        {
            return ClsDataAccessBooking.UpdateBooking(this.DTOBookingUpdate);
        }
        public bool Save()
        {
            switch
                (this.Mode)
            {
                case enMode.Update:
                    return UpdateBooking();
                case enMode.Add:
                    this.Mode = enMode.Update;
                    return AddBooking();
                default:
                    throw new Exception("Invalid Mode");
            }


        }
        public static bool DeleteBookingById(int Id)
        {
            return ClsDataAccessBooking.DeleteBooking(Id);
        }
        public static int GetMonthlyreVenueforDoctor(int DoctorID, DateOnly DateToday)
        {
            return ClsDataAccessBooking.GetMonthlyRevenueforDoctor(DoctorID, DateToday);
        }
    }
}
