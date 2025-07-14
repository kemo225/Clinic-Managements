using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _DataAccessLayerClinics.BookingDeletes
{
    public class DTOBookingDeletesRead
    {
        public int ID {  get; set; }
        public int BookingId { get; set; }
        public int DoctorID { get; set; }
        public int PatientID { get; set; }
        public int DetectionCost { get; set; }
        public bool IsPaid { get; set; }
        public DateOnly CreatedAt { get; set; }
        public TimeOnly BookingTime { get; set; }
        public DateOnly BookingDate { get; set; }
        public int CreatedBy { get; set; }
        public DateOnly DateDelete { get; set; }    
        public int Fine {  get; set; }
        public DTOBookingDeletesRead(int ID,int BookingId, int DoctorID, int PatientID, int DetectionCost, bool IsPaid, DateOnly CreatedAt, TimeOnly BookingTime, DateOnly BookingDate, int CreatedBy,int Fine,DateOnly DateDelete)
        {
            this.ID=ID;
            this.DetectionCost = DetectionCost;
            this.CreatedAt = CreatedAt;
            this.BookingTime = BookingTime;
            this.BookingDate = BookingDate;
            this.CreatedBy = CreatedBy;
            this.IsPaid = IsPaid;
            this.DoctorID = DoctorID;
            this.PatientID = PatientID;
            this.DateDelete = DateDelete;
            this.BookingId = BookingId;
            this.Fine = Fine;

        }
    }
}
