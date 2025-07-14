using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _DataAccessLayerClinics.Booking
{
    public class DTOBookingRead
{
        public int ID { get; set; } 
        public string DoctorName { get; set; }
        public string Speciallity { get; set; } 
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }  
        public int DetectionCost { get; set; }  
        public DateOnly CreatedAt { get; set; }
        public TimeOnly BookingTime { get; set; }
        public DateOnly BookingDate{ get; set; }
        public bool IsPaid { get; set; }    
        public string CreatedNurse { get; set; }    
        public DTOBookingRead(int ID,string Doctor,string Speciallity,string Name,int Age,string Gender,int DetectionCost,DateOnly CreatedAt,TimeOnly BookingTime,DateOnly Bookindate,bool Ispaid,string CreatedNurse)
        {
            this.ID = ID;
            this.DoctorName = Doctor;
            this.Name = Name;
            this.Age = Age;
            this.Gender = Gender;
            this.DetectionCost = DetectionCost;
            this.CreatedAt = CreatedAt;
            this.BookingTime = BookingTime;
            this.BookingDate = Bookindate;
            this.CreatedNurse = CreatedNurse;
            this.IsPaid = Ispaid;
            this.CreatedAt=CreatedAt;
            this.Speciallity = Speciallity;

        }


}
}
