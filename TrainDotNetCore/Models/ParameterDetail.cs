using System;
using System.Collections.Generic;

namespace TrainDotNetCore.Models
{
    public partial class ParameterDetail
    {
        public decimal Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string Status { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? Version { get; set; }
        public string Code { get; set; }
        public string CommentParameterValue1 { get; set; }
        public string CommentParameterValue10 { get; set; }
        public string CommentParameterValue2 { get; set; }
        public string CommentParameterValue3 { get; set; }
        public string CommentParameterValue4 { get; set; }
        public string CommentParameterValue5 { get; set; }
        public string CommentParameterValue6 { get; set; }
        public string CommentParameterValue7 { get; set; }
        public string CommentParameterValue8 { get; set; }
        public string CommentParameterValue9 { get; set; }
        public string ParameterDescription { get; set; }
        public string ParameterValue1 { get; set; }
        public string ParameterValue10 { get; set; }
        public string ParameterValue2 { get; set; }
        public string ParameterValue3 { get; set; }
        public string ParameterValue4 { get; set; }
        public string ParameterValue5 { get; set; }
        public string ParameterValue6 { get; set; }
        public string ParameterValue7 { get; set; }
        public string ParameterValue8 { get; set; }
        public string ParameterValue9 { get; set; }
        public decimal? AppParameter { get; set; }

        public virtual AppParameter AppParameterNavigation { get; set; }
    }
}