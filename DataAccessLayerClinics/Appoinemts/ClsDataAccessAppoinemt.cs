using _3_DataAccessLayerClinics.Models;
using _DataAccessLayerClinics.Booking;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _DataAccessLayerClinics.Appoinemts
{
    public class ClsDataAccessAppoinemt
    {
        public static bool Deleteappintment(int ID)
        {
            using (ClinicDBContext db = new ClinicDBContext())
            {
                var res = db.DoctorSchedules.Find(ID);
                if (res == null)
                    return false;
                db.DoctorSchedules.Remove(res);
                db.SaveChanges();


                return true;
            }
        }

        public static int AddAppoinment(DToAddAppoinment dToAddAppoinment)
        {
            using (ClinicDBContext db = new ClinicDBContext())
            {


                var res = new _3_DataAccessLayerClinics.Models.DoctorSchedule
                {
                    StartTime = dToAddAppoinment.StartTime,
                    EndTime = dToAddAppoinment.EndTime,
                    DayOfWeek=dToAddAppoinment.Day

                };

                db.Add(res);
                db.SaveChanges();
                return res.ID;
            }



        }

        public static DTOAppointmentRead GetAppointmentById(int ID)
        {
            using (ClinicDBContext context = new ClinicDBContext())
            {
                var res = context.DoctorSchedules.Find(ID);
                if (res == null)
                    return null;



                return new DTOAppointmentRead(res.ID,res.StartTime,res.EndTime,res.DayOfWeek);
            }
        }
    }
}
