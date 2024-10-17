namespace TicketBookingSystem.Model
{
    public abstract class EventTask11
    {
        public int EventId { get; set; }
        public string EventName { get; set; }
        public DateTime EventDate { get; set; }
        public TimeSpan EventTime { get; set; }
        public VenueTask11 Venue { get; set; }
        public int TotalSeats { get; set; }
        public int AvailableSeats { get; set; }
        public decimal TicketPrice { get; set; }
        public string EventType { get; set; }

        public EventTask11(int eventId, string eventName, DateTime eventDate, TimeSpan eventTime, VenueTask11 venue, int totalSeats, decimal ticketPrice, string eventType)
        {
            EventId = eventId;
            EventName = eventName;
            EventDate = eventDate;
            EventTime = eventTime;
            Venue = venue;
            TotalSeats = totalSeats;
            AvailableSeats = totalSeats;
            TicketPrice = ticketPrice;
            EventType = eventType;
        }

        public abstract void DisplayEventDetails();
    }

    public class MovieTask11 : EventTask11
    {
        public string Genre { get; set; }
        public string ActorName { get; set; }
        public string ActressName { get; set; }

        public MovieTask11(int eventId, string eventName, DateTime eventDate, TimeSpan eventTime, VenueTask11 venue, int totalSeats, decimal ticketPrice, string genre, string actorName, string actressName)
            : base(eventId, eventName, eventDate, eventTime, venue, totalSeats, ticketPrice, "Movie")
        {
            Genre = genre;
            ActorName = actorName;
            ActressName = actressName;
        }

        public override void DisplayEventDetails()
        {
            Console.WriteLine($"Movie: {EventName}, Genre: {Genre}, Actor: {ActorName}, Actress: {ActressName}, Date: {EventDate}, Venue: {Venue.VenueName}, Seats: {AvailableSeats}");
        }
    }

    public class ConcertTask11 : EventTask11
    {
        public string Artist { get; set; }
        public string Type { get; set; }

        public ConcertTask11(int eventId, string eventName, DateTime eventDate, TimeSpan eventTime, VenueTask11 venue, int totalSeats, decimal ticketPrice, string artist, string type)
            : base(eventId, eventName, eventDate, eventTime, venue, totalSeats, ticketPrice, "Concert")
        {
            Artist = artist;
            Type = type;
        }

        public override void DisplayEventDetails()
        {
            Console.WriteLine($"Concert: {EventName}, Artist: {Artist}, Type: {Type}, Date: {EventDate}, Venue: {Venue.VenueName}, Seats: {AvailableSeats}");
        }
    }

    public class SportsTask11 : EventTask11
    {
        public string SportName { get; set; }
        public string Teams { get; set; }

        public SportsTask11(int eventId, string eventName, DateTime eventDate, TimeSpan eventTime, VenueTask11 venue, int totalSeats, decimal ticketPrice, string sportName, string teams)
            : base(eventId, eventName, eventDate, eventTime, venue, totalSeats, ticketPrice, "Sports")
        {
            SportName = sportName;
            Teams = teams;
        }

        public override void DisplayEventDetails()
        {
            Console.WriteLine($"Sports: {EventName}, Sport: {SportName}, Teams: {Teams}, Date: {EventDate}, Venue: {Venue.VenueName}, Seats: {AvailableSeats}");
        }
    }
}
