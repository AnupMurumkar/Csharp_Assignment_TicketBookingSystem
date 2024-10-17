namespace TicketBookingSystem.Model
{
    public class SportsTask6 : EventTask6
    {
        public string SportName { get; set; }
        public string TeamsName { get; set; }

        // Constructor for Sports class
        public SportsTask6(string eventName, DateTime eventDate, TimeSpan eventTime, string venueName, int totalSeats, decimal ticketPrice, string sportName, string teamsName)
            : base(eventName, eventDate, eventTime, venueName, totalSeats, ticketPrice)
        {
            SportName = sportName;
            TeamsName = teamsName;
        }

        // Override DisplayEventDetails method
        public override void DisplayEventDetails()
        {
            Console.WriteLine($"Sports: {EventName}, Sport: {SportName}, Teams: {TeamsName}, Date: {EventDate}, Time: {EventTime}, Venue: {VenueName}, Available Seats: {AvailableSeats}, Ticket Price: {TicketPrice}");
        }
    }
}
