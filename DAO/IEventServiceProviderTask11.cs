
using TicketBookingSystem.Model;

namespace TicketBookingSystem.DAO
{
    public interface IEventServiceProviderTask11
    {
        EventTask11 CreateEvent(string eventName, DateTime date, TimeSpan time, VenueTask11 venue, int totalSeats, decimal ticketPrice, string eventType);
        List<EventTask11> GetEventDetails();
        int GetAvailableNoOfTickets(string eventName);
    }
}
