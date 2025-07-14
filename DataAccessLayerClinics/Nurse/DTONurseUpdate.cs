using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _DataAccessLayerClinics.Nurse
{
    public class DTONurseUpdate
{
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public int Salary { get; set; }
        public string Username { get; set; }

        public DTONurseUpdate(int ID,string firstName, string secondName, string thirdName, string lastName, string email, string address, string phone, int age, string gender, int Salary, string UserName)
        {
            this.ID = ID;
            FirstName = firstName;
            SecondName = secondName;
            ThirdName = thirdName;
            LastName = lastName;
            Email = email;
            Address = address;
            Phone = phone;
            Age = age;
            Gender = gender;
            this.Salary = Salary;
            this.Username = UserName;

        }

    }
}
