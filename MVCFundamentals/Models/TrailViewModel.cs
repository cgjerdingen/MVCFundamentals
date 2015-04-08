using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCFundamentals.Models
{
    public class TrailViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int CountOfReviews { get; set; }
        public ICollection<TrailReview> TrailReviews { get; set; }
    }
}