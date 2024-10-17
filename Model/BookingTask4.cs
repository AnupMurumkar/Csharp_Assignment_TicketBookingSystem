using TicketBookingSystem.Model;

namespace TicketBookingSystem.Model
{
    public class BookingTask4
    {
        public int BookingId { get; set; }
        public EventTask4 Event { get; set; }
        public int NumTickets { get; set; }
        public decimal TotalCost { get; set; }
        public DateTime BookingDate { get; set; }

        // Constructor
        public BookingTask4(int bookingId, EventTask4 @event, int numTickets, decimal totalCost, DateTime bookingDate)
        {
            BookingId = bookingId;
            Event = @event;
            NumTickets = numTickets;
            TotalCost = totalCost;
            BookingDate = bookingDate;
        }
    }
}
