using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _DataAccessLayerClinics.ScheduleDoctorMapping
{
    public class DTOScheduleDoctorAdd
{
        public int DoctorID { get; set; }
        public int AppointmentID { get; set; }
        public int DetectionCost { get; set; }
        public DTOScheduleDoctorAdd( int doctorId, int doctorScheduleId, int detectionCost)
        {
            DoctorID = doctorId;
            AppointmentID = doctorScheduleId;
            DetectionCost = detectionCost;
        }
    }
}
