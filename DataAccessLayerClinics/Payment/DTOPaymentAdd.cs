using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _DataAccessLayerClinics.Payment
{
    public class DTOPaymentAdd
{
        public int BookingID { get; set; }
        public int DetectionCost { get; set; }
        public string PaymentMethod { get; set; }
        public string phoneNumberpaymentTo { get; set; }
        public bool IsCash { get; set; }
        public DTOPaymentAdd(int bookingID, int detectionCost, string paymentMethod, string phoneNumberpaymentTo, bool isCash)
        {
            BookingID = bookingID;
            DetectionCost = detectionCost;
            PaymentMethod = paymentMethod;
            this.phoneNumberpaymentTo = phoneNumberpaymentTo;
            IsCash = isCash;
        }
    }
}
