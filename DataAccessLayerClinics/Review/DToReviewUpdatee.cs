using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _DataAccessLayerClinics.Review
{
    public class DToReviewUpdatee
{
        public int ID {  get; set; }
        public int BookingID { get; set; }

        public int PatientID { get; set; }

        public string Notes { get; set; }

        public DateTime ReviewDate { get; set; }

        public int DoctorID { get; set; }
   public     DToReviewUpdatee(int iD, int bookingID, int patientID, string notes, DateTime reviewDate, int doctorID)
        {
            ID = iD;
            BookingID = bookingID;
            PatientID = patientID;
            Notes = notes;
            ReviewDate = reviewDate;
            DoctorID = doctorID;
        }
    }
}
