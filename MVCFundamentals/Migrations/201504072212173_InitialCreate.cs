namespace MVCFundamentals.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TrailReviews",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Rating = c.Int(nullable: false),
                        Body = c.String(),
                        TrailId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Trails", t => t.TrailId, cascadeDelete: true)
                .Index(t => t.TrailId);
            
            CreateTable(
                "dbo.Trails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        City = c.String(),
                        State = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TrailReviews", "TrailId", "dbo.Trails");
            DropIndex("dbo.TrailReviews", new[] { "TrailId" });
            DropTable("dbo.Trails");
            DropTable("dbo.TrailReviews");
        }
    }
}
