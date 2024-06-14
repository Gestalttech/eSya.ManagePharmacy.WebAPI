using System;
using System.Collections.Generic;

namespace eSya.ManagePharmacy.DL.Entities
{
    public partial class GtEphdml
    {
        public int BusinessKey { get; set; }
        public int TradeId { get; set; }
        public int ManufacturerId { get; set; }
        public DateTime EffectiveFrom { get; set; }
        public decimal PurchaseRate { get; set; }
        public decimal Mrp { get; set; }
        public DateTime? LastMrpdate { get; set; }
        public DateTime? EffectiveTill { get; set; }
        public bool ActiveStatus { get; set; }
        public string FormId { get; set; } = null!;
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedTerminal { get; set; } = null!;
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string? ModifiedTerminal { get; set; }
    }
}
