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
        public DbSet<Air> Air { get; set; }
        public DbSet<Air> Averages { get; set; }
    }
}
