using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Malacar.Models
{
    public class CarContext : DbContext
    {
        public CarContext(DbContextOptions<CarContext> options):base(options)
        {

        }

        public DbSet<Car> Cars { get; set; }

        public DbSet<Station> Stations { get; set; }

    }
}
