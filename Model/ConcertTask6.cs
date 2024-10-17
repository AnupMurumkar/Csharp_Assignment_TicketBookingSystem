namespace TicketBookingSystem.Model
{
    public class ConcertTask6 : EventTask6
    {
        public string Artist { get; set; }
        public string Type { get; set; }  // Theatrical, Classical, Rock, Recital

        // Constructor for Concert class
        public ConcertTask6(string eventName, DateTime eventDate, TimeSpan eventTime, string venueName, int totalSeats, decimal ticketPrice, string artist, string type)
            : base(eventName, eventDate, eventTime, venueName, totalSeats, ticketPrice)
        {
            Artist = artist;
            Type = type;
        }

        // Override DisplayEventDetails method
        public override void DisplayEventDetails()
        {
            Console.WriteLine($"Concert: {EventName}, Artist: {Artist}, Type: {Type}, Date: {EventDate}, Time: {EventTime}, Venue: {VenueName}, Available Seats: {AvailableSeats}, Ticket Price: {TicketPrice}");
        }
    }
}
