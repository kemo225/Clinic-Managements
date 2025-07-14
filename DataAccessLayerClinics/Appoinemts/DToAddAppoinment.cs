using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _DataAccessLayerClinics.Appoinemts
{
    public class DToAddAppoinment
{
        
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Day {  get; set; }
        public DToAddAppoinment(DateTime startTime, DateTime endTime, string day)
        {
            StartTime = startTime;
            EndTime = endTime;
            Day = day;
        }
    }
}
