using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCFundamentals.Models
{
    public class TrailReview
    {
        public int Id { get; set; }
        [Required]
        [Range(0,5)]
        public decimal Rating { get; set; }
        [Display(Name = "Your Review")]
        [StringLength(4000)]
        public string Body { get; set; }
        public int TrailId { get; set; }
        [Display(Name="Reviewer Name")]
        [DisplayFormat(NullDisplayText = "anonymous")]
        public string ReviewerName { get; set; }
    }
}