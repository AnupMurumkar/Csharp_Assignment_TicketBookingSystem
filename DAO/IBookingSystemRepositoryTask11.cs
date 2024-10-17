using TicketBookingSystem.model;
using System.Collections.Generic;
using TicketBookingSystem.Model;

namespace TicketBookingSystem.DAO
{
    public interface IBookingSystemRepositoryTask11
    {
        EventTask11 CreateEvent(string eventName, string date, string time, int totalSeats, decimal ticketPrice, string eventType, VenueTask11 venue);
        List<EventTask11> GetEventDetails();
        int GetAvailableNoOfTickets(string eventName);
        BookingTask11 BookTickets(string eventName, int numTickets, List<CustomerTask11> customers);
        void CancelBooking(int bookingId);
        BookingTask11 GetBookingDetails(int bookingId);
    }
}
