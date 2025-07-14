using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _DataAccessLayerClinics.Models
{
    public class BookingDeletes
{
        public int ID { get; set; }
        public int BookingID { get; set; }

        public DateOnly BookingDate { get; set; }

        public TimeOnly BookingTime { get; set; }

        public bool IsPaid { get; set; }

        public decimal? DetectionCost { get; set; }

        public int? PatientID { get; set; }

        public int? DoctorID { get; set; }

        public int? CreatedByNurseID { get; set; }

        public DateOnly BookingCreateAt { get; set; }
        public DateOnly DateDelete { get; set; }
        public int Fine {  get; set; }
    }
}
