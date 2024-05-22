using Microsoft.AspNetCore.SignalR;

namespace InteractiveBookingBackend.Web.Utility
{
    public class BookingUpdateHub: Hub
    {
        public async Task SendMessage(string message)
        {
            await Clients.All.SendAsync("update", message);
        }
    }
}
