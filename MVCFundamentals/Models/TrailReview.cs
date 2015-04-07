using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCFundamentals.Models
{
    public class TrailReview
    {
        public int Id { get; set; }
        public int Rating { get; set; }
        public string Body { get; set; }
        public int TrailId { get; set; }

    }
}