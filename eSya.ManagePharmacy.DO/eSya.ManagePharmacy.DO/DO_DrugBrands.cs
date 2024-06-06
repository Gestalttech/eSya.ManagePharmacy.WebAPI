﻿using System;
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
        public int ManufacturerID { get; set; }
        public int ISDCode { get; set; }
        public string BarcodeID { get; set; }
        public bool ActiveStatus { get; set; }
        public string FormID { get; set; }
        public int UserID { get; set; }
        public DateTime CreatedOn { get; set; }
        public string TerminalID { get; set; }
    }
}