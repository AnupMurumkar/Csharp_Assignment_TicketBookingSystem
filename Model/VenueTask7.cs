namespace TicketBookingSystem.Model
{
    public class VenueTask7
    {
        public string VenueName { get; set; }
        public string Address { get; set; }

        // Constructor
        public VenueTask7(string venueName, string address)
        {
            VenueName = venueName;
            Address = address;
        }

        // Display venue details
        public void display_venue_details()
        {
            Console.WriteLine($"Venue: {VenueName}, Address: {Address}");
        }
    }
}
