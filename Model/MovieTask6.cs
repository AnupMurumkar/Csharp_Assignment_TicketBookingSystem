namespace TicketBookingSystem.Model
{
    public class MovieTask6 : EventTask6
    {
        public string Genre { get; set; }
        public string ActorName { get; set; }
        public string ActressName { get; set; }

        // Constructor for Movie class
        public MovieTask6(string eventName, DateTime eventDate, TimeSpan eventTime, string venueName, int totalSeats, decimal ticketPrice, string genre, string actorName, string actressName)
            : base(eventName, eventDate, eventTime, venueName, totalSeats, ticketPrice)
        {
            Genre = genre;
            ActorName = actorName;
            ActressName = actressName;
        }

        // Override DisplayEventDetails method
        public override void DisplayEventDetails()
        {
            Console.WriteLine($"Movie: {EventName}, Genre: {Genre}, Actor: {ActorName}, Actress: {ActressName}, Date: {EventDate}, Time: {EventTime}, Venue: {VenueName}, Available Seats: {AvailableSeats}, Ticket Price: {TicketPrice}");
        }
    }
}
