using System;
using System.Collections.Generic;
using TicketBookingSystem.Model;
using TicketBookingSystem.DAO;

namespace TicketBookingSystem.DAO
{   
    public class EventServiceProviderImplTask8 : IEventServiceProviderTask8
    {
        public List<EventTask8> events = new List<EventTask8>();

        // Create event
        public EventTask8 create_event(string eventName, string date, string time, int totalSeats, decimal ticketPrice, string eventType, VenueTask8 venue)
        {
            DateTime eventDate = DateTime.Parse(date);
            TimeSpan eventTime = TimeSpan.Parse(time);
            EventTask8 newEvent = null;

            switch (eventType.ToLower())
            {
                case "movie":
                    newEvent = new MovieTask8(eventName, eventDate, eventTime, venue, totalSeats, ticketPrice, "Genre", "Actor Name", "Actress Name");
                    break;
                case "concert":
                    newEvent = new ConcertTask8(eventName, eventDate, eventTime, venue, totalSeats, ticketPrice, "Artist Name", "Type");
                    break;
                case "sports":
                    newEvent = new SportsTask8(eventName, eventDate, eventTime, venue, totalSeats, ticketPrice, "Sport Name", "Teams Name");
                    break;
            }

            if (newEvent != null)
            {
                events.Add(newEvent);
                Console.WriteLine($"Event '{eventName}' created successfully.");
            }
            return newEvent;
        }

        // Get event details
        public EventTask8[] getEventDetails()
        {
            return events.ToArray();
        }

        // Get available tickets for an event
        public int getAvailableNoOfTickets(string eventName)
        {
            EventTask8 selectedEvent = events.Find(e => e.EventName == eventName);
            return selectedEvent != null ? selectedEvent.AvailableSeats : 0;
        }
    }
}
