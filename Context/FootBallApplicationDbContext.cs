using System.Reflection;
using FootballWebApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace FootballWebApp.Context
{
    public class FootBallApplicationDbContext : DbContext
    {
        public FootBallApplicationDbContext( DbContextOptions<FootBallApplicationDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        public DbSet <Club> Clubs {get;set;}
        public DbSet <Player> Players {get;set;}
        public DbSet <Sponsorer> Sponsorers {get;set;}
        public DbSet <ClubSponsorer> ClubSponsorers {get;set;}
    }
}