using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DIS_Project.DataModels;
using DIS_Project.Models;

namespace DIS_Project.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<CrashRecord> CrashRecord { get; set; }
        public DbSet<RoadCharacter> RoadCharacter { get; set; }
        public DbSet<RoadCondition> RoadCondition { get; set; }
        public DbSet<RoadConfiguration> RoadConfiguration { get; set; }
        public DbSet<VehicleType> VehicleType { get; set; }
        public DbSet<WeatherCondition> WeatherCondition { get; set; }
        public DbSet<Contact> Contact { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed data for RoadCharacter
            modelBuilder.Entity<RoadCharacter>().HasData(SeedData.GetRoadCharacters());

            // Seed data for RoadCondition
            modelBuilder.Entity<RoadCondition>().HasData(SeedData.GetRoadConditions());

            // Seed data for RoadConfiguration
            modelBuilder.Entity<RoadConfiguration>().HasData(SeedData.GetRoadConfigurations());

            // Seed data for VehicleType
            modelBuilder.Entity<VehicleType>().HasData(SeedData.GetVehicleTypes());

            // Seed data for RoadCondition
            modelBuilder.Entity<WeatherCondition>().HasData(SeedData.GetWeatherConditions());
        }
    }
}
