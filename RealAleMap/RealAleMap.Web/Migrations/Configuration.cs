namespace RealAleMap.Web.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using RealAleMap.Web.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    internal sealed class Configuration : DbMigrationsConfiguration<RealAleMap.Web.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(RealAleMap.Web.Models.ApplicationDbContext context)
        {
            this.AddUserAndRole(context);

            context.Breweries.AddOrUpdate(p => p.Name,
                new Brewery()
                {
                    Name = "Woodfordes",
                    Email = "me@lewisjharvey.co.uk"
                }
            );

            context.SaveChanges();

            context.Beers.AddOrUpdate(p => p.Name,
                new Beer()
                {
                    BreweryId = context.Breweries.Single(b => b.Name.Equals("Woodfordes")).BreweryId,
                    Name = "Wherry"
                }
            );

            context.SaveChanges();

            context.Venues.AddOrUpdate(p => p.Name,
                new Venue()
                {
                    Name = "The Crown Lodge",
                    Email = "me@lewisjharvey.co.uk",
                    Latitude = 52.60945,
                    Longitude = 0.24295
                }
            );

            context.SaveChanges();

            context.Stocks.AddOrUpdate(p => p.BeerId,
                new Stock()
                {
                    BeerId = context.Beers.Single(b => b.Name.Equals("Wherry")).BeerId,
                    UserId = context.Users.Single(u => u.UserName.Equals("me@lewisjharvey.co.uk")).Id,
                    VenueId = context.Venues.Single(v => v.Name.Equals("The Crown Lodge")).VenueId,
                    ReportedTime = DateTime.Now
                }
            );
        }

        /// <summary>
        /// Adds the user and role.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        bool AddUserAndRole(Models.ApplicationDbContext context)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var identityResult = roleManager.Create(new IdentityRole("canEdit"));
            var um = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var user = new ApplicationUser()
            {
                UserName = "me@lewisjharvey.co.uk"
            };

            identityResult = um.Create(user, "F!tzroyrobin1");

            if (identityResult.Succeeded == false)
                return identityResult.Succeeded;

            identityResult = um.AddToRole(user.Id, "canEdit");
            return identityResult.Succeeded;
        }
    }
}
