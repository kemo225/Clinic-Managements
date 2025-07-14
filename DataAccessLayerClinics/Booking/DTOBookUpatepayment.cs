using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _DataAccessLayerClinics.Booking
{
    public class DTOBookUpatePayment
{
        public int BookingID { get; set; }
        public bool ispaid { get; set; }
        public int DetectionCost { get; set; }

        public DTOBookUpatePayment(int bookingID, bool ispaid, int detectionCost)
        {
            BookingID = bookingID;
            this.ispaid = ispaid;
          this.DetectionCost = detectionCost;

        }
    }
}
