using _3_DataAccessLayerClinics.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _DataAccessLayerClinics.ScheduleDoctorMapping
{
    public class ClsDataAccessScheduleDoctorMapping
{
        public static List<DTOScheduleDoctorRead> GetAllScheduleDoctorMappings()
        {
            using (ClinicDBContext context = new ClinicDBContext())
            {
                var res = context.ScheduleDoctorMappings.Include(s => s.Doctor).ThenInclude(d=>d.Specialty).Include(s => s.DoctorSchedule)
                    .Select(s => new DTOScheduleDoctorRead
                    (
                         s.ID,
                        s.Doctor.FirstName+" "+s.Doctor.LastName,
                        s.Doctor.Specialty.Name,
                        TimeOnly.FromDateTime(s.DoctorSchedule.StartTime),
                        TimeOnly.FromDateTime(s.DoctorSchedule.EndTime),
                        Convert.ToInt32(s.DetectionCost),s.DoctorSchedule.DayOfWeek
                         )).ToList();
                return res;
            }
        }
        public static DTOScheduleDoctorRead GetScheduleDoctorMappingByID(int ID)
        {
            using (ClinicDBContext context = new ClinicDBContext())
            {
                var res = context.ScheduleDoctorMappings.Include(s => s.Doctor).ThenInclude(d => d.Specialty).Include(s => s.DoctorSchedule)
                    .Where(s => s.ID == ID)
                    .Select(s => new DTOScheduleDoctorRead
                    (
                        s.ID,
                        s.Doctor.FirstName + " " + s.Doctor.LastName,
                        s.Doctor.Specialty.Name,
                       TimeOnly.FromDateTime( s.DoctorSchedule.StartTime),
                        TimeOnly.FromDateTime(s.DoctorSchedule.EndTime) ,
                        Convert.ToInt32(s.DetectionCost), s.DoctorSchedule.DayOfWeek
                    )).SingleOrDefault();
                return res;
            }
        }
        public static List<DTOScheduleDoctorRead> GetScheduleDoctorMappingByDoctorID(int DoctorID)
        {
            using (ClinicDBContext context = new ClinicDBContext())
            {
                var res = context.ScheduleDoctorMappings.Include(s => s.Doctor).ThenInclude(d => d.Specialty).Include(s => s.DoctorSchedule)
                    .Where(s => s.DoctorID == DoctorID)
                    .Select(s => new DTOScheduleDoctorRead
                    (
                        s.ID,
                        s.Doctor.FirstName + " " + s.Doctor.LastName,
                        s.Doctor.Specialty.Name,
                        TimeOnly.FromDateTime(s.DoctorSchedule.StartTime),
                        TimeOnly.FromDateTime(s.DoctorSchedule.EndTime),
                        Convert.ToInt32(s.DetectionCost), s.DoctorSchedule.DayOfWeek
                    )).ToList();
                return res;
            }
        }
        public static DTOScheduleDoctorRead GetScheduleDoctorMappingByDoctorNumber(string PhoneNumber)
        {
            using (ClinicDBContext context = new ClinicDBContext())
            {
                var res = context.ScheduleDoctorMappings.Include(s => s.Doctor).ThenInclude(d => d.Specialty).Include(s => s.DoctorSchedule)
                    .Where(s => s.Doctor.Phone == PhoneNumber)
                    .Select(s => new DTOScheduleDoctorRead
                    (
                        s.ID,
                        s.Doctor.FirstName + " " + s.Doctor.LastName,
                        s.Doctor.Specialty.Name,
                        TimeOnly.FromDateTime(s.DoctorSchedule.StartTime),
                        TimeOnly.FromDateTime(s.DoctorSchedule.EndTime),
                        Convert.ToInt32(s.DetectionCost), s.DoctorSchedule.DayOfWeek
                    )).SingleOrDefault();
                return res;
            }
        }
        public static bool UpdateScheduleDoctorMapping(DTOScheduleDoctorUpdate dtoScheduleDoctor)
        {
            using (ClinicDBContext context = new ClinicDBContext())
            {
                var scheduleDoctor = context.ScheduleDoctorMappings.Find(dtoScheduleDoctor.ID);
                if (scheduleDoctor == null)
                {
                    return false; // ScheduleDoctorMapping not found
                }
                scheduleDoctor.DetectionCost = dtoScheduleDoctor.DetectionCost;

                context.SaveChanges();
                return true;
            }
        }
        public static int AddScheduleDoctorMapping(DTOScheduleDoctorAdd dtoScheduleDoctor)
        {
            using (ClinicDBContext context = new ClinicDBContext())
            {
                var scheduleDoctor = new _3_DataAccessLayerClinics.Models.ScheduleDoctorMapping()
                {
                    DoctorID = dtoScheduleDoctor.DoctorID,
                    DoctorScheduleID = dtoScheduleDoctor.AppointmentID,
                    DetectionCost = dtoScheduleDoctor.DetectionCost
                };
                context.ScheduleDoctorMappings.Add(scheduleDoctor);
                context.SaveChanges();
                return scheduleDoctor.ID; // ScheduleDoctorMapping added successfully
            }
        }
        public static bool DeleteScheduleDoctorMapping(int id)
        {
            using (ClinicDBContext context = new ClinicDBContext())
            {
                var scheduleDoctor = context.ScheduleDoctorMappings.Find(id);
                if (scheduleDoctor == null)
                {
                    return false; // ScheduleDoctorMapping not found
                }
                context.ScheduleDoctorMappings.Remove(scheduleDoctor);
                context.SaveChanges();
                return true; // ScheduleDoctorMapping deleted successfully
            }
        }
    }
}
