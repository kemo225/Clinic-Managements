using _DataAccessLayerClinics.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _BussinessLayerClinics.Global
{
    public static class ClsGlobal
    {
        public static CurrentUser Currentuser { get; set; }
        public static bool IsDoctor()
        {
            if (Currentuser.Role.ToLower() == "doctor")
                return true;
            else
                return false;
        }
        public static bool IsNurse()
        {
            if (Currentuser.Role.ToLower() == "nurse")
                return true;
            else
                return false;
        }

    }
}
