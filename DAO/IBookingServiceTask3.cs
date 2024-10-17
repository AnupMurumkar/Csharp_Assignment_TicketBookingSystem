using TicketBookingSystem.Model;

namespace TicketBookingSystem.DAO
{
    public interface IBookingServiceTask3
    {
        string BookTickets(BookingTask3 booking, int noOfTickets);
    }
}
