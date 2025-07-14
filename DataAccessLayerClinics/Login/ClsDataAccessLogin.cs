using _3_DataAccessLayerClinics.Models;
using _DataAccessLayerClinics.PasswordService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _DataAccessLayerClinics.Login
{
    public class ClsDataAccessLogin
    {
        public static bool LoginDoctor(DtoLogin Login)
        {
            using (ClinicDBContext dBContext = new ClinicDBContext())
            {
                // Check if the user exists in the database
                var doctor = dBContext.Doctors.FirstOrDefault(u => u.Username == Login.Username);
                if (doctor == null)
                    return false;
                // user exits and is A doctor
                if (ClsDataAccessPasswordService.IsPasswordCorrect(Login.Password,doctor.password.Trim(),doctor.Salt.Trim()))
                    return true; // Password is correct
                else
                    return false; // Password is incorrect


            }

        }
        public static bool LoginNurse(DtoLogin Login)
        {
            using (ClinicDBContext dBContext = new ClinicDBContext())
            {

                var UserNurse = dBContext.Nurses.FirstOrDefault(u => u.UserName == Login.Username);
                if (UserNurse == null)
                    return false; // nurse not found

                if (ClsDataAccessPasswordService.IsPasswordCorrect(Login.Password, UserNurse.Password.Trim(), UserNurse.Salt.Trim()))
                    return true; // Password is correct
                else
                    return false; // Password is incorrect
            }
        }
    }
}
