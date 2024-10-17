using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBookingSystem.Model;

namespace TicketBookingSystem.DAO
{
    public class MovieServiceImplTask5 : IMovieServiceTask5
    {
        public void DisplayMoiveDetails(MovieTask5 movie)
        {
            Console.WriteLine( $"Movie: {movie.EventName}, Genre: {movie.Genre}, Actor: {movie.ActorName}, Actress: {movie.ActressName}, Date: {movie.EventDate}, Time: {movie.EventTime}, Venue: {movie.VenueName}, Available Seats: {movie.AvailableSeats}, Ticket Price: {movie.TicketPrice}");
        }
    }
}
