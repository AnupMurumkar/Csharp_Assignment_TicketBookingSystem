using System.Collections.Generic;

using TicketBookingSystem.Model;

namespace TicketBookingSystem.DAO
{
    public class BookingSystemRepositoryImplTask10 : IBookingSystemRepositoryTask10
    {
        private List<EventTask10> events = new List<EventTask10>();
        private List<BookingTask10> bookings = new List<BookingTask10>();

        public void CreateEvent(EventTask10 eventObj)
        {
            events.Add(eventObj);
        }

        public List<EventTask10> GetEventDetails()
        {
            return events;
        }

        public int GetAvailableNoOfTickets(string eventName)
        {
            var eventObj = events.Find(e => e.EventName.Equals(eventName, System.StringComparison.OrdinalIgnoreCase));
            return eventObj?.AvailableSeats ?? 0;
        }

        public void BookTickets(BookingTask10 booking)
        {
            bookings.Add(booking);
            var eventToUpdate = events.Find(e => e.EventId == booking.Event.EventId);
            if (eventToUpdate != null)
            {
                eventToUpdate.AvailableSeats -= booking.NumTickets;
            }
        }

        public void CancelBooking(int bookingId)
        {
            var booking = bookings.Find(b => b.BookingId == bookingId);
            if (booking != null)
            {
                bookings.Remove(booking);
                var eventToUpdate = events.Find(e => e.EventId == booking.Event.EventId);
                if (eventToUpdate != null)
                {
                    eventToUpdate.AvailableSeats += booking.NumTickets;
                }
            }
        }

        public BookingTask10 GetBookingDetails(int bookingId)
        {
            return bookings.Find(b => b.BookingId == bookingId);
        }
    }
}
