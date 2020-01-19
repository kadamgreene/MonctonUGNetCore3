using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MonctonUG.BlazorServer.Data
{
    public class WeatherDbContext : DbContext
    {
        public WeatherDbContext(DbContextOptions dbOptions) : base(dbOptions)
        {
        }

        public DbSet<WeatherForecast> WeatherForecasts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WeatherForecast>(x =>
            {
                x.HasKey(x => x.Date);
                x.HasData(
                    new WeatherForecast { Date = DateTime.Now, Summary = "Cold", TemperatureC = -10 },
                    new WeatherForecast { Date = DateTime.Now.AddDays(1), Summary = "Warm", TemperatureC = 25 },
                    new WeatherForecast { Date = DateTime.Now.AddDays(2), Summary = "Unbearably hot", TemperatureC = 40 },
                    new WeatherForecast { Date = DateTime.Now.AddDays(3), Summary = "Deathly cold", TemperatureC = -60 }
                );
            });
        }
    }
}
