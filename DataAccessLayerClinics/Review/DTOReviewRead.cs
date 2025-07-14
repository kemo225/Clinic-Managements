using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _DataAccessLayerClinics.Review
{
    public class DTOReviewRead
{
        public int ID { get; set; }
        public string PatientName { get; set; }
        public int Age {  get; set; }
        public string Notes {  get; set; }  
        public string DoctorName {  get; set; }
        public string specialty {  get; set; }
        public DateTime ReviewDate { get; set; } 
        public DateOnly BookingDate { get; set; }   
        public TimeOnly BookingTime { get; set; }
     public    DTOReviewRead(int ID,string PatientName,int Age,string Notes,string DoctorName,string Specialty,DateTime ReviewDate,DateOnly BookingDate,TimeOnly BookingTime)
        {
            this.ID = ID;
            this.PatientName = PatientName;
            this.Age = Age;
            this.Notes = Notes;
            this.DoctorName = DoctorName;
            this.specialty= Specialty;
            this.ReviewDate= ReviewDate;
            this.BookingDate = BookingDate;
       

        }
}
}
