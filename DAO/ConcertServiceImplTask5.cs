using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBookingSystem.Model;

namespace DAO
{
    internal class ConcertServiceImplTask5 : IConcertServiceTask5
    {
        public void DisplayConcertDetails(ConcertTask5 concert)
        {
            Console.WriteLine($"Concert: {concert.EventName}, Artist: {concert.Artist}, Type: {concert.Type}, Date: {concert.EventDate}, Time: {concert.EventTime}, Venue: {concert.VenueName}, Available Seats: {concert.AvailableSeats}, Ticket Price: {concert.TicketPrice}");
        }
    }
}
