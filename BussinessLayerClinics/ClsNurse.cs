using _DataAccessLayerClinics.Nurse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _BussinessLayerClinics
{
    public class ClsNurse
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
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public string Gender { get; set; }

        public DTONurseRead DTONurseRead
        {
            get
            {
                return new DTONurseRead(this.ID, this.FirstName, this.SecondName, this.ThirdName, this.LastName, this.Email, this.Address, this.Phone, this.Age, this.Gender, this.Salary, this.UserName);
            }
            set
            {
                this.ID = value.ID;
                this.FirstName = value.FirstName;
                this.SecondName = value.SecondName;
                this.ThirdName = value.ThirdName;
                this.LastName = value.LastName;
                this.Email = value.Email;
                this.Address = value.Address;
                this.Phone = value.Phone;
                this.Age = value.Age;
                this.Salary = value.Salary;
                this.UserName = value.UserName;
                this.Gender = value.Gender;
            }
        }
        public DTONurseCreate dTONurseCreate
        {
            get
            {
                return new DTONurseCreate(FirstName, SecondName, ThirdName, this.LastName, this.Email, this.Address, this.Phone, this.Age, this.Gender, this.Salary, this.UserName, this.Password, this.Salt);
            }
            set
            {
                this.FirstName = value.FirstName;
                this.SecondName = value.SecondName;
                this.ThirdName = value.ThirdName;
                this.LastName = value.LastName;
                this.Email = value.Email;
                this.Address = value.Address;
                this.Phone = value.Phone;
                this.Age = value.Age;
                this.Salary = value.Salary;
                this.UserName = value.Username;
                this.Password = value.password;
                this.Salt = value.Salt;
            }
        }
        public DTONurseUpdate dTONurseUpdate
        {
            get
            {
                return new DTONurseUpdate(this.ID, this.FirstName, this.SecondName, this.ThirdName, this.LastName, this.Email, this.Address, this.Phone, this.Age, this.Gender, this.Salary, this.UserName);
            }
            set
            {
                this.ID = value.ID;
                this.FirstName = value.FirstName;
                this.SecondName = value.SecondName;
                this.ThirdName = value.ThirdName;
                this.LastName = value.LastName;
                this.Email = value.Email;
                this.Address = value.Address;
                this.Phone = value.Phone;
                this.Age = value.Age;
                this.Salary = value.Salary;
                this.UserName = value.Username;
                this.Gender = value.Gender;

            }
        }
        public enum enMode { Update, add }
        public enMode Mode { get; set; }
        public static List<DTONurseRead> GetallNurse()
        {
            return ClsDataAccessNurse.getAllNurse();
        }
        public ClsNurse(DTONurseRead dTONurseRead, enMode Mode)
        {
            this.Mode = Mode;
            this.DTONurseRead = dTONurseRead;
        }
        public ClsNurse(DTONurseCreate dTONurseCreate, enMode Mode)
        {
            this.Mode = Mode;
            this.dTONurseCreate = dTONurseCreate;
        }
        public static DTONurseRead GetDTONurseReadByID(int ID)
        {
          return  ClsDataAccessNurse.GetNurseById(ID);
        }
        public static ClsNurse GetNurseByID(int ID)
        {
            DTONurseRead dTONurseRead = ClsDataAccessNurse.GetNurseById(ID);
            if (dTONurseRead == null)
                return null;
            return new ClsNurse(dTONurseRead, enMode.Update);
        }
        private bool UpdateNurse()
        {
            return ClsDataAccessNurse.UpdateNurse(this.dTONurseUpdate);
        }
        private bool addNurse()
        {
            this.ID = ClsDataAccessNurse.AddNurse(this.dTONurseCreate);
            return (this.ID > 0);
        }
        public bool Save()
        {
            switch
                (this.Mode)
            {
                case enMode.Update:
                    return UpdateNurse();
                case enMode.add:
                    this.Mode = enMode.Update;
                    return addNurse();
                default:
                    throw new Exception("Invalid Mode");
            }







        }
        public static bool UpdatePassword(DtoUpdatePasswordNurse dtoupdated)
        {
            return ClsDataAccessNurse.UpdatePassword(dtoupdated);
        }
        public static DTONurseRead GetNurseByUserName(string UserName)
        {
            return ClsDataAccessNurse.GetNurseByUserName(UserName);
        }
        public static bool DeleteNurse(int ID)
        {
            return ClsDataAccessNurse.DeleteNurse(ID);
        }
    }
}
