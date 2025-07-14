using _3_DataAccessLayerClinics.Models;
using _DataAccessLayerClinics.Nurse;
using _DataAccessLayerClinics.PasswordService;
using _DataAccessLayerClinics.Validation;
using Doctor;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace _DataAccessLayerClinics.Nurse
{
    public class ClsDataAccessNurse
    {

        public static List<DTONurseRead> getAllNurse()
        {
            using (ClinicDBContext db = new ClinicDBContext())
            {
                List<DTONurseRead> AllNurse = new List<DTONurseRead>();

                var res = db.Nurses.Select(N => new DTONurseRead
                (
                     N.ID,
                    N.FirstName,
                    N.SecondName,
                    N.ThirdName,
                    N.LastName,
                    N.Email,
                    N.Address,
                    N.Phone,
                    Convert.ToInt32(N.Age),
                    N.Gender,
                Convert.ToInt32(N.Salary),
                    N.UserName
                )).ToList();

                return res;

            }
        }
        public static DTONurseRead GetNurseById(int ID)
        {
            using (ClinicDBContext db = new ClinicDBContext())
            {
                var nursechk = db.Nurses.Find(ID);
                if (nursechk == null)
                    return null;
                var nurse = db.Nurses.Where(n => n.ID == ID).Select(nurse =>
                    new DTONurseRead(nurse.ID,
                    nurse.FirstName,
                    nurse.SecondName,
                    nurse.ThirdName,
                    nurse.LastName,
                    nurse.Email,
                    nurse.Address,
                    nurse.Phone,
                    Convert.ToInt32(nurse.Age),
                    nurse.Gender,
                    Convert.ToInt32(nurse.Salary),
                    nurse.UserName
)).SingleOrDefault();
                return nurse;


            }
        }
        public static DTONurseRead GetNurseByUserName(string UserName)
        {
            using (ClinicDBContext db = new ClinicDBContext())
            {
                if(!ClsDataAccessValidation.IsUserNameExist(UserName))
                    return null;
                var nurse = db.Nurses.Where(n => n.UserName == UserName).Select(nurse =>
                    new DTONurseRead(nurse.ID, nurse.FirstName,
                    nurse.SecondName,
                    nurse.ThirdName,
                    nurse.LastName,
                    nurse.Email,
                    nurse.Address,
                    nurse.Phone,
                    Convert.ToInt32(nurse.Age),
                    nurse.Gender,
                    Convert.ToInt32(nurse.Salary),
                    nurse.UserName
)).SingleOrDefault();
                return nurse;


            }
        }
        public static bool UpdateNurse(DTONurseUpdate NurseUpdate)
        {
            using (ClinicDBContext db = new ClinicDBContext())
            {
                var nurse = db.Nurses.Find(NurseUpdate.ID);
                if (nurse == null)
                {
                    return false; // Nurse not found
                }
                nurse.FirstName = NurseUpdate.FirstName;
                nurse.SecondName = NurseUpdate.SecondName;
                nurse.ThirdName = NurseUpdate.ThirdName;
                nurse.LastName = NurseUpdate.LastName;
                nurse.Email = NurseUpdate.Email;
                nurse.Address = NurseUpdate.Address;
                nurse.Phone = NurseUpdate.Phone;
                nurse.Age = NurseUpdate.Age;
                nurse.Salary = NurseUpdate.Salary;
                nurse.Gender = NurseUpdate.Gender;
                nurse.UserName = NurseUpdate.Username;

                db.SaveChanges();
                return true; // Update successful

            }
        }

        public static bool DeleteNurse(int ID)

        {
            using (ClinicDBContext db = new ClinicDBContext())
            {
                var nurse = db.Nurses.Find(ID);
                if (nurse == null)
                {
                    return false; // Nurse not found
                }
                db.Nurses.Remove(nurse);
                db.SaveChanges();
                return true; // Deletion successful
            }
        }

        public static int AddNurse(DTONurseCreate dTONurseCreate)
        {

            using (ClinicDBContext db = new ClinicDBContext())
            {
                _3_DataAccessLayerClinics.Models.Nurse nurse = new _3_DataAccessLayerClinics.Models.Nurse();
                nurse.FirstName = dTONurseCreate.FirstName;
                nurse.SecondName = dTONurseCreate.SecondName;
                nurse.ThirdName = dTONurseCreate.ThirdName;
                nurse.LastName = dTONurseCreate.LastName;
                nurse.Email = dTONurseCreate.Email;
                nurse.Address = dTONurseCreate.Address;
                nurse.Phone = dTONurseCreate.Phone;
                nurse.Age = dTONurseCreate.Age;
                nurse.Salary = dTONurseCreate.Salary;
                nurse.UserName = dTONurseCreate.Username;
                nurse.Password = dTONurseCreate.password;
                nurse.Salt = dTONurseCreate.Salt;
                db.Nurses.Add(nurse);
                db.SaveChanges();
                return nurse.ID; // Return the ID of the newly created nurse

            }
        }

        public static bool UpdatePassword(DtoUpdatePasswordNurse dtoupdatePassword)
        {
            using (ClinicDBContext db = new ClinicDBContext())
            {
                var Nurse = db.Nurses.Find(dtoupdatePassword.NurseID);
                if (Nurse == null)
                    return false;

                if (!ClsDataAccessPasswordService.IsPasswordCorrect(dtoupdatePassword.OldPassword, Nurse.Password.Trim(), Nurse.Salt.Trim()))
                    return false;


                string Salt = ClsDataAccessPasswordService.GenerateSaltString();
            string HashedNewPassword = ClsDataAccessPasswordService.GenerateHashedPassword(dtoupdatePassword.NewPassword, Salt);
         
                Nurse.Password = HashedNewPassword;
                Nurse.Salt = Salt;
                db.SaveChanges();
                return true;
            }
        }
    }
}