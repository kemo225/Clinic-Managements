using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _DataAccessLayerClinics.Payment
{
    public class DtopaymentRead
{
        public int ID { get; set; }
        public int BookingID { get; set; }
        public string DoctorName { get; set; }

        public string PatientName { get; set; }
        public int DetectionCost { get; set; }

        public string PaymentMethod { get; set; }
        public string phoneNumberpaymentTo { get; set; }

        public bool IsCash { get; set; }
        public string CreatedBy { get; set; }
        public DtopaymentRead(int id, int bookingID, int detectionCost, string paymentMethod, string phoneNumberpaymentTo, bool isCash, string doctorName, string patientName, string createdBy)
        {
            ID = id;
            BookingID = bookingID;
            DetectionCost = detectionCost;
            PaymentMethod = paymentMethod;
            this.phoneNumberpaymentTo = phoneNumberpaymentTo;
            IsCash = isCash;
            DoctorName = doctorName;
            PatientName = patientName;
            CreatedBy = createdBy;
        }

    }
}
