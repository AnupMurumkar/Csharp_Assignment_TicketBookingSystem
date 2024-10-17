namespace TicketBookingSystem.Model
{
    public class BookingTask3
    {
        public int AvailableTickets { get; set; }
        public string TicketType { get; set; }

        // Constructor
        public BookingTask3(int availableTickets, string ticketType)
        {
            AvailableTickets = availableTickets;
            TicketType = ticketType;
        }
    }
}
