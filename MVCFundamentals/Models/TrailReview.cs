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
        [Range(0,10)]
        [Required]
        public int Rating { get; set; }
        [Required]
        [StringLength(1024)]
        [Display(Name="Your Review")]
        public string Body { get; set; }

        public int TrailId { get; set; }

    }
}