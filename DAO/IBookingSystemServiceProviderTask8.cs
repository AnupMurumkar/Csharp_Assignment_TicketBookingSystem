using TicketBookingSystem.Model;

namespace TicketBookingSystem.DAO
{
    public interface IBookingSystemServiceProviderTask8
    {
        decimal calculate_booking_cost(int numTickets, decimal ticketPrice);
        void book_tickets(string eventName, int numTickets, CustomerTask8[] customers);
        void cancel_booking(int bookingId);
        BookingTask8 get_booking_details(int bookingId);
    }
}
