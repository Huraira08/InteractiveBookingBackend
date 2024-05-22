using InteractiveBookingBackend.Data.Repositories;
using InteractiveBookingBackend.Model;
using InteractiveBookingBackend.Web.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace InteractiveBookingBackend.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IHubContext<BookingUpdateHub> _updateHub;

        public BookingsController(IBookingRepository bookingRepository,
            IHubContext<BookingUpdateHub> updateContext)
        {
            _bookingRepository = bookingRepository;
            _updateHub = updateContext;
        }

        [HttpGet]
        public async Task<List<Booking>> Get()
        {
            List<Booking> bookings = await _bookingRepository.GetAsync();
            return bookings;
        }

        [HttpGet("{id}")]
        public async Task<Booking?> Get(int id)
        {
            Booking? booking = await _bookingRepository.GetAsync(id);
            return booking;
        }

        [HttpGet("{startDate}/{endDate}")]
        public async Task<List<Booking>> Get(DateTime startDate, DateTime endDate)
        {
            List<Booking> bookings = await _bookingRepository.GetByDateRangeAsync(startDate, endDate);
            return bookings;
        }

        [HttpPost]
        public async Task<int> AddBooking(Booking newBooking)
        {
            if(newBooking.UserID == null)
            {
                newBooking.UserID = Guid.NewGuid();
            }
            int rowsAffected = await _bookingRepository.AddAsync(booking: newBooking);
            if(rowsAffected > 0)
            {
                await _updateHub.Clients.All.SendAsync("update", "Booking update is here");
            }
            return rowsAffected;
        }
    }
}
