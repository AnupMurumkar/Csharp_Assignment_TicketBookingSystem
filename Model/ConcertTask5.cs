
namespace TicketBookingSystem.Model
{
    public class ConcertTask5 : EventTask5
    {
        public string Artist { get; set; }
        public string Type { get; set; }  // Theatrical, Classical, Rock, Recital

        // Constructor for the Concert class
        public ConcertTask5(string eventName, DateTime eventDate, TimeSpan eventTime, string venueName, int totalSeats, decimal ticketPrice, string artist, string type)
            : base(eventName, eventDate, eventTime, venueName, totalSeats, ticketPrice)
        {
            Artist = artist;
            Type = type;
        }
    }
}
