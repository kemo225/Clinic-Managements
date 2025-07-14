using _DataAccessLayerClinics.BookingDeletes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _BussinessLayerClinics
{
    public class ClsFineBooking
{
        public static List<DTOBookingDeletesRead>GetAllFine()
        {
            return ClsDataAccessBookDelete.getAllFines();   
        }
}
}
