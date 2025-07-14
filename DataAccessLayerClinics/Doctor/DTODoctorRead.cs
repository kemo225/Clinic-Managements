using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayerClinics.DTOS
{
    public class DTODoctorRead
{
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public int Salary { get; set; } 
        public int Age { get; set; }
        public string SpecialtyName { get; set; }
        public string UserName { get; set; }    
        public string Gender { get; set; }  
        public string NurseName {  get; set; }
        
        public DTODoctorRead(int ID,string firstName, string secondName, string thirdName, string lastName, string email, string address, string phone, int age,string Gender, int salary,string UserName ,string SpeciallityName,string NurseName)
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
            Salary = salary;
            SpecialtyName = SpeciallityName;
            this.UserName = UserName;
            this.Salary = salary;   
            this.Gender = Gender;   
            this.NurseName = NurseName; 
        }
    }
}
