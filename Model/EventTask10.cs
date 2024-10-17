

namespace TicketBookingSystem.Model
{
    public class EventTask10
    {
        public int EventId { get; set; }
        public string EventName { get; set; }
        public DateTime EventDate { get; set; }
        public TimeSpan EventTime { get; set; }
        public VenueTask10 Venue { get; set; }
        public int TotalSeats { get; set; }
        public int AvailableSeats { get; set; }
        public decimal TicketPrice { get; set; }
        public string EventType { get; set; }

        public EventTask10(int eventId, string eventName, DateTime eventDate, TimeSpan eventTime, VenueTask10 venue, int totalSeats, decimal ticketPrice, string eventType)
        {
            EventId = eventId;
            EventName = eventName;
            EventDate = eventDate;
            EventTime = eventTime;
            Venue = venue;
            TotalSeats = totalSeats;
            AvailableSeats = totalSeats;  // Initially, all seats are available
            TicketPrice = ticketPrice;
            EventType = eventType;
        }
    }
}
