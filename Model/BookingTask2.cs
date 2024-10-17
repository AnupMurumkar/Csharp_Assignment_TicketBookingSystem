namespace TicketBookingSystem.Model
{
    public class BookingTask2
    {
        public int AvailableTickets { get; set; }
        public string TicketType { get; set; } // Silver, Gold, Diamond

        // Constructor
        public BookingTask2(int availableTickets, string ticketType)
        {
            AvailableTickets = availableTickets;
            TicketType = ticketType;
        }
    }
}
