using System;
using System.Collections.Generic;

namespace TrainDotNetCore.Models
{
    public partial class PrintingTechnology
    {
        public PrintingTechnology()
        {
            Item = new HashSet<Item>();
        }

        public decimal Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string Status { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? Version { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string FlagActive { get; set; }
        public string FlagPrePrint { get; set; }
        public decimal? HighValueAdded { get; set; }
        public string FlagDefault { get; set; }

        public virtual ICollection<Item> Item { get; set; }
    }
}