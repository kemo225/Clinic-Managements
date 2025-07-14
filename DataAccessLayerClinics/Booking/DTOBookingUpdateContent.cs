using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _DataAccessLayerClinics.Booking
{
    public class DTOBookingUpdateContent
{
        public int ID { get; set; } 
        public int DoctorID { get; set; }
        public int PatientID { get; set; }
        public DateOnly CreatedAt { get; set; }
        public TimeOnly BookingTime { get; set; }
        public DateOnly BookingDate { get; set; }
        public int CreatedBy { get; set; }
        public DTOBookingUpdateContent(int ID,int DoctorID, int PatientID, DateOnly CreatedAt, TimeOnly BookingTime, DateOnly Bookindate, int CreatedbyNurseID)
        {

            this.CreatedAt = CreatedAt;
            this.BookingTime = BookingTime;
            this.BookingDate = Bookindate;
            this.CreatedBy = CreatedbyNurseID;
            this.DoctorID = DoctorID;
            this.PatientID = PatientID;
        }
    }
}
