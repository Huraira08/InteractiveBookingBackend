using InteractiveBookingBackend.Data.Context;
using InteractiveBookingBackend.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteractiveBookingBackend.Data.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly InteractiveBookingContext _context;

        public BookingRepository(InteractiveBookingContext context)
        {
            _context = context;
        }

        public async Task<List<Booking>> GetAsync()
        {
            List<Booking> bookings = await _context.Bookings.ToListAsync();
            return bookings;
        }

        public async Task<Booking?> GetAsync(int id)
        {
            Booking? booking = await _context.Bookings.FindAsync(id);
            return booking;
        }

        public async Task<List<Booking>> GetByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            List<Booking> bookings = await _context.Bookings
                .Where(b => (
                (b.StartDate.Date >= startDate.Date && b.StartDate.Date <= endDate.Date)
                || (b.EndDate.Date >= startDate.Date && b.EndDate.Date <= endDate.Date)
                || (b.StartDate.Date <= startDate.Date && b.EndDate.Date >= endDate.Date)
                ) // end of lambda expression
                ).ToListAsync();
            return bookings;
        }
        public async Task<int> AddAsync(Booking newBooking)
        {
            if(newBooking.Id == Guid.Empty)
            {
                _context.Bookings.Add(newBooking);
                int rowsCount = await _context.SaveChangesAsync();
                return rowsCount;
            }
            return 0;
        }
    }
}
