using InteractiveBookingBackend.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteractiveBookingBackend.Data.EntityConfiguration
{
    internal class BookingEntityConfiguration : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder.ToTable(nameof(Booking));
            builder.HasKey(b => b.Id);
            builder.Property(b => b.StartDate).IsRequired();
            builder.Property(b => b.EndDate).IsRequired();
            builder.Property(b => b.UserID).IsRequired();
            builder.Property(b => b.Price);

            builder.HasData(
                new Booking { Id = Guid.NewGuid(), 
                    StartDate = new DateTime(2024, 05, 25),
                    EndDate = new DateTime(2024, 05, 27),
                    UserID = Guid.NewGuid(),
                    Price = 1000
                },

                new Booking
                {
                    Id = Guid.NewGuid(),
                    StartDate = new DateTime(2024, 05, 27),
                    EndDate = new DateTime(2024, 05, 29),
                    UserID = Guid.NewGuid(),
                    Price = 2000
                },

                new Booking
                {
                    Id = Guid.NewGuid(),
                    StartDate = new DateTime(2024, 05, 26),
                    EndDate = new DateTime(2024, 05, 31),
                    UserID = Guid.NewGuid(),
                    Price = 1000
                },
                new Booking
                {
                    Id = Guid.NewGuid(),
                    StartDate = new DateTime(2024, 06, 01),
                    EndDate = new DateTime(2024, 06, 04),
                    UserID = Guid.NewGuid(),
                    Price = 1000
                }
                );
        }
    }
}
