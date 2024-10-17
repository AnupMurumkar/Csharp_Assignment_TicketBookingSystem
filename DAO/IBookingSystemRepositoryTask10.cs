using System.Collections.Generic;
using TicketBookingSystem.Model;

namespace TicketBookingSystem.DAO
{
    public interface IBookingSystemRepositoryTask10
    {
        void CreateEvent(EventTask10 eventObj);
        List<EventTask10> GetEventDetails();
        int GetAvailableNoOfTickets(string eventName);
        void BookTickets( BookingTask10 booking);
        void CancelBooking(int bookingId);
        BookingTask10 GetBookingDetails(int bookingId);
    }
}
