using _DataAccessLayerClinics.Patient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _BussinessLayerClinics
{
    public class ClsPatient
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
        public DTOPatientReadUpdate DtoReadUpdate
        {
            get
            {
                return new DTOPatientReadUpdate(this.ID,this.FirstName,this.SecondName,this.ThirdName,this.LastName,this.Email,this.Address,this.Phone,this.Age,this.Gender);
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
                this.Gender = value.Gender;

            }
        }
        public DTOPatientAdd Dtoadd
        {
            get
            {
                return new DTOPatientAdd( this.FirstName, this.SecondName, this.ThirdName, this.LastName, this.Email, this.Address, this.Phone, this.Age, this.Gender);
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
                this.Gender = value.Gender;

            }
        }

        public static bool DeletePatientbyID(int ID)
        {
            return ClsDataAccessPatient.DeletePatient(ID);
        }

        public static List<DTOPatientReadUpdate>GetPatients()
        {
            return ClsDataAccessPatient.GetPatients();
        }

        public enum enMode { Update, Add }
        public enMode Mode { get; set; }
        public ClsPatient(DTOPatientReadUpdate DtoReadUpdate, enMode Mode)
        {
            this.Mode = Mode;
            this.DtoReadUpdate = DtoReadUpdate;
        }
        public ClsPatient(DTOPatientAdd Dtoadd, enMode Mode)
        {
            this.Mode = Mode;
            this.Dtoadd = Dtoadd;
        }
        public static ClsPatient GetPatientByID(int ID)
        {
            DTOPatientReadUpdate dtoPatient = ClsDataAccessPatient.GetPatientByID(ID);
            if (dtoPatient == null)
                return null;
            return new ClsPatient(dtoPatient, enMode.Update);
        }
        public static ClsPatient GetPatientByPhone(string PhoneNumber)
        {
            DTOPatientReadUpdate dtoPatient = ClsDataAccessPatient.GetPatientByPhoneNumber(PhoneNumber);
            if (dtoPatient == null)
                return null;
            return new ClsPatient(dtoPatient, enMode.Update);
        }
        private bool UpdatePatient()
        {
            return ClsDataAccessPatient.UpdatePatient(this.DtoReadUpdate);
        }
        private bool addpatient()
        {
            this.ID= ClsDataAccessPatient.AddPatient(this.Dtoadd);
            return(this.ID > 0);
        }
        public bool Save()
        {
            switch
                (this.Mode)
            {
                case enMode.Update:
                    return UpdatePatient();
                case enMode.Add:
                    this.Mode = enMode.Update;
                    return addpatient();
                default:
                    return false; // Invalid mode
            }







        }

    }
}
 
    
