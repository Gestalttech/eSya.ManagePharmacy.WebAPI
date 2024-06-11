using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eSya.ManagePharmacy.DO
{
    public class DO_DrugBrands
    {
        public int Skuid { get; set; }
        public string Skutype { get; set; }
        public int Skucode { get; set; }
        public int CompositionID { get; set; }
        public int FormulationID { get; set; }
        public int TradeID { get; set; }
        public string TradeName { get; set; }
        public int PackSize { get; set; }
        public int Packing { get; set; }
        public string PackingDesc { get; set; }
        public int ManufacturerID { get; set; }
        public int ISDCode { get; set; }
        public string BarcodeID { get; set; }
        public bool ActiveStatus { get; set; }
        public string FormID { get; set; }
        public int UserID { get; set; }
        public DateTime CreatedOn { get; set; }
        public string TerminalID { get; set; }
        public int BusinessKey { get; set; }
        public string LocationDescription { get; set; }
        public List<DO_eSyaParameter> l_FormParameter { get; set; }
    }

    public class DO_eSyaParameter
    {
        public int ParameterID { get; set; }
        public bool ParmAction { get; set; }
        public decimal ParmValue { get; set; }
        public decimal ParmPerct { get; set; }
        public string? ParmDesc { get; set; }
        public bool ActiveStatus { get; set; }
    }
}
