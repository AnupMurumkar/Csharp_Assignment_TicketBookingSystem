using System;

namespace TicketBookingSystem.Model
{
    public class BookingTask7
    {
        private static int _bookingCounter = 1; // Booking ID starts from 1 and increments

        public int BookingId { get; private set; }
        public CustomerTask7[] Customers { get; set; }  // Array of customers
        public EventTask7 Event { get; set; }           // Reference to the event booked
        public int NumTickets { get; set; }
        public decimal TotalCost { get; set; }
        public DateTime BookingDate { get; set; }

        // Constructor
        public BookingTask7(CustomerTask7[] customers, EventTask7 bookedEvent, int numTickets, decimal totalCost)
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
