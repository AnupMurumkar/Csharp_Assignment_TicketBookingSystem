using System;
using TicketBookingSystem.Model;

namespace TicketBookingSystem.DAO
{
    public class EventServiceImplTask4 : IEventServiceTask4
    {
        public void BookTickets(EventTask4 eventTask, int numTickets)
        {
            if (numTickets <= eventTask.AvailableSeats)
            {
                eventTask.AvailableSeats -= numTickets;
                Console.WriteLine($"{numTickets} tickets successfully booked for {eventTask.EventName}. Remaining tickets: {eventTask.AvailableSeats}");
            }
            else
            {
                Console.WriteLine("Insufficient tickets available.");
            }
        }

        public void CancelBooking(EventTask4 eventTask, int numTickets)
        {
            eventTask.AvailableSeats += numTickets;
            Console.WriteLine($"{numTickets} tickets have been canceled for {eventTask.EventName}. Available tickets: {eventTask.AvailableSeats}");
        }

        public decimal CalculateTotalRevenue(EventTask4 eventTask)
        {
            int bookedTickets = eventTask.TotalSeats - eventTask.AvailableSeats;
            return bookedTickets * eventTask.TicketPrice;
        }

        public int GetBookedNoOfTickets(EventTask4 eventTask)
        {
            return eventTask.TotalSeats - eventTask.AvailableSeats;
        }

        public void DisplayEventDetails(EventTask4 eventTask)
        {
            Console.WriteLine($"Event: {eventTask.EventName}, Date: {eventTask.EventDate.ToShortDateString()}, Time: {eventTask.EventTime}, Venue: {eventTask.VenueName}, Available Seats: {eventTask.AvailableSeats}");
        }
    }
}
