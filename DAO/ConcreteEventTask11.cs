using System;

namespace TicketBookingSystem.Model
{
    public class ConcreteEventTask11 : EventTask11
    {
        public ConcreteEventTask11(int eventId, string eventName, DateTime eventDate, TimeSpan eventTime, VenueTask11 venue, int totalSeats, decimal ticketPrice, string eventType)
            : base(eventId, eventName, eventDate, eventTime, venue, totalSeats, ticketPrice, eventType)
        {
        }

        public override void DisplayEventDetails()
        {
            Console.WriteLine($"Event ID: {EventId}, Name: {EventName}, Date: {EventDate}, Time: {EventTime}, Venue: {Venue.VenueName}, Total Seats: {TotalSeats}, Available Seats: {AvailableSeats}, Ticket Price: {TicketPrice:C}, Type: {EventType}");
        }
    }
}
