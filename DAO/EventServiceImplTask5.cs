using System;
using TicketBookingSystem.Model;

namespace TicketBookingSystem.DAO
{
    public class EventServiceImplTask5 : IEventServiceTask5
    {
        public void display_event_details(EventTask5 eventObj)
        {
            if (eventObj is MovieTask5 movie)
            {
                Console.WriteLine($"Movie: {movie.EventName}, Genre: {movie.Genre}, Actor: {movie.ActorName}, Actress: {movie.ActressName}, Date: {movie.EventDate}, Time: {movie.EventTime}, Venue: {movie.VenueName}, Available Seats: {movie.AvailableSeats}, Ticket Price: {movie.TicketPrice}");
            }
            else if (eventObj is ConcertTask5 concert)
            {
                Console.WriteLine($"Concert: {concert.EventName}, Artist: {concert.Artist}, Type: {concert.Type}, Date: {concert.EventDate}, Time: {concert.EventTime}, Venue: {concert.VenueName}, Available Seats: {concert.AvailableSeats}, Ticket Price: {concert.TicketPrice}");
            }
            else if (eventObj is SportsTask5 sports)
            {
                Console.WriteLine($"Sports: {sports.EventName}, Sport: {sports.SportName}, Teams: {sports.TeamsName}, Date: {sports.EventDate}, Time: {sports.EventTime}, Venue: {sports.VenueName}, Available Seats: {sports.AvailableSeats}, Ticket Price: {sports.TicketPrice}");
            }
        }

        public decimal book_tickets(EventTask5 eventObj, int numTickets)
        {
            if (numTickets <= eventObj.AvailableSeats)
            {
                eventObj.AvailableSeats -= numTickets;
                Console.WriteLine($"{numTickets} tickets successfully booked for {eventObj.EventName}. Remaining tickets: {eventObj.AvailableSeats}");
                return numTickets * eventObj.TicketPrice;
            }
            else
            {
                Console.WriteLine("Insufficient tickets available.");
                return 0;
            }
        }

        public void cancel_tickets(EventTask5 eventObj, int numTickets)
        {
            eventObj.AvailableSeats += numTickets;
            Console.WriteLine($"{numTickets} tickets canceled for {eventObj.EventName}. Available tickets: {eventObj.AvailableSeats}");
        }
    }
}
