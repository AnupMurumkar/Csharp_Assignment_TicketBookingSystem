using System.Collections.Generic;
using TicketBookingSystem.Model;

namespace TicketBookingSystem.DAO
{
    public interface IEventServiceProviderTask10
    {
        EventTask10 CreateEvent(string eventName, DateTime date, TimeSpan time, VenueTask10 venue, int totalSeats, decimal ticketPrice, string eventType);
        List<EventTask10> GetEventDetails();
        int GetAvailableNoOfTickets(string eventName);
    }
}
