using System;
using System.Collections.Generic;
using TicketBookingSystem.Model;

namespace TicketBookingSystem.model
{
    public class BookingTask11
    {
        public int BookingId { get; private set; }
        public List<CustomerTask11> Customers { get; set; }
        public EventTask11 Event { get; set; }
        public int NumTickets { get; set; }
        public decimal TotalCost { get; set; }
        public DateTime BookingDate { get; set; }

        private static int _bookingCounter = 1;

        public BookingTask11(EventTask11 eventObj, List<CustomerTask11> customers, int numTickets)
        {
            BookingId = _bookingCounter++;
            Event = eventObj;
            Customers = customers;
            NumTickets = numTickets;
            BookingDate = DateTime.Now;
            TotalCost = NumTickets * Event.TicketPrice;
        }

        public void DisplayBookingDetails()
        {
            Console.WriteLine($"Booking ID: {BookingId}, Event: {Event.EventName}, Tickets: {NumTickets}, Total Cost: {TotalCost}");
            foreach (var customer in Customers)
            {
                customer.DisplayCustomerDetails();
            }
        }
    }
}
