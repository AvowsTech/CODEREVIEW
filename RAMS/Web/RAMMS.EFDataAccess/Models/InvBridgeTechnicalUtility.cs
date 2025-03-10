﻿using System;
using System.Collections.Generic;

namespace RAMMS.EFDataAccess.Models
{
    public partial class InvBridgeTechnicalUtility
    {
        public int Pk { get; set; }
        public int InvBridgeTechnicalPk { get; set; }
        public string UtilityName { get; set; }
        public string Description { get; set; }
        public double? Quantity { get; set; }
        public DateTime Created { get; set; }
        public string CreatedBy { get; set; }
        public DateTime Updated { get; set; }
        public string UpdatedBy { get; set; }
    }
}
