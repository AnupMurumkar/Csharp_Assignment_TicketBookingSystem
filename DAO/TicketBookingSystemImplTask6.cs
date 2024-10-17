using System;
using System.Collections.Generic;
using TicketBookingSystem.Model;

namespace TicketBookingSystem.DAO
{
    public class TicketBookingSystemImplTask6 : BookingSystemAbstractClassTask6
    {
        private List<EventTask6> events = new List<EventTask6>();

        public override void create_event(string eventName, string date, string time, int totalSeats, decimal ticketPrice, string eventType, string venueName, string extraAttribute1, string extraAttribute2)
        {
            DateTime eventDate = DateTime.Parse(date);
            TimeSpan eventTime = TimeSpan.Parse(time);

            EventTask6 newEvent = null;

            switch (eventType.ToLower())
            {
                case "movie":
                    newEvent = new MovieTask6(eventName, eventDate, eventTime, venueName, totalSeats, ticketPrice, extraAttribute1, extraAttribute2, "Some Actress");
                    break;
                case "concert":
                    newEvent = new ConcertTask6(eventName, eventDate, eventTime, venueName, totalSeats, ticketPrice, extraAttribute1, extraAttribute2);
                    break;
                case "sports":
                    newEvent = new SportsTask6(eventName, eventDate, eventTime, venueName, totalSeats, ticketPrice, extraAttribute1, extraAttribute2);
                    break;
            }

            if (newEvent != null)
            {
                events.Add(newEvent);
                Console.WriteLine($"Event '{eventName}' created successfully.");
            }
        }

        public override void book_tickets(string eventName, int numTickets)
        {
            EventTask6 selectedEvent = events.Find(e => e.EventName == eventName);
            if (selectedEvent != null)
            {
                if (numTickets <= selectedEvent.AvailableSeats)
                {
                    selectedEvent.AvailableSeats -= numTickets;
                    Console.WriteLine($"{numTickets} tickets successfully booked for {eventName}. Remaining tickets: {selectedEvent.AvailableSeats}");
                }
                else
                {
                    Console.WriteLine("Not enough available seats.");
                }
            }
            else
            {
                Console.WriteLine("Event not found.");
            }
        }

        public override void cancel_tickets(string eventName, int numTickets)
        {
            EventTask6 selectedEvent = events.Find(e => e.EventName == eventName);
            if (selectedEvent != null)
            {
                selectedEvent.AvailableSeats += numTickets;
                Console.WriteLine($"{numTickets} tickets have been canceled for {eventName}. Available tickets: {selectedEvent.AvailableSeats}");
            }
            else
            {
                Console.WriteLine("Event not found.");
            }
        }

        public override int get_available_seats(string eventName)
        {
            EventTask6 selectedEvent = events.Find(e => e.EventName == eventName);
            return selectedEvent != null ? selectedEvent.AvailableSeats : 0;
        }

        public override void display_event_details(string eventName)
        {
            EventTask6 selectedEvent = events.Find(e => e.EventName == eventName);
            if (selectedEvent != null)
            {
                selectedEvent.DisplayEventDetails();
            }
            else
            {
                Console.WriteLine("Event not found.");
            }
        }
    }
}
