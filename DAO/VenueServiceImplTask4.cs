using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBookingSystem.Model;

namespace TicketBookingSystem.DAO
{
    public class VenueServiceImplTask4 : IVenueServiceTask4
    {

        public void DisplayVenueDetails(VenueTask4 venue)
        {
            Console.WriteLine($"VenueName: {venue.VenueName} , Address: {venue.Address}");
        }
    }
}
