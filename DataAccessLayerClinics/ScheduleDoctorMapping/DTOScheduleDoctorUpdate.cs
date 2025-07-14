using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _DataAccessLayerClinics.ScheduleDoctorMapping
{
    public class DTOScheduleDoctorUpdate
{
        public int ID { get; set; }
        public int DetectionCost { get; set; }
        public DTOScheduleDoctorUpdate(int id, int detectionCost)
        {
            ID = id;
            DetectionCost = detectionCost;
        }
    }
}
