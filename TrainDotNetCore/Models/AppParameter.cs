using System;
using System.Collections.Generic;

namespace TrainDotNetCore.Models
{
    public partial class AppParameter
    {
        public AppParameter()
        {
            ParameterDetail = new HashSet<ParameterDetail>();
        }

        public decimal Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string Status { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? Version { get; set; }
        public string Code { get; set; }
        public string ParameterDescription { get; set; }

        public virtual ICollection<ParameterDetail> ParameterDetail { get; set; }
    }
}