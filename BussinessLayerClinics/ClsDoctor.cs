using _DataAccessLayerClinics;
using _DataAccessLayerClinics.Doctor;
using DataAccessLayerClinics.DTOS;
using Doctor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _BussinessLayerClinics
{
    public class ClsDoctor
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
        public int Salary { get; set; }
        public string SpecialtyName { get; set; }
        public string UserName { get; set; }
        public string password { get; set; }
        public string Salt { get; set; }
        public int specialtyID { get; set; }
        public string Gender { get; set; }
        public int NurseID {  get; set; }
        public string NurseName {  get; set; }
        public DTODoctorCreate DoctorCreate
        {
            get
            {
                return new DTODoctorCreate(this.FirstName, this.SecondName, this.ThirdName, this.LastName, this.Email, this.Address, this.Phone, this.Age, this.Gender, this.Salary, this.specialtyID, this.UserName, this.password, this.Salt,this.ID);
            }
            set
            {
                this.NurseID = value.NurseID;
                FirstName = value.FirstName;
                SecondName = value.SecondName;
                ThirdName = value.ThirdName;
                LastName = value.LastName;
                Email = value.Email;
                Address = value.Address;
                Phone = value.Phone;
                Age = value.Age;
                Salary = value.Salary;
                specialtyID = value.SpecialtyID;
                UserName = value.Username;
                password = value.password;
                Salt = value.Salt;

            }
        }
        public DTODoctorRead DtoDoctorRead
        {
            get
            {
                return new DTODoctorRead(ID, FirstName, SecondName, ThirdName, LastName, Email, Address, Phone, Age, Gender, Salary, UserName, SpecialtyName,this.NurseName);
            }
            set
            {
                this.NurseName = value.NurseName;   
                ID = value.ID;
                FirstName = value.FirstName;
                SecondName = value.SecondName;
                ThirdName = value.ThirdName;
                LastName = value.LastName;
                Email = value.Email;
                Address = value.Address;
                Phone = value.Phone;
                Age = value.Age;
                Salary = value.Salary;
                SpecialtyName = value.SpecialtyName;
                UserName = value.UserName;
                this.Gender = value.Gender;
            }
        }

        public DTODoctorUpdate DtoDoctorUpdate
        {
            get
            {
                return new DTODoctorUpdate(ID, this.FirstName, this.SecondName, this.ThirdName, this.LastName, this.Email, this.Address, this.Phone, this.Age, this.Gender, this.UserName, this.Salary, this.specialtyID,this.NurseID);

            }
            set
            {
                this.NurseID = value.NurseID;
                ID = value.ID;
                FirstName = value.FirstName;
                SecondName = value.SecondName;
                ThirdName = value.ThirdName;
                LastName = value.LastName;
                Email = value.Email;
                Address = value.Address;
                Phone = value.Phone;
                Age = value.Age;
                Salary = value.Salary;
                specialtyID = value.SpecialtyID;
                UserName = value.Username;

            }
        }
        public enum enMode { Update, Add }
        public enMode Mode
        { get; set; }
        public ClsDoctor(DTODoctorCreate Doctor, enMode Mode)
        {
            this.DoctorCreate = Doctor;
            this.Mode = Mode;
        }
 
        public ClsDoctor(DTODoctorRead Doctor, enMode Mode)
        {
            this.DtoDoctorRead = Doctor;
            this.Mode = Mode;
        }
        public static List<DTODoctorRead> GetAllDoctors()
        {
            return ClsDataAccessDoctor.getAllDoctors();
        }
        private bool UpdateDoctor()
        {
            return ClsDataAccessDoctor.UpdateDoctor(this.DtoDoctorUpdate);
        }
        public static ClsDoctor GetDoctorReadByID(int ID)
        {
            DTODoctorRead doctor = ClsDataAccessDoctor.GetDoctorReadById(ID);
            if (doctor == null)
            {
                return null;
            }
            return new ClsDoctor(doctor, enMode.Update);

        }
        public static DTODoctorRead GetDoctorbyUserName(string UserName)
        {
            return ClsDataAccessDoctor.GetDoctorReadByUserName(UserName);
        }
        private bool AddDoctor()
        {
            this.ID = ClsDataAccessDoctor.AddDoctor(DoctorCreate);
            return (this.ID != -1);
        }
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.Add:
                    this.Mode = enMode.Update;
                    return AddDoctor();
                case enMode.Update:
                    return UpdateDoctor();
                default:
                    return false;
            }
        }
        public static bool UpdatePassword(DToUpdatePasswordDoctor dToUpdatePassword)
        {
            return ClsDataAccessDoctor.UpdatePassword(dToUpdatePassword);
        }
        public static bool DeleteDoctor(int ID)
        {
            return ClsDataAccessDoctor.DeleteDoctor(ID);
        }
    }
}
