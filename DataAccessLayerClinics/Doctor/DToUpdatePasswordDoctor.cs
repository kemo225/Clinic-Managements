using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doctor
{
    public class DToUpdatePasswordDoctor
{
        public int DoctorID {  get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        public DToUpdatePasswordDoctor(int DoctorID,string OldPassword, string NewPassword )
        {
            this.DoctorID = DoctorID;
            this.OldPassword = OldPassword;
            this.NewPassword = NewPassword;
        }
    }
}
