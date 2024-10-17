using TicketBookingSystem.Model;

namespace TicketBookingSystem.DAO
{
    public interface IEventServiceTask4
    {
        void BookTickets(EventTask4 eventTask, int numTickets);
        void CancelBooking(EventTask4 eventTask, int numTickets);
        decimal CalculateTotalRevenue(EventTask4 eventTask);
        int GetBookedNoOfTickets(EventTask4 eventTask);
        void DisplayEventDetails(EventTask4 eventTask);
    }
}
