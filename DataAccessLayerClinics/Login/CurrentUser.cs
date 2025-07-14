using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _DataAccessLayerClinics.Login
{
    public class CurrentUser
{
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Role { get; set; }
        public CurrentUser(int Id, string Name, string Phone, string Role)
        {
            this.Id = Id;
            this.Name = Name; this.Phone = Phone;
            this.Role = Role;
        }
}
}
