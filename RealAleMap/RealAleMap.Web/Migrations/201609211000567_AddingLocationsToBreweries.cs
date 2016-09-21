namespace RealAleMap.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingLocationsToBreweries : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Breweries", "Latitude", c => c.Double(nullable: false));
            AddColumn("dbo.Breweries", "Longitude", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Breweries", "Longitude");
            DropColumn("dbo.Breweries", "Latitude");
        }
    }
}
