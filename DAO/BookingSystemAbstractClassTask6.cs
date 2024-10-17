using TicketBookingSystem.Model;

namespace TicketBookingSystem.DAO
{
    public abstract class BookingSystemAbstractClassTask6
    {
        public abstract void create_event(string eventName, string date, string time, int totalSeats, decimal ticketPrice, string eventType, string venueName, string extraAttribute1, string extraAttribute2);
        public abstract void book_tickets(string eventName, int numTickets);
        public abstract void cancel_tickets(string eventName, int numTickets);
        public abstract int get_available_seats(string eventName);
        public abstract void display_event_details(string eventName);
    }
}
