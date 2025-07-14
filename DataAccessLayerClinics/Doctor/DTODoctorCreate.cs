using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayerClinics.DTOS
{

    public class DTODoctorCreate
       {
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
        public int SpecialtyID { get; set; }
        public string Username { get; set; }
        public string password { get; set; }
        public string Salt { get; set; }
        public int NurseID { get; set; }

        public DTODoctorCreate(string firstName, string secondName, string thirdName, string lastName, string email, string address, string phone, int age, string gender,int Salary, int specialtyID,string UserName,string Password,string Salt,int NurseID)
        {
            FirstName = firstName;
            SecondName = secondName;
            ThirdName = thirdName;
            LastName = lastName;
            Email = email;
            Address = address;
            Phone = phone;
            Age = age;
            Gender = gender;
            SpecialtyID = specialtyID;
            this.Salary = Salary;
            this.Username = UserName;
            this.password = Password;
            this.Salt = Salt;
            this.NurseID = NurseID;
        }
    }
}
