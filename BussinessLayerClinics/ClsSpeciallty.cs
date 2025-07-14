using _DataAccessLayerClinics.Speciallty;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _BussinessLayerClinics
{
    public class ClsSpeciallty
{
        public int Id { get; set; }
        public string Name { get; set; }
       public DTOSpecialltyAdd dTOSpecialltyadd
        {
            get
            {
                return new DTOSpecialltyAdd(Name);
            }
            set
            {
                Name = value.Name;
            }
        }
        public DtoSpecialltyReadUpdate dtoSpecialltyReadUpdate
        {
            get
            {
                return new DtoSpecialltyReadUpdate(Id, Name);
            }
            set
            {
                Id = value.Id;
                Name = value.Name;
            }
        }
        public enum enMode
        {
            update,
            add
        }
        public enMode Mode { get; set; }
        public ClsSpeciallty(DtoSpecialltyReadUpdate specialltyReadUpdate, enMode mode)
        {
            this.Mode = mode;
            this.dtoSpecialltyReadUpdate = specialltyReadUpdate;
        }
        public ClsSpeciallty(DTOSpecialltyAdd specialltyadd, enMode mode)
        {
            this.Mode = mode;
            this.dTOSpecialltyadd = specialltyadd;
        }
        public static List<DtoSpecialltyReadUpdate> GetAllSpecialties()
        {
           return ClsDataAccessSpeciallty.GetAllSpecialties();
        }
        public static ClsSpeciallty GetSpecialtyById(int id)
        {
            var res = ClsDataAccessSpeciallty.GetSpecialtyById(id);
            if (res == null)
                return null;
            return new ClsSpeciallty(res, enMode.update);
        }
        public bool DeleteSpecialty()
        {
            return ClsDataAccessSpeciallty.DeleteSpecialty(this.Id);
        }
        private bool Update()
        {
            return ClsDataAccessSpeciallty.UpdateSpecialty(this.dtoSpecialltyReadUpdate);
        }
        private bool Add()
        {
            this.Id = ClsDataAccessSpeciallty.AddSpecialty(this.dTOSpecialltyadd);
            return (this.Id > 0);
        }
        public bool Save()
        {
            switch
                (this.Mode)
            {
                case enMode.update:
                    return Update();
                case enMode.add:
                    this.Mode = enMode.update;
                    return Add();
                default:
                    throw new Exception("Invalid Mode");
            }







        }
    }
}
