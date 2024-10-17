namespace TicketBookingSystem.Model
{
    public abstract class EventTask6
    {
        public string EventName { get; set; }
        public DateTime EventDate { get; set; }
        public TimeSpan EventTime { get; set; }
        public string VenueName { get; set; }
        public int TotalSeats { get; set; }
        public int AvailableSeats { get; set; }
        public decimal TicketPrice { get; set; }

        // Constructor for the abstract class
        protected EventTask6(string eventName, DateTime eventDate, TimeSpan eventTime, string venueName, int totalSeats, decimal ticketPrice)
        {
            EventName = eventName;
            EventDate = eventDate;
            EventTime = eventTime;
            VenueName = venueName;
            TotalSeats = totalSeats;
            AvailableSeats = totalSeats;  // Initially, available seats equal total seats
            TicketPrice = ticketPrice;
        }

        // Abstract methods to be overridden in concrete classes
        public abstract void DisplayEventDetails();
    }
}
