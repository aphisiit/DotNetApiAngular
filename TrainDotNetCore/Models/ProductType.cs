using System;
using System.Collections.Generic;

namespace TrainDotNetCore.Models
{
    public partial class ProductType
    {
        public ProductType()
        {
            Item = new HashSet<Item>();
            ProductSubType = new HashSet<ProductSubType>();
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
        public string DrawingFileName { get; set; }
        public string DrawingRealFileName { get; set; }
        public string FlagActive { get; set; }
        public string FlagCorrugatedPartition { get; set; }
        public string FlagSpecialProductType { get; set; }
        public string HierachyLevel2 { get; set; }
        public int? LeadTime { get; set; }
        public string MaterialTypeDesc { get; set; }
        public string ShortName { get; set; }
        public string UploadTime { get; set; }
        public string ProductCodeSuffix { get; set; }
        public decimal? HighValueAdded { get; set; }
        public decimal? Plant { get; set; }
        public decimal? ProductGroupType { get; set; }
        public decimal? PsmCluster { get; set; }
        public decimal? PlanProcess { get; set; }
        public int? Sequence { get; set; }

        public virtual ICollection<Item> Item { get; set; }
        public virtual ICollection<ProductSubType> ProductSubType { get; set; }
    }
}