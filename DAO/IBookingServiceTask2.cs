using TicketBookingSystem.Model;

namespace TicketBookingSystem.DAO
{
    public interface IBookingServiceTask2
    {
        string BookTickets(BookingTask2 booking, int noOfTickets);
    }
}
