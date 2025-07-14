using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _DataAccessLayerClinics.Booking
{
    public class DTOBookingAdd
{
        public int DoctorID { get; set; }
        public int PatientID { get; set; }
        public int DetectionCost { get; set; }
        public bool IsPaid { get; set; }
        public DateOnly CreatedAt { get; set; }
        public TimeOnly BookingTime { get; set; }
        public DateOnly BookingDate { get; set; }
        public int CreatedBy { get; set; }
        public DTOBookingAdd(int DoctorID, int PatientID, int DetectionCost,bool IsPaid, DateOnly CreatedAt, TimeOnly BookingTime, DateOnly BookingDate, int CreatedBy)
        {

            this.DetectionCost = DetectionCost;
            this.CreatedAt = CreatedAt;
            this.BookingTime = BookingTime;
            this.BookingDate = BookingDate;
            this.CreatedBy = CreatedBy;
            this.IsPaid = IsPaid;
            this.DoctorID = DoctorID;
            this.PatientID = PatientID; 

        }
    }
}
