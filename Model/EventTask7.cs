using System;

namespace TicketBookingSystem.Model
{
    public abstract class EventTask7
    {
        public string EventName { get; set; }
        public DateTime EventDate { get; set; }
        public TimeSpan EventTime { get; set; }
        public VenueTask7 Venue { get; set; }  // Has A relation with Venue
        public int TotalSeats { get; set; }
        public int AvailableSeats { get; set; }
        public decimal TicketPrice { get; set; }
        public string EventType { get; set; }

        // Constructor
        protected EventTask7(string eventName, DateTime eventDate, TimeSpan eventTime, VenueTask7 venue, int totalSeats, decimal ticketPrice, string eventType)
        {
            EventName = eventName;
            EventDate = eventDate;
            EventTime = eventTime;
            Venue = venue;
            TotalSeats = totalSeats;
            AvailableSeats = totalSeats;
            TicketPrice = ticketPrice;
            EventType = eventType;
        }

        // Abstract method to display event details
        public abstract void display_event_details();

        // Calculate total revenue based on the number of tickets sold
        public decimal calculate_total_revenue()
        {
            int bookedTickets = TotalSeats - AvailableSeats;
            return bookedTickets * TicketPrice;
        }

        // Get the number of booked tickets
        public int getBookedNoOfTickets()
        {
            return TotalSeats - AvailableSeats;
        }

        // Book tickets for the event
        public void book_tickets(int numTickets)
        {
            if (numTickets <= AvailableSeats)
            {
                AvailableSeats -= numTickets;
                Console.WriteLine($"{numTickets} tickets successfully booked for {EventName}. Remaining tickets: {AvailableSeats}");
            }
            else
            {
                Console.WriteLine("Insufficient tickets available.");
            }
        }

        // Cancel the booking and update the available seats
        public void cancel_booking(int numTickets)
        {
            AvailableSeats += numTickets;
            Console.WriteLine($"{numTickets} tickets have been canceled for {EventName}. Available tickets: {AvailableSeats}");
        }
    }

    public class MovieTask7 : EventTask7
    {
        public string Genre { get; set; }
        public string ActorName { get; set; }
        public string ActressName { get; set; }

        public MovieTask7(string eventName, DateTime eventDate, TimeSpan eventTime, VenueTask7 venue, int totalSeats, decimal ticketPrice, string genre, string actorName, string actressName)
            : base(eventName, eventDate, eventTime, venue, totalSeats, ticketPrice, "Movie")
        {
            Genre = genre;
            ActorName = actorName;
            ActressName = actressName;
        }

        public override void display_event_details()
        {
            Console.WriteLine($"Movie: {EventName}, Genre: {Genre}, Actor: {ActorName}, Actress: {ActressName}, Date: {EventDate.ToShortDateString()}, Time: {EventTime}, Venue: {Venue.VenueName}, Available Seats: {AvailableSeats}, Ticket Price: {TicketPrice}");
        }
    }

    public class ConcertTask7 : EventTask7
    {
        public string Artist { get; set; }
        public string Type { get; set; }

        public ConcertTask7(string eventName, DateTime eventDate, TimeSpan eventTime, VenueTask7 venue, int totalSeats, decimal ticketPrice, string artist, string type)
            : base(eventName, eventDate, eventTime, venue, totalSeats, ticketPrice, "Concert")
        {
            Artist = artist;
            Type = type;
        }

        public override void display_event_details()
        {
            Console.WriteLine($"Concert: {EventName}, Artist: {Artist}, Type: {Type}, Date: {EventDate.ToShortDateString()}, Time: {EventTime}, Venue: {Venue.VenueName}, Available Seats: {AvailableSeats}, Ticket Price: {TicketPrice}");
        }
    }

    public class SportsTask7 : EventTask7
    {
        public string SportName { get; set; }
        public string TeamsName { get; set; }

        public SportsTask7(string eventName, DateTime eventDate, TimeSpan eventTime, VenueTask7 venue, int totalSeats, decimal ticketPrice, string sportName, string teamsName)
            : base(eventName, eventDate, eventTime, venue, totalSeats, ticketPrice, "Sports")
        {
            SportName = sportName;
            TeamsName = teamsName;
        }

        public override void display_event_details()
        {
            Console.WriteLine($"Sports: {EventName}, Sport: {SportName}, Teams: {TeamsName}, Date: {EventDate.ToShortDateString()}, Time: {EventTime}, Venue: {Venue.VenueName}, Available Seats: {AvailableSeats}, Ticket Price: {TicketPrice}");
        }
    }
}
