using System;
using System.Collections.Generic;

namespace eSya.ManagePharmacy.DL.Entities
{
    public partial class GtEphmdb
    {
        public GtEphmdb()
        {
            GtEphdpas = new HashSet<GtEphdpa>();
        }
        public int CompositionId { get; set; }
        public int FormulationId { get; set; }
        public int TradeId { get; set; }
        public string TradeName { get; set; } = null!;
        public int PackSize { get; set; }
        public int Packing { get; set; }
        public int ManufacturerId { get; set; }
        public int Isdcode { get; set; }
        public string? BarcodeId { get; set; }
        public bool ActiveStatus { get; set; }
        public string FormId { get; set; } = null!;
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedTerminal { get; set; } = null!;
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string? ModifiedTerminal { get; set; }
        public virtual ICollection<GtEphdpa> GtEphdpas { get; set; }
    }
}
