using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace SacramentMeetingPlanner.Models
{
    public class PlannerModel : DbContext
    {

        public DbSet<Planner> Planners { get; set; }
        public DbSet<Speaker> Speaker { get; set; }

        public PlannerModel(DbContextOptions<PlannerModel> context) : base(context)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Planner>()
                        .HasMany(p => p.Speakers)
                        .WithOne(e => e.Planner);

        }
    }
}
