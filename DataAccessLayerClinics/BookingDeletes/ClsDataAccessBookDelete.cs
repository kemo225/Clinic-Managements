using _3_DataAccessLayerClinics.Models;
using _DataAccessLayerClinics.Booking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _DataAccessLayerClinics.BookingDeletes
{
    public class ClsDataAccessBookDelete
{
        public static List<DTOBookingDeletesRead>getAllFines()
        

            {
                using (ClinicDBContext context = new ClinicDBContext())
                {
                var res = context.BookingsDeletes.Select(b => new DTOBookingDeletesRead(b.ID, b.BookingID, Convert.ToInt32(b.DoctorID), Convert.ToInt32(b.PatientID), Convert.ToInt32(b.DetectionCost), b.IsPaid, b.BookingCreateAt, b.BookingTime, b.BookingDate, Convert.ToInt32(b.CreatedByNurseID), b.Fine, b.DateDelete)).ToList();

                         
                    return res;
                }
            
        }
}
}
