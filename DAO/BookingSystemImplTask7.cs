using System;
using System.Collections.Generic;
using TicketBookingSystem.Model;

namespace TicketBookingSystem.DAO;

public class BookingSystemImplTask7
{
    private List<EventTask7> events = new List<EventTask7>();
    private List<BookingTask7> bookings = new List<BookingTask7>();

    // Create an event
    public void create_event(string eventName, string date, string time, int totalSeats, decimal ticketPrice, string eventType, VenueTask7 venue, string extraAttribute1, string extraAttribute2)
    {
        DateTime eventDate = DateTime.Parse(date);
        TimeSpan eventTime = TimeSpan.Parse(time);

        EventTask7 newEvent = null;

        switch (eventType.ToLower())
        {
            case "movie":
                newEvent = new MovieTask7(eventName, eventDate, eventTime, venue, totalSeats, ticketPrice, extraAttribute1, extraAttribute2, "Some Actress");
                break;
            case "concert":
                newEvent = new ConcertTask7(eventName, eventDate, eventTime, venue, totalSeats, ticketPrice, extraAttribute1, extraAttribute2);
                break;
            case "sports":
                newEvent = new SportsTask7(eventName, eventDate, eventTime, venue, totalSeats, ticketPrice, extraAttribute1, extraAttribute2);
                break;
        }

        if (newEvent != null)
        {
            events.Add(newEvent);
            Console.WriteLine($"Event '{eventName}' created successfully.");
        }
    }

    // Book tickets for an event
    public void book_tickets(string eventName, int numTickets, CustomerTask7[] customers)
    {
        EventTask7 selectedEvent = events.Find(e => e.EventName == eventName);
        if (selectedEvent != null)
        {
            if (numTickets <= selectedEvent.AvailableSeats)
            {
                selectedEvent.book_tickets(numTickets);
                decimal totalCost = numTickets * selectedEvent.TicketPrice;
                BookingTask7 newBooking = new BookingTask7(customers, selectedEvent, numTickets, totalCost);
                bookings.Add(newBooking);
                newBooking.display_booking_details();
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

    // Cancel a booking by booking ID
    public void cancel_booking(int bookingId)
    {
        BookingTask7 booking = bookings.Find(b => b.BookingId == bookingId);
        if (booking != null)
        {
            booking.Event.cancel_booking(booking.NumTickets);
            bookings.Remove(booking);
            Console.WriteLine($"Booking with ID {bookingId} has been canceled.");
        }
        else
        {
            Console.WriteLine("Booking not found.");
        }
    }

    // Get available seats for an event
    public int getAvailableNoOfTickets(string eventName)
    {
        EventTask7 selectedEvent = events.Find(e => e.EventName == eventName);
        return selectedEvent != null ? selectedEvent.AvailableSeats : 0;
    }

    // Get event details
    public void getEventDetails(string eventName)
    {
        EventTask7 selectedEvent = events.Find(e => e.EventName == eventName);
        if (selectedEvent != null)
        {
            selectedEvent.display_event_details();
        }
        else
        {
            Console.WriteLine("Event not found.");
        }
    }
}


