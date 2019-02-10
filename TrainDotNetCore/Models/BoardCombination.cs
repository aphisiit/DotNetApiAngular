using System;
using System.Collections.Generic;

namespace TrainDotNetCore.Models
{
    public partial class BoardCombination
    {
        public BoardCombination()
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
        public string FlagActive { get; set; }
        public double? Price { get; set; }
        public int? TotalLayer { get; set; }
        public double? TotalWeight { get; set; }
        public decimal? HighValueAdded { get; set; }
        public decimal? Plant { get; set; }
        public decimal? PsmCluster { get; set; }
        public string ExternalCode { get; set; }
        public string RemarkFluteCode { get; set; }

        public virtual ICollection<Item> Item { get; set; }
    }
}