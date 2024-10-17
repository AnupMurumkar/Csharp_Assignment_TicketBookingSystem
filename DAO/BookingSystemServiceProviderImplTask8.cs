using System;
using System.Collections.Generic;
using TicketBookingSystem.Model;
using TicketBookingSystem.DAO;

namespace TicketBookingSystem.DAO
{
    public class BookingSystemServiceProviderImplTask8 : EventServiceProviderImplTask8, IBookingSystemServiceProviderTask8
    {
        private List<BookingTask8> bookings = new List<BookingTask8>();

        // Calculate booking cost
        public decimal calculate_booking_cost(int numTickets, decimal ticketPrice)
        {
            return numTickets * ticketPrice;
        }

        // Book tickets
        public void book_tickets(string eventName, int numTickets, CustomerTask8[] customers)
        {
            EventTask8 selectedEvent = events.Find(e => e.EventName == eventName);
            if (selectedEvent != null)
            {
                selectedEvent.book_tickets(numTickets);
                decimal totalCost = calculate_booking_cost(numTickets, selectedEvent.TicketPrice);
                BookingTask8 booking = new BookingTask8(customers, selectedEvent, numTickets, totalCost);
                bookings.Add(booking);
                booking.display_booking_details();
            }
            else
            {
                Console.WriteLine("Event not found.");
            }
        }

        // Cancel a booking
        public void cancel_booking(int bookingId)
        {
            BookingTask8 booking = bookings.Find(b => b.BookingId == bookingId);
            if (booking != null)
            {
                booking.Event.cancel_booking(booking.NumTickets);
                bookings.Remove(booking);
                Console.WriteLine($"Booking {bookingId} canceled successfully.");
            }
            else
            {
                Console.WriteLine("Booking not found.");
            }
        }

        // Get booking details
        public BookingTask8 get_booking_details(int bookingId)
        {
            return bookings.Find(b => b.BookingId == bookingId);
        }
    }
}
