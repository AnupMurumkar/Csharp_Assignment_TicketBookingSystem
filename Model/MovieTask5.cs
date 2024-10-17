namespace TicketBookingSystem.Model
{
    public class MovieTask5 : EventTask5
    {
        public string Genre { get; set; }
        public string ActorName { get; set; }
        public string ActressName { get; set; }

        // Constructor for the Movie class
        public MovieTask5(string eventName, DateTime eventDate, TimeSpan eventTime, string venueName, int totalSeats, decimal ticketPrice, string genre, string actorName, string actressName)
            : base(eventName, eventDate, eventTime, venueName, totalSeats, ticketPrice)
        {
            Genre = genre;
            ActorName = actorName;
            ActressName = actressName;
        }
    }
}
