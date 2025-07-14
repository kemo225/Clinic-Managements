using _3_DataAccessLayerClinics.Models;
using _DataAccessLayerClinics.ScheduleDoctorMapping;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _DataAccessLayerClinics.Validation
{
    public static class ClsDataAccessValidation
    {
        public static bool IsNurseExits(int ID)
        {
            if (ID < 0)
                return false;
            using (ClinicDBContext db = new ClinicDBContext())
            {
                var res = db.Nurses.Find(ID);
                if (res == null)
                    return false;
                return true;

            }
        }
        public static bool IsPatientExits(int ID)
        {
            if (ID < 0)
                return false;
            using (ClinicDBContext db = new ClinicDBContext())
            {
                var res = db.Patients.Find(ID);
                if (res == null)
                    return false;
                return true;

            }
        }
        public static bool IsDoctorExist(int ID)
        {
            if (ID < 0)
                return false;
            using (ClinicDBContext db = new ClinicDBContext())
            {
                var res = db.Doctors.Find(ID);
                if (res == null)
                    return false;
                return true;

            }
        }
        public static bool IsBookingExist(int ID)
        {
            if (ID < 0)
                return false;
            using (ClinicDBContext db = new ClinicDBContext())
            {
                var res = db.Bookings.Find(ID);
                if (res == null)
                    return false;
                return true;

            }
        }
        public static bool IsBookingPaid(int ID)
        {
            if (ID < 0)
                return false;
            using (ClinicDBContext db = new ClinicDBContext())
            {
                var res = db.Bookings.Find(ID);
                if (res.IsPaid == false)
                    return false;
                return true;

            }
        }
        public static bool IsAppointmentExist(int ID)
        {
            if (ID < 0)
                return false;
            using (ClinicDBContext db = new ClinicDBContext())
            {
                var res = db.Bookings.Find(ID);
                if (res == null)
                    return false;
                return true;

            }
        }
        public static bool IsDateValidforBooking(DateOnly BookingDate)
        {

            DateTime dt = new DateTime(BookingDate.Year, BookingDate.Month, BookingDate.Day);

            using (ClinicDBContext db = new ClinicDBContext())
            {
                if (dt > DateTime.Now)
                    return true;

                return false;
            }
        }
        public static bool IsDoctorAvailinTime(TimeOnly BookingTime, int DoctorID, DateOnly BookingDate)
        {

            using (ClinicDBContext db = new ClinicDBContext())
            {
                var res = db.Bookings.Where(b => b.DoctorID == DoctorID && b.BookingDate == BookingDate && b.BookingTime == BookingTime);
                if (!res.Any())
                    return true;// 
                return false;
            }

        }
        public static bool IsTimeValid(TimeOnly BookingTime, int DoctorId)
        {
            using (ClinicDBContext db = new ClinicDBContext())
            { // Time Valid From Start to  End
                List<DTOScheduleDoctorRead> AppointmentsDoctor = ClsDataAccessScheduleDoctorMapping.GetScheduleDoctorMappingByDoctorID(DoctorId);
                foreach (var X in AppointmentsDoctor)
                {
                    if (BookingTime >= X.StartTime && BookingTime <= X.EndTime)
                        return true;
                }
                return false;
            }
        }
        public static DateTime ToDateTime(DateOnly date)
        {
            return new DateTime(date.Year, date.Month, date.Day);
        }
        public static DateOnly ToDateOnly(DateTime date)
        {
            return new DateOnly(date.Year, date.Month, date.Day);
        }
        public static bool IsPatientHasBookingActive(int PatientId, int doctorID)
        {
          DateOnly  datime = ToDateOnly(DateTime.Now);
            if (PatientId < 0)
                return false;
            using (ClinicDBContext db = new ClinicDBContext())
            {
                var res = db.Bookings.Where(b => b.PatientID == PatientId && b.DoctorID == doctorID && b.BookingDate > datime);
                if (res.Any())
                    return true;
                return false;
            }
        }
        public static bool ISEmailExistForDoctor(string Email, int ID = -1)
        {
            if (string.IsNullOrEmpty(Email))
                return false;
            using (ClinicDBContext db = new ClinicDBContext())
            {
                var res = db.Doctors.Where(n => n.Email == Email && n.ID != ID);
                if (res.Any())
                    return true;
                return false;
            }
        }
        public static bool ISEmailExistForPatient(string Email, int ID = -1)
        {
            if (string.IsNullOrEmpty(Email))
                return false;
            using (ClinicDBContext db = new ClinicDBContext())
            {
                var res = db.Patients.Where(n => n.Email == Email && n.ID != ID);
                if (res.Any())
                    return true;
                return false;
            }
        }
        public static bool ISEmailExistForNurse(string Email, int ID = -1)
        {
            if (string.IsNullOrEmpty(Email))
                return false;
            using (ClinicDBContext db = new ClinicDBContext())
            {
                var res = db.Nurses.Where(n => n.Email == Email && n.ID != ID);
                if (res.Any())
                    return true;
                return false;
            }
        }
        public static bool ISEmailExist(string Email, int ID = -1)
        {
            if (string.IsNullOrEmpty(Email))
                return false;
            using (ClinicDBContext db = new ClinicDBContext())
            {
                if (ISEmailExistForDoctor(Email, ID))
                    return true;
                else if (ISEmailExistForPatient(Email, ID))
                    return true;
                else if (ISEmailExistForNurse(Email, ID))
                    return true;
                else
                    return false;
            }
        }
        public static bool IsUserNameExist(string UserName, int ID = -1)
        {

            using (ClinicDBContext db = new ClinicDBContext())
            {
                if (string.IsNullOrEmpty(UserName))
                    return false;
                if (IsUserNameExistForDoctor(UserName,ID))
                    return true;
                else if (IsUserNameExistForPatient(UserName,ID))
                    return true;
                else
                    return false;




            }
        }
        private static bool IsUserNameExistForDoctor(string UserName, int ID = -1)
        {
            if (string.IsNullOrEmpty(UserName))
                return false;
            using (ClinicDBContext db = new ClinicDBContext())
            {
                var res = db.Doctors.Where(n => n.Username == UserName&&n.ID!=ID);
                if (res.Any())
                    return true;
                return false;
            }
        }
        private static bool IsUserNameExistForPatient(string UserName, int ID = -1)
        {
            if (string.IsNullOrEmpty(UserName))
                return false;
            using (ClinicDBContext db = new ClinicDBContext())
            {
                var res = db.Nurses.Where(n => n.UserName == UserName && n.ID != ID);
                if (res.Any())
                    return true;
                return false;
            }
        }
        private static bool IsPhoneExistForDoctor(string Phone, int ID = -1)
        {
            if (string.IsNullOrEmpty(Phone))
                return false;
            using (ClinicDBContext db = new ClinicDBContext())
            {
                var res = db.Doctors.Where(n => n.Phone == Phone && n.ID != ID);
                if (res.Any())
                    return true;
                return false;
            }
        }
        private static bool IsPhoneExistForPatient(string Phone, int ID = -1)
        {
            if (string.IsNullOrEmpty(Phone))
                return false;
            using (ClinicDBContext db = new ClinicDBContext())
            {
                var res = db.Patients.Where(n => n.Phone == Phone && n.ID != ID);
                if (res.Any())
                    return true;
                return false;
            }
        }
        private static bool IsPhoneExistForNurse(string Phone,int ID=-1)
        {
            if (string.IsNullOrEmpty(Phone))
                return false;
            using (ClinicDBContext db = new ClinicDBContext())
            {
                var res = db.Nurses.Where(n => n.Phone == Phone&&n.ID!=ID);
                if (res.Any())
                    return true;
                return false;
            }
        }
        public static bool IsPhoneExist(string Phone,int ID=-1)
        {
            if (string.IsNullOrEmpty(Phone))
                return false;
            using (ClinicDBContext db = new ClinicDBContext())
            {
               if(IsPhoneExistForPatient(Phone,ID))
                    return true;
                else if(IsPhoneExistForDoctor(Phone, ID))
                    return true;
                else if(IsPhoneExistForNurse(Phone, ID))
                    return true;
                else
                    return false;
               
            }
        }
        public static bool IsDoctorHasBooking(int DoctorId)
        {
            if (DoctorId < 0)
                return false;
            DateOnly dt = new DateOnly(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            using (ClinicDBContext db = new ClinicDBContext())
            {
                var res = db.Bookings.Where(b => b.DoctorID == DoctorId&&b.BookingDate> dt);
                if (res.Any())
                    return true;
                return false;
            }
        }
    }
 }

