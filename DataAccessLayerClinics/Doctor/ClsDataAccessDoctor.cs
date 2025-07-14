using _3_DataAccessLayerClinics.Models;
using _DataAccessLayerClinics.PasswordService;
using _DataAccessLayerClinics.Validation;
using DataAccessLayerClinics.DTOS;
using Doctor;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace _DataAccessLayerClinics.Doctor
{
    public class ClsDataAccessDoctor
{
        public static DTODoctorUpdate GetDoctorById(int id)
        {
            using (ClinicDBContext context = new ClinicDBContext())
            {
                var doctorchk = context.Doctors.Find(id);
                if (doctorchk == null)
                    return null;
                var doctor = context.Doctors
                    .Where(d => d.ID == id)
                    .Select(d => new DTODoctorUpdate(d.ID,
                    d.FirstName,
                    d.SecondName,
                    d.ThirdName,
                    d.LastName,
                    d.Email,
                    d.Address,
                    d.Phone, Convert.ToInt32(d.Age),
                    d.Gender,
                    d.Username,
                    Convert.ToInt32(d.Salary),
                    Convert.ToInt32(d.SpecialtyID),
                    Convert.ToInt32(d.NurseID))).SingleOrDefault();
                return doctor;
            }
        }
        public static List<DTODoctorRead> getAllDoctors()
        {
            using (ClinicDBContext context = new ClinicDBContext())
            {
               var Doctor=context.Doctors.Include(d => d.Nurse).Include(d => d.Specialty)
                    .Select(d => new DTODoctorRead(
                        d.ID,
                        d.FirstName,
                        d.SecondName,
                        d.ThirdName,
                        d.LastName,
                        d.Email,
                        d.Address,
                        d.Phone,
                        Convert.ToInt16(d.Age),
                        d.Gender,
                        Convert.ToInt16(d.Salary),
                        d.Username,
                        d.Specialty.Name,d.Nurse.FirstName+" "+d.Nurse.LastName
                    )).ToList();
                return Doctor;
            }
        }
        public static DTODoctorRead GetDoctorReadById(int id)
        {
            using (ClinicDBContext context = new ClinicDBContext())
            {
                var doctorchk = context.Doctors.Find(id);
                if (doctorchk == null)
                    return null;
                var doctor = context.Doctors.Include(d => d.Nurse).Include(d => d.Specialty)
                    .Where(d => d.ID == id)
                    .Select(d => new DTODoctorRead(
                        d.ID,
                        d.FirstName,
                        d.SecondName,
                        d.ThirdName,
                        d.LastName,
                        d.Email,
                        d.Address,
                        d.Phone,
                        Convert.ToInt16(d.Age),
                        d.Gender,
                        Convert.ToInt32(d.Salary),
                        d.Username,
                        d.Specialty.Name, d.Nurse.FirstName + " " + d.Nurse.LastName
                    )).SingleOrDefault();
                return doctor;
            }
        }
        public static DTODoctorRead GetDoctorReadByUserName(string UserName)
        {
            using (ClinicDBContext context = new ClinicDBContext())
            {
                if (!ClsDataAccessValidation.IsUserNameExist(UserName))
                    return null;
                var doctor = context.Doctors.Include(d => d.Nurse).Include(d => d.Specialty)
                    .Where(d => d.Username == UserName)
                    .Select(d => new DTODoctorRead(
                        d.ID,
                        d.FirstName,
                        d.SecondName,
                        d.ThirdName,
                        d.LastName,
                        d.Email,
                        d.Address,
                        d.Phone,
                        Convert.ToInt16(d.Age),
                        d.Gender,
                        Convert.ToInt32(d.Salary),
                        d.Username,
                        d.Specialty.Name, d.Nurse.FirstName + " " + d.Nurse.LastName
                    )).SingleOrDefault();
                return doctor;
            }
        }
        public static bool UpdateDoctor(DTODoctorUpdate doctor)
        {
            using (ClinicDBContext context = new ClinicDBContext())
            {
                if(context.Doctors.Any(d=>d.ID == doctor.ID))
                {
                    var existingDoctor = context.Doctors.Find(doctor.ID);
                    if (existingDoctor != null)
                    {
                        existingDoctor.FirstName = doctor.FirstName;
                        existingDoctor.SecondName = doctor.SecondName;
                        existingDoctor.ThirdName = doctor.ThirdName;
                        existingDoctor.LastName = doctor.LastName;
                        existingDoctor.Email = doctor.Email;
                        existingDoctor.Address = doctor.Address;
                        existingDoctor.Phone = doctor.Phone;
                        existingDoctor.Age = doctor.Age;
                        existingDoctor.Salary = doctor.Salary;
                        existingDoctor.Username = doctor.Username;
                        existingDoctor.NurseID= doctor.NurseID;
                        context.SaveChanges();
                    }
                } 
                else
                {
                    return false;
                }
                return true;    
            }
        }
        public static int AddDoctor(DTODoctorCreate Doctoradd)
        {
            using (ClinicDBContext context = new ClinicDBContext())
            {

                var res = context.Doctors.Add(new _3_DataAccessLayerClinics.Models.Doctor()
                {
                    FirstName = Doctoradd.FirstName,
                    SecondName = Doctoradd.SecondName,
                    ThirdName = Doctoradd.ThirdName,
                    LastName = Doctoradd.LastName,
                    Email = Doctoradd.Email,
                    Address = Doctoradd.Address,
                    SpecialtyID = Doctoradd.SpecialtyID,
                    Salary = Doctoradd.Salary,
                    Gender = Doctoradd.Gender,
                    Username = Doctoradd.Username,
                    password = Doctoradd.password,
                    Salt = Doctoradd.Salt,
                    Phone = Doctoradd.Phone,
                    Age = Doctoradd.Age,
                    NurseID= Doctoradd.NurseID
                });
                context.SaveChanges();
                return res.Entity.ID;

            }
        }
        public static bool DeleteDoctor(int id)
        {
            using (ClinicDBContext context = new ClinicDBContext())
            {
                var doctor = context.Doctors.Find(id);
                if (doctor != null)
                {
                    context.Doctors.Remove(doctor);
                    context.SaveChanges();
                    return true;
                }
                return false;
            }
        }
        public static bool UpdatePassword(DToUpdatePasswordDoctor dtoupdatePassword)
        {
            using (ClinicDBContext db = new ClinicDBContext())
            {
                var doctor = db.Doctors.Find(dtoupdatePassword.DoctorID);
                if (doctor == null)
                    return false;

                if (!ClsDataAccessPasswordService.IsPasswordCorrect(dtoupdatePassword.OldPassword, doctor.password.Trim(), doctor.Salt.Trim()))
                    return false;


                string Salt = ClsDataAccessPasswordService.GenerateSaltString();
            string HashedNewPassword = ClsDataAccessPasswordService.GenerateHashedPassword(dtoupdatePassword.NewPassword, Salt);
           
            doctor.password = HashedNewPassword;
            doctor.Salt = Salt;
            db.SaveChanges();
                return true;
            }
        }
    }
}
