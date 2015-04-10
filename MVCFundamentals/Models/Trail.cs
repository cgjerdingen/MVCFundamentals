using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Web;

namespace MVCFundamentals.Models
{
    public class Trail
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public virtual ICollection<TrailReview> TrailReviews { get; set; }
    }
}