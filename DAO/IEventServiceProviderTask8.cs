using TicketBookingSystem.Model;

namespace TicketBookingSystem.DAO
{
    public interface IEventServiceProviderTask8
    {
        EventTask8 create_event(string eventName, string date, string time, int totalSeats, decimal ticketPrice, string eventType, VenueTask8 venue);
        EventTask8[] getEventDetails();
        int getAvailableNoOfTickets(string eventName);
    }
}
