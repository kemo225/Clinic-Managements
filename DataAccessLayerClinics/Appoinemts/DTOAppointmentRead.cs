using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _DataAccessLayerClinics.Appoinemts
{
    public class DTOAppointmentRead
{
        public int ID { get; set; } 
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Day {  get; set; }
        public DTOAppointmentRead(int ID,DateTime startTime, DateTime endTime, string Day)
        {
            this.ID = ID;
            StartTime = startTime;
            EndTime = endTime;
            this.Day = Day;
        }
    }
}
