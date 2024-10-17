using TicketBookingSystem.Model;

namespace TicketBookingSystem.DAO
{
    public class BookingServiceImplTask4 : IBookingServiceTask4
    {
        public decimal CalculateBookingCost(BookingTask4 booking)
        {
            return booking.NumTickets * booking.Event.TicketPrice;
        }

        public void BookTickets(BookingTask4 booking, int numTickets)
        {
            booking.Event.AvailableSeats -= numTickets;
            booking.TotalCost = CalculateBookingCost(booking);
            booking.NumTickets = numTickets;
        }

        public void CancelBooking(BookingTask4 booking, int numTickets)
        {
            booking.Event.AvailableSeats += numTickets;
        }

        public int GetAvailableNoOfTickets(BookingTask4 booking)
        {
            return booking.Event.AvailableSeats;
        }

        public void GetEventDetails(BookingTask4 booking)
        {
            Console.WriteLine($"Event: {booking.Event.EventName}, Available Tickets: {booking.Event.AvailableSeats}, Total Seats: {booking.Event.TotalSeats}, Event Type: {booking.Event.EventType}");
        }
    }
}
