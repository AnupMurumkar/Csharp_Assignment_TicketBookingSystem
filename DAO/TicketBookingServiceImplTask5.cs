using System;
using TicketBookingSystem.Model;

namespace TicketBookingSystem.DAO
{
    public class TicketBookingServiceImplTask5 : ITicketBookingServiceTask5
    {
        public EventTask5 create_event(string eventName, string date, string time, int totalSeats, decimal ticketPrice, string eventType, string venueName, string extraAttribute1, string extraAttribute2, string extraAttribute3)
        {
            DateTime eventDate = DateTime.Parse(date);
            TimeSpan eventTime = TimeSpan.Parse(time);

            switch (eventType.ToLower())
            {
                case "movie":
                    return new MovieTask5(eventName, eventDate, eventTime, venueName, totalSeats, ticketPrice, extraAttribute1, extraAttribute2 , extraAttribute3);
                case "concert":
                    return new ConcertTask5(eventName, eventDate, eventTime, venueName, totalSeats, ticketPrice, extraAttribute1, extraAttribute2);
                case "sports":
                    return new SportsTask5(eventName, eventDate, eventTime, venueName, totalSeats, ticketPrice, extraAttribute1, extraAttribute2);
                default:
                    throw new ArgumentException("Invalid event type.");
            }
        }
    }
}
