using _DataAccessLayerClinics.Appoinemts;
using _DataAccessLayerClinics.Booking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _BussinessLayerClinics
{
    public class ClsAppoinement
{
        public int Id { get; set; } 
        public DateTime Starttime { get; set; }
        public DateTime Endtime { get; set; }
        public string Day { get; set; }
        public DToAddAppoinment dToAddAppoinment{
            get
            {
                return new DToAddAppoinment(this.Starttime,this.Endtime,this.Day);
            }
            set
            {
                this.Starttime = value.StartTime;
                this.Endtime = value.EndTime;
                this.Day = value.Day;


            }
            }
        public DTOAppointmentRead dToAppoinmentRead
        {
            get
            {
                return new DTOAppointmentRead(this.Id,this.Starttime, this.Endtime,this.Day);
            }
            set
            {
                this.Id = value.ID;
                this.Starttime = value.StartTime;
                this.Endtime = value.EndTime;
                this.Day = value.Day;


            }
        }
        public enum enMode { Add,Update}
        public enMode Mode { get; set; }
        public ClsAppoinement(DToAddAppoinment dToAddAppoinment,enMode Mode)
        {
            this.dToAddAppoinment
                 = dToAddAppoinment;
            this.Mode = Mode;
        }
        public ClsAppoinement(DTOAppointmentRead dToAppoinment, enMode Mode )
        {
            this.dToAppoinmentRead = dToAppoinment;
            this.Mode = Mode;
        }
        public static ClsAppoinement GetAppointmenrByID(int ID)
        {
            DTOAppointmentRead DtoAppointUpdate = ClsDataAccessAppoinemt.GetAppointmentById(ID);
            if (DtoAppointUpdate == null)
            {
                return null;
            }
            return new ClsAppoinement(DtoAppointUpdate, enMode.Update);


        }
        public static bool DeleteAppointment(int Id)
        {
            return ClsDataAccessAppoinemt.Deleteappintment(Id);
        }
        private bool Add()
        {
            this.Id=ClsDataAccessAppoinemt.AddAppoinment(dToAddAppoinment);
            return (this.Id>0);

        }
     
        public bool Save()
        {
            switch
                (this.Mode)
            {
          

                case enMode.Add:
                    this.Mode = enMode.Update;
                    return Add();
                default:
                    throw new Exception("Invalid Mode");
            }
        }
    }
}
