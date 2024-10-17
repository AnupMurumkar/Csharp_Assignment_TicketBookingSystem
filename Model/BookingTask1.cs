namespace TicketBookingSystem.Model

{
    public class BookingTask1
    {
        public int AvailableTickets { get; set; }

        public  BookingTask1(int availableTickets)
        {
            AvailableTickets = availableTickets;
        }
    }
}
