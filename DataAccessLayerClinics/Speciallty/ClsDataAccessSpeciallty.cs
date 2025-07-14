using _3_DataAccessLayerClinics.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _DataAccessLayerClinics.Speciallty
{
    public class ClsDataAccessSpeciallty
{
        public static List<DtoSpecialltyReadUpdate> GetAllSpecialties()
        {
            using (ClinicDBContext context = new ClinicDBContext())
            {
                var res = context.Specialties.Select(s => new DtoSpecialltyReadUpdate(s.ID, s.Name)).ToList();
                return res;
            }
        }
        public static DtoSpecialltyReadUpdate GetSpecialtyById(int id)
        {
            using (ClinicDBContext context = new ClinicDBContext())
            {
                var res = context.Specialties.Where(s => s.ID == id).Select(s => new DtoSpecialltyReadUpdate(s.ID, s.Name)).SingleOrDefault();
                return res;
            }
        }
        public static bool UpdateSpecialty(DtoSpecialltyReadUpdate dtoSpecialty)
        {
            using (ClinicDBContext context = new ClinicDBContext())
            {
                var specialty = context.Specialties.Find(dtoSpecialty.Id);
                if (specialty == null)
                {
                    return false; // Specialty not found
                }
                specialty.Name = dtoSpecialty.Name;
                context.SaveChanges();
                return true;
            }
        }
        public static int AddSpecialty(DTOSpecialltyAdd dtoSpecialty)
        {
            using (ClinicDBContext context = new ClinicDBContext())
            {
                var specialty = new Specialty
                {
                    Name = dtoSpecialty.Name
                };
                context.Specialties.Add(specialty);
                context.SaveChanges();
                return specialty.ID; // Specialty added successfully
            }
        }
        public static bool DeleteSpecialty(int id)
        {
            using (ClinicDBContext context = new ClinicDBContext())
            {
                var specialty = context.Specialties.Find(id);
                if (specialty == null)
                {
                    return false; // Specialty not found
                }
                context.Specialties.Remove(specialty);
                context.SaveChanges();
                return true; // Specialty deleted successfully
            }
        }
    }
}
