using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eSya.ManagePharmacy.DO
{
    public class DO_DrugComposition
    {
        public int CompositionId { get; set; }
        public string DrugCompDesc { get; set; }
        public int FormulationID { get; set; }
        public string FormulationDesc { get; set; }
        public int ManufacturerId { get; set; }
        public string ManufacturerName { get; set; }
    }
}
