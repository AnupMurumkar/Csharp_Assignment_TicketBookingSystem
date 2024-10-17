using TicketBookingSystem.model;
using TicketBookingSystem.Model;

namespace TicketBookingSystem.DAO
{
    public interface IBookingSystemServiceProviderTask11
    {
        decimal CalculateBookingCost(int numTickets, decimal ticketPrice);
        BookingTask11 BookTickets(string eventName, int numTickets, List<CustomerTask11> customers);
        void CancelBooking(int bookingId);
        BookingTask11 GetBookingDetails(int bookingId);
    }
}
