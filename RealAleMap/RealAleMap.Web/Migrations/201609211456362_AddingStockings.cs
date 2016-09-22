namespace RealAleMap.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingStockings : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Stocks",
                c => new
                    {
                        StockId = c.Long(nullable: false, identity: true),
                        VenueId = c.Int(nullable: false),
                        BeerId = c.Int(nullable: false),
                        ReportedTime = c.DateTime(nullable: false),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.StockId)
                .ForeignKey("dbo.Beers", t => t.BeerId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.Venues", t => t.VenueId, cascadeDelete: true)
                .Index(t => t.VenueId)
                .Index(t => t.BeerId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Stocks", "VenueId", "dbo.Venues");
            DropForeignKey("dbo.Stocks", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Stocks", "BeerId", "dbo.Beers");
            DropIndex("dbo.Stocks", new[] { "UserId" });
            DropIndex("dbo.Stocks", new[] { "BeerId" });
            DropIndex("dbo.Stocks", new[] { "VenueId" });
            DropTable("dbo.Stocks");
        }
    }
}
