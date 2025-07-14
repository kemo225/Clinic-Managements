using _DataAccessLayerClinics.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _BussinessLayerClinics
{
    public static class ClsValidation
{

        public static bool IsDoctorHasActiveBooking(int DoctorID)
        {
            return ClsDataAccessValidation.IsDoctorHasBooking(DoctorID);
        }
        public static bool IsUserNameExist(string UserName,int ID=-1)
        {
            return ClsDataAccessValidation.IsUserNameExist(UserName,ID);
        }
        public static bool IsPhoneExist(string Phone,int ID = -1)
        {
            return ClsDataAccessValidation.IsPhoneExist(Phone,ID);
        }
        public static bool IsEmailExist(string Email,int ID = -1)
        {
            return ClsDataAccessValidation.ISEmailExist(Email,ID);
        }
        public static bool IsEmailExistforPatient(string Email,int ID = -1)
        {
            return ClsDataAccessValidation.ISEmailExistForPatient(Email, ID);
        }
        public static bool IsEmailExistforDoctor(string Email, int ID = -1)
        {
            return ClsDataAccessValidation.ISEmailExistForDoctor(Email,ID);
        }
        public static bool IsEmailExistforNurse(string Email, int ID = -1)
        {
            return ClsDataAccessValidation.ISEmailExistForNurse(Email,ID);
        }
        public static bool IsNurseExist(int NurseId)
        {
            return ClsDataAccessValidation.IsNurseExits(NurseId);
        }
        public static bool IsDoctorExist(int DoctorId)
        {
            return ClsDataAccessValidation.IsDoctorExist(DoctorId);
        }
        public static bool IsPatientExist(int PatientId)
        {
            return ClsDataAccessValidation.IsPatientExits(PatientId);
        }
        public static bool IsAppointmentExist(int AppointmentId)
        {
            return ClsDataAccessValidation.IsAppointmentExist(AppointmentId);
        }
        public static bool IsDoctorAvailinTime(TimeOnly BookingTime, int DoctorId, DateOnly BookingDate)
        {
            return ClsDataAccessValidation.IsDoctorAvailinTime(BookingTime, DoctorId, BookingDate);
        }
        public static bool IsDateValid(DateOnly BookingDate)
        {
            return ClsDataAccessValidation.IsDateValidforBooking(BookingDate);
        }
        public static bool IsTimeValid(TimeOnly BookingTime,int DoctorID)
        {
            return ClsDataAccessValidation.IsTimeValid(BookingTime,DoctorID);
        }
        public static bool IsBookingExist(int BookingId)
        {
            return ClsDataAccessValidation.IsBookingExist(BookingId);
        }
        public static bool IsBookingPaid(int BookingId)
        {
            return ClsDataAccessValidation.IsBookingPaid(BookingId);
        }
        public static bool IsPatientHasActiveBooking(int patientID,int DoctorID)
        {
            return ClsDataAccessValidation.IsPatientHasBookingActive(patientID, DoctorID);
        }
        public static DateOnly ToDateDateOnly(DateTime dateTime)
        {
          return ClsDataAccessValidation.ToDateOnly(dateTime);
        }
        public static DateTime ToDateTime(DateOnly dateTime)
        {
            return ClsDataAccessValidation.ToDateTime(dateTime);
        }


    }
}
