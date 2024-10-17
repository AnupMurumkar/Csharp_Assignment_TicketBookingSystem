using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBookingSystem.Model;

namespace TicketBookingSystem.DAO
{
    public class BookingServiceImplTask1 : IBookingServiceTask1
    {
        public string BookTickets(BookingTask1 booking, int noOfTickets)
        {
            if(noOfTickets <= booking.AvailableTickets)
            {
                booking.AvailableTickets -= noOfTickets;
                return $"Booking Successful!! Remaining Tickets : {booking.AvailableTickets}.";
            }

            else
            {
                return "Ticket unavailable!";
            }
        }
    }
}
