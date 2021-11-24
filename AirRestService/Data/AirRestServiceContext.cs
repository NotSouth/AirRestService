using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AirLibrary;

namespace AirRestService.Data
{
    public class AirRestServiceContext : DbContext
    {
        public AirRestServiceContext (DbContextOptions<AirRestServiceContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Air>().HasData(new Air
            {
                ID = 1,
                Temperature = "Bob",
                CO2 = "Ross",
                Humidity = "Drama"

            }, new Air
            {
                ID = 2,
                Temperature = "Bob2",
                CO2 = "Ross2",
                Humidity = "Drama2"
            });
        }
        public DbSet<Air> Air { get; set; }
    }
}
