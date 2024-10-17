using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBookingSystem.Model;

namespace DAO
{
    internal class SportServiceImplTask5 : ISportService
    {
        public void DisplaySportDetails(SportsTask5 sports)
        {
            Console.WriteLine($"Sports: {sports.EventName}, Sport: {sports.SportName}, Teams: {sports.TeamsName}, Date: {sports.EventDate}, Time: {sports.EventTime}, Venue: {sports.VenueName}, Available Seats: {sports.AvailableSeats}, Ticket Price: {sports.TicketPrice}");
        }
    }
}
