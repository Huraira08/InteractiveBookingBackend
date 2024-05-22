using InteractiveBookingBackend.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteractiveBookingBackend.Data.Context
{
    public class InteractiveBookingContext : DbContext
    {
        public InteractiveBookingContext(DbContextOptions<InteractiveBookingContext> options)
            :base(options)
        {
            
        }

        public DbSet<Booking> Bookings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(InteractiveBookingContext).Assembly);
        }
    }
}
