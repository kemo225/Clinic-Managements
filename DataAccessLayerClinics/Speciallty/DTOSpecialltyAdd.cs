using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _DataAccessLayerClinics.Speciallty
{
    public class DTOSpecialltyAdd
{
        public string Name { get; set; }
        public DTOSpecialltyAdd( string name)
        {
            Name = name;
        }
    }
}
