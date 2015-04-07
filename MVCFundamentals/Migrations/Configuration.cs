using System.Collections.Generic;
using MVCFundamentals.Models;

namespace MVCFundamentals.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MVCFundamentals.Models.RateMyTrail>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "MVCFundamentals.Models.RateMyTrail";
        }

        protected override void Seed(MVCFundamentals.Models.RateMyTrail context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //


            context.Trails.AddOrUpdate(
                t => t.Name,
                new Trail
                {
                    Name = "Lebanon Hills", City = "Eagan", State = "MN", TrailReviews =
                    new List<TrailReview>
                    {
                        new TrailReview {Body = "Epic Minnesota Trail. A must ride!", Rating = 10}
                    }           
                },
                new Trail
                {
                    Name = "Murphy Hanrehan", City = "Savage", State = "MN"
                });

        }
    }
}
