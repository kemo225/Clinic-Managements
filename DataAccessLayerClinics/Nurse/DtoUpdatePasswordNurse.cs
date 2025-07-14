using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _DataAccessLayerClinics.Nurse
{
    public class DtoUpdatePasswordNurse
{
        public int NurseID { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        public DtoUpdatePasswordNurse(int NurseID,string OldPassword, string NewPassword)
        {
            this.NurseID = NurseID;
            this.OldPassword = OldPassword;
            this.NewPassword = NewPassword;
        }
    }
}
