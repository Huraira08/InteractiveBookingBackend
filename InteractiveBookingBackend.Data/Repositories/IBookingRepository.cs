using InteractiveBookingBackend.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteractiveBookingBackend.Data.Repositories
{
    public interface IBookingRepository
    {
        public Task<List<Booking>> GetAsync();
        public Task<Booking?> GetAsync(int id);
        public Task<List<Booking>> GetByDateRangeAsync(DateTime startDate, DateTime endDate);
        public Task<int> AddAsync(Booking booking);

    }
}
