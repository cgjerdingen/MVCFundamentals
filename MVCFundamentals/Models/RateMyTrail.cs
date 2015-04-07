using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVCFundamentals.Models
{
    public class RateMyTrail : DbContext
    {
        public RateMyTrail() : base("name=DefaultConnection")
        {
        }

        public DbSet<Trail> Trails { get; set; }
        public DbSet<TrailReview> TrailReviews { get; set; }

    }
}