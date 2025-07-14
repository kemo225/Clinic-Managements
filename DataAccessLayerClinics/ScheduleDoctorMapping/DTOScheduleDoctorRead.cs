using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _DataAccessLayerClinics.ScheduleDoctorMapping
{
    public class DTOScheduleDoctorRead
{
        public int ID { get; set; }
        public string DoctorName { get; set; }
        public string Specialty { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
        public int DetectionCost { get; set; }
        public string Day {  get; set; }
       public DTOScheduleDoctorRead(int id, string doctorName, string specialty, TimeOnly startTime, TimeOnly endTime, int detectionCost, string day)
        {
            ID = id;
            DoctorName = doctorName;
            Specialty = specialty;
            StartTime = startTime;
            EndTime = endTime;
            DetectionCost = detectionCost;
            Day = day;
        }
    }
}
