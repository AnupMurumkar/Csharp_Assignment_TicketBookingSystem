using System;
using TicketBookingSystem.Model;

namespace TicketBookingSystem.Model
{
    public class BookingTask8
    {
        private static int _bookingCounter = 1; // Static variable for unique booking ID

        public int BookingId { get; private set; }
        public CustomerTask8[] Customers { get; set; }  // Array of customers
        public EventTask8 Event { get; set; }           // Reference to the event booked
        public int NumTickets { get; set; }
        public decimal TotalCost { get; set; }
        public DateTime BookingDate { get; set; }

        // Constructor
        public BookingTask8(CustomerTask8[] customers, EventTask8 bookedEvent, int numTickets, decimal totalCost)
        {
            BookingId = _bookingCounter++;
            Customers = customers;
            Event = bookedEvent;
            NumTickets = numTickets;
            TotalCost = totalCost;
            BookingDate = DateTime.Now;
        }

        // Display booking details
        public void display_booking_details()
        {
            Console.WriteLine($"Booking ID: {BookingId}, Event: {Event.EventName}, Tickets: {NumTickets}, Total Cost: {TotalCost}, Booking Date: {BookingDate}");
            foreach (var customer in Customers)
            {
                customer.display_customer_details();
            }
        }
    }
}
