﻿using System;
using System.Collections.Generic;

namespace eSya.ManagePharmacy.DL.Entities
{
    public partial class GtEskucd
    {
        public int Skuid { get; set; }
        public string Skutype { get; set; } = null!;
        public int Skucode { get; set; }
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
