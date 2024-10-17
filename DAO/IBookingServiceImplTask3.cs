using TicketBookingSystem.Model;

namespace TicketBookingSystem.DAO
{
    public class BookingServiceImplTask3 : IBookingServiceTask3
    {
        public string BookTickets(BookingTask3 booking, int noOfTickets)
        {
            decimal ticketPrice = 0;

            // Nested conditional logic to determine ticket price based on type
            if (booking.TicketType == "Silver")
            {
                ticketPrice = 500;  // Price for Silver ticket
            }
            else if (booking.TicketType == "Gold")
            {
                ticketPrice = 1000; // Price for Gold ticket
            }
            else if (booking.TicketType == "Diamond")
            {
                ticketPrice = 1500; // Price for Diamond ticket
            }
            else
            {
                return "Invalid ticket type!";
            }

            // Check if the requested number of tickets is available
            if (noOfTickets <= booking.AvailableTickets)
            {
                decimal totalCost = ticketPrice * noOfTickets;
                booking.AvailableTickets -= noOfTickets;  // Update available tickets
                return $"Booking successful! Ticket Type: {booking.TicketType}, Total Cost: {totalCost}. Remaining tickets: {booking.AvailableTickets}.";
            }
            else
            {
                return "Ticket unavailable!";
            }
        }
    }
}
