using _DataAccessLayerClinics.PasswordService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace _BussinessLayerClinics
{
    public class PasswordServices
{
        public static string GenerateHashedPassword(string Password, string Salt)
        {
            return ClsDataAccessPasswordService.GenerateHashedPassword(Password, Salt);
        }  
        public static bool IsPasswordCorrect(string Password, string HashedPassword, string Salt)
        {
           return ClsDataAccessPasswordService.IsPasswordCorrect(Password, HashedPassword, Salt);
        }
        public static string GenerateSaltString(int size = 16)
        {
           return ClsDataAccessPasswordService.GenerateSaltString(size);
        }
    }
}
