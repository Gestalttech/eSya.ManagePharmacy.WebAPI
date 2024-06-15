using System;
using System.Collections.Generic;

namespace eSya.ManagePharmacy.DL.Entities
{
    public partial class GtEphdvl
    {
        public int BusinessKey { get; set; }
        public int TradeId { get; set; }
        public int VendorId { get; set; }
        public decimal MinimumSupplyQty { get; set; }
        public decimal BusinessSharePerc { get; set; }
        public string? PartNumber { get; set; }
        public string? PartDesc { get; set; }
        public decimal LastPurchaseRate { get; set; }
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
