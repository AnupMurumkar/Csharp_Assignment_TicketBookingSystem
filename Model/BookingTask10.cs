using System;
using System.Collections.Generic;

namespace TicketBookingSystem.Model
{
    public class BookingTask10
    {
        public int BookingId { get; private set; }
        public HashSet<CustomerTask10> Customers { get; set; }
        public EventTask10 Event { get; set; }
        public int NumTickets { get; set; }
        public decimal TotalCost { get; set; }
        public DateTime BookingDate { get; set; }

        private static int _bookingIdCounter = 1;

        public BookingTask10(EventTask10 eventObj, HashSet<CustomerTask10> customers, int numTickets)
        {
            BookingId = _bookingIdCounter++;
            Event = eventObj;
            Customers = customers;
            NumTickets = numTickets;
            BookingDate = DateTime.Now;
            CalculateTotalCost();
        }

        private void CalculateTotalCost()
        {
            TotalCost = NumTickets * Event.TicketPrice;
        }
    }
}
