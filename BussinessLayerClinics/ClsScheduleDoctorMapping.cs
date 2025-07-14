using _DataAccessLayerClinics.ScheduleDoctorMapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _BussinessLayerClinics
{
    public class ClsScheduleDoctorMapping
    {
        public int ID { get; set; }
        public string DoctorName { get; set; }
        public string Specialty { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
        public int DetectionCost { get; set; }
        public int DoctorID { get; set; }
        public int AppointmentID { get; set; }
        public string Day { get; set; }
        public DTOScheduleDoctorUpdate dtoScheduleDoctorUpdate
        {
            get
            {
                return new DTOScheduleDoctorUpdate(this.ID, this.DetectionCost);
            }
            set
            {
                this.ID = value.ID;
                this.DetectionCost = value.DetectionCost;
            }
        }
        public DTOScheduleDoctorAdd dtoScheduleDoctorAdd
        {
            get
            {
                return new DTOScheduleDoctorAdd(this.DoctorID, this.AppointmentID, this.DetectionCost);
            }
            set
            {
                this.DoctorID = value.DoctorID;
                this.AppointmentID = value.AppointmentID;
                this.DetectionCost = value.DetectionCost;
            }
        }
        public DTOScheduleDoctorRead dtoScheduleDoctorRead
        {
            get
            {
                return new DTOScheduleDoctorRead(this.ID, this.DoctorName, this.Specialty, this.StartTime, this.EndTime, this.DetectionCost,this.Day);
            }
            set
            {
                this.ID = value.ID;
                this.DoctorName = value.DoctorName;
                this.Specialty = value.Specialty;
                this.StartTime = value.StartTime;
                this.EndTime = value.EndTime;
                this.DetectionCost = value.DetectionCost;
                this.Day = value.Day;
            }
        }
        public enum enMode
        {
            update,
            add

        }
        public enMode Mode { get; set; }
        public ClsScheduleDoctorMapping(DTOScheduleDoctorRead scheduleDoctorRead, enMode mode)
        {
            this.Mode = mode;
            this.dtoScheduleDoctorRead = scheduleDoctorRead;
        }
        public ClsScheduleDoctorMapping(DTOScheduleDoctorAdd scheduleDoctorAdd, enMode mode)
        {
            this.Mode = mode;
            this.dtoScheduleDoctorAdd = scheduleDoctorAdd;
        }
        public static List<DTOScheduleDoctorRead> GetAllScheduleDoctors()
        {
            return ClsDataAccessScheduleDoctorMapping.GetAllScheduleDoctorMappings();
        }
        public static ClsScheduleDoctorMapping GetScheduleBYID(int iD)
        {
            var res = ClsDataAccessScheduleDoctorMapping.GetScheduleDoctorMappingByID(iD);
            if (res == null)
            {
                return null;
            }
            return new ClsScheduleDoctorMapping(res, enMode.update);


        }
        public static List<DTOScheduleDoctorRead> GetScheduleForDoctorID(int DoctorID)
        {
           return ClsDataAccessScheduleDoctorMapping.GetScheduleDoctorMappingByDoctorID(DoctorID);
        }
        public static ClsScheduleDoctorMapping GetScheduleDoctorByPhoneNumber(string phone)
        {
            var res = ClsDataAccessScheduleDoctorMapping.GetScheduleDoctorMappingByDoctorNumber(phone);
            if (res == null)
            {
                return null;
            }
            return new ClsScheduleDoctorMapping(res, enMode.update);
        }
        public static bool DeleteScheduleDoctorByID(int ID)
        {
            return ClsDataAccessScheduleDoctorMapping.DeleteScheduleDoctorMapping(ID);
        }
        public bool UpdateScheduleDoctor()
        {
            return ClsDataAccessScheduleDoctorMapping.UpdateScheduleDoctorMapping(this.dtoScheduleDoctorUpdate);
        }
        public bool AddScheduleDoctor()
        {
            this.ID = ClsDataAccessScheduleDoctorMapping.AddScheduleDoctorMapping(this.dtoScheduleDoctorAdd);
            return (this.ID > 0);
        }
        public bool Save()
        {
            switch
                (this.Mode)
            {
                case enMode.update:
                    return UpdateScheduleDoctor();
                case enMode.add:
                    this.Mode = enMode.add;
                    return AddScheduleDoctor();
                default:
                    throw new Exception("Invalid Mode");
            }







        }
    }

}
