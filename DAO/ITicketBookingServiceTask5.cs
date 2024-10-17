using TicketBookingSystem.Model;

namespace TicketBookingSystem.DAO
{
    public interface ITicketBookingServiceTask5
    {
        EventTask5 create_event(string eventName, string date, string time, int totalSeats, decimal ticketPrice, string eventType, string venueName, string extraAttribute1, string extraAttribute2 , string extraAttribute3);
    }
}
