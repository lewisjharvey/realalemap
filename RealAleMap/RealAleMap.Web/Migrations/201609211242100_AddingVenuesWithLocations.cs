namespace RealAleMap.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingVenuesWithLocations : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Venues",
                c => new
                    {
                        VenueId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Latitude = c.Double(nullable: false),
                        Longitude = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.VenueId);
            
            DropColumn("dbo.Breweries", "Latitude");
            DropColumn("dbo.Breweries", "Longitude");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Breweries", "Longitude", c => c.Double(nullable: false));
            AddColumn("dbo.Breweries", "Latitude", c => c.Double(nullable: false));
            DropTable("dbo.Venues");
        }
    }
}
