using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _DataAccessLayerClinics.Payment
{
    public class DTOPaymentUpdate
{
        public int ID { get; set; }
        public int BookingID { get; set; }
        public int DetectionCost { get; set; }
        public string PaymentMethod { get; set; }
        public string phoneNumberpaymentTo { get; set; }
        public bool IsCash { get; set; }
        public DTOPaymentUpdate(int ID,int bookingID, int detectionCost, string paymentMethod, string phoneNumberpaymentTo, bool isCash)
        {
            this.ID = ID;
            BookingID = bookingID;
            DetectionCost = detectionCost;
            PaymentMethod = paymentMethod;
            this.phoneNumberpaymentTo = phoneNumberpaymentTo;
            IsCash = isCash;
        }
    }
}
