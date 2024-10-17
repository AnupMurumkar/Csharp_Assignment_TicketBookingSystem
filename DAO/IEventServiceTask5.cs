using TicketBookingSystem.Model;

namespace TicketBookingSystem.DAO
{
    public interface IEventServiceTask5
    {
        void display_event_details(EventTask5 eventObj);
        decimal book_tickets(EventTask5 eventObj, int numTickets);
        void cancel_tickets(EventTask5 eventObj, int numTickets);
    }
}
