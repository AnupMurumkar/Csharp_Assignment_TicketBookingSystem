using TicketBookingSystem.Model;

namespace TicketBookingSystem.DAO
{
    public interface IBookingServiceTask4
    {
        decimal CalculateBookingCost(BookingTask4 booking);
        void BookTickets(BookingTask4 booking, int numTickets);
        void CancelBooking(BookingTask4 booking, int numTickets);
        int GetAvailableNoOfTickets(BookingTask4 booking);
        void GetEventDetails(BookingTask4 booking);
    }
}
