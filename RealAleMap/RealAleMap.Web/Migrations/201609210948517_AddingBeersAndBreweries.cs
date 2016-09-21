namespace RealAleMap.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingBeersAndBreweries : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Beers",
                c => new
                    {
                        BeerId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        BreweryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BeerId)
                .ForeignKey("dbo.Breweries", t => t.BreweryId, cascadeDelete: true)
                .Index(t => t.BreweryId);
            
            AlterColumn("dbo.Breweries", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Breweries", "Email", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Beers", "BreweryId", "dbo.Breweries");
            DropIndex("dbo.Beers", new[] { "BreweryId" });
            AlterColumn("dbo.Breweries", "Email", c => c.String());
            AlterColumn("dbo.Breweries", "Name", c => c.String());
            DropTable("dbo.Beers");
        }
    }
}
