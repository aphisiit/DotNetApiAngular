using System;
using System.Collections.Generic;

namespace TrainDotNetCore.Models
{
    public partial class Flute
    {
        public Flute()
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
        public int? GlueTab { get; set; }
        public double? OdThickness { get; set; }
        public double? TakeupRatio { get; set; }
        public double? TakeupRatio1 { get; set; }
        public double? TakeupRatio2 { get; set; }
        public double? Thickness { get; set; }
        public int? Variablea { get; set; }
        public int? Variabled { get; set; }
        public double? Variablek { get; set; }
        public int? Variables { get; set; }
        public int? Wall { get; set; }
        public decimal? HighValueAdded { get; set; }
        public decimal? Plant { get; set; }
        public decimal? PsmCluster { get; set; }
        public int? PaperPerPalletDefault { get; set; }
        public int? BoxPerBundleDefault { get; set; }
        public int? LayerPerPalletDefault { get; set; }

        public virtual ICollection<Item> Item { get; set; }
    }
}