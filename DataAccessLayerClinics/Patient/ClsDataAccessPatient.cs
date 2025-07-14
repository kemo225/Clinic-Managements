using _3_DataAccessLayerClinics.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _DataAccessLayerClinics.Patient
{
    public class ClsDataAccessPatient
{
        public static List<DTOPatientReadUpdate> GetPatients()
        {
            using(ClinicDBContext db=new ClinicDBContext())
            {
                var res=db.Patients.Select(p=>new DTOPatientReadUpdate(p.ID,
                    p.FirstName,
                    p.SecondName,
                    p.ThirdName,
                    p.LastName,
                    p.Email,
                    p.Address,
                    p.Phone,
                   Convert.ToInt32( p.Age),
                    p.Gender)).ToList();
                    return res;






            }

        }

        public static DTOPatientReadUpdate GetPatientByID(int ID)
        {
            using (ClinicDBContext db = new ClinicDBContext())
            {
                var res=db.Patients.Where(p=>p.ID==ID).Select(p => new DTOPatientReadUpdate(p.ID,
                    p.FirstName,
                    p.SecondName,
                    p.ThirdName,
                    p.LastName,
                    p.Email,
                    p.Address,
                    p.Phone,
                   Convert.ToInt32(p.Age),
                    p.Gender)).SingleOrDefault();
                return res;

            }
        }

        public static DTOPatientReadUpdate GetPatientByPhoneNumber(string Phone)
        {
            using (ClinicDBContext db = new ClinicDBContext())
            {
                var res = db.Patients.Where(p => p.Phone == Phone).Select(p => new DTOPatientReadUpdate(p.ID,
                    p.FirstName,
                    p.SecondName,
                    p.ThirdName,
                    p.LastName,
                    p.Email,
                    p.Address,
                    p.Phone,
                   Convert.ToInt32(p.Age),
                    p.Gender)).SingleOrDefault();
                return res;

            }
        }

        public static bool DeletePatient(int ID)
        {
            using (ClinicDBContext db = new ClinicDBContext())
            {
                var patient = db.Patients.Find(ID);
                if (patient == null)
                    return false;
                db.Patients.Remove(patient);
                db.SaveChanges();
                return true;
            }
        }

        public static int AddPatient(DTOPatientAdd dTOPatientAdd)
        {
            using (ClinicDBContext db = new ClinicDBContext())
            {
                var willadd = new _3_DataAccessLayerClinics.Models.Patient() {FirstName=dTOPatientAdd.FirstName,
                SecondName = dTOPatientAdd.SecondName,
                    ThirdName = dTOPatientAdd.ThirdName,
                    LastName = dTOPatientAdd.LastName,
                    Email = dTOPatientAdd.Email,
                    Address = dTOPatientAdd.Address,
                    Phone = dTOPatientAdd.Phone,
                    Gender = dTOPatientAdd.Gender,
                    Age = dTOPatientAdd.Age



                };
                db.Patients.Add(willadd);
                db.SaveChanges();
                return willadd.ID; // Return the ID of the newly added patient
            }
        }

        public static bool UpdatePatient(DTOPatientReadUpdate dTOPatientReadUpdate)
        {
            using(ClinicDBContext db=new ClinicDBContext())
            {
                var res = db.Patients.Find(dTOPatientReadUpdate.ID);
                if (res == null)
                    return false;
                res.FirstName = dTOPatientReadUpdate.FirstName;
                res.SecondName = dTOPatientReadUpdate.SecondName;
                res.ThirdName = dTOPatientReadUpdate.ThirdName;
                res.LastName = dTOPatientReadUpdate.LastName;
                res.Email = dTOPatientReadUpdate.Email;
                res.Address = dTOPatientReadUpdate.Address;
                res.Phone = dTOPatientReadUpdate.Phone;
                res.Gender= dTOPatientReadUpdate.Gender;
                res.Age = dTOPatientReadUpdate.Age;
                db.SaveChanges();
                return true;
            }
        }
    }
}
