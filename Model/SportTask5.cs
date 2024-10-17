using TicketBookingSystem.Model;

namespace TicketBookingSystem.Model
{
    public class SportsTask5 : EventTask5
    {
        public string SportName { get; set; }
        public string TeamsName { get; set; }

        // Constructor for the Sports class
        public SportsTask5(string eventName, DateTime eventDate, TimeSpan eventTime, string venueName, int totalSeats, decimal ticketPrice, string sportName, string teamsName)
            : base(eventName, eventDate, eventTime, venueName, totalSeats, ticketPrice)
        {
            SportName = sportName;
            TeamsName = teamsName;
        }
    }
}
