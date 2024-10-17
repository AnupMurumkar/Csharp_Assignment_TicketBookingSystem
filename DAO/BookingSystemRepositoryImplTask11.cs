using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using TicketBookingSystem.model;
using TicketBookingSystem.Model;
using TicketBookingSystem.utils;

namespace TicketBookingSystem.DAO
{
    public class BookingSystemRepositoryImplTask11 : IBookingSystemRepositoryTask11
    {
      
        public EventTask11 CreateEvent(string eventName, string date, string time, int totalSeats, decimal ticketPrice, string eventType, VenueTask11 venue)
        {
            using (SqlConnection conn = DBUtilTask11.getDBConn())
            {
                string query = "INSERT INTO Events (EventName, EventDate, EventTime, TotalSeats, AvailableSeats, TicketPrice, EventType, VenueName, VenueAddress) " +
                               "VALUES (@EventName, @EventDate, @EventTime, @TotalSeats, @AvailableSeats, @TicketPrice, @EventType, @VenueName, @VenueAddress)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@EventName", eventName);
                cmd.Parameters.AddWithValue("@EventDate", DateTime.Parse(date));
                cmd.Parameters.AddWithValue("@EventTime", TimeSpan.Parse(time));
                cmd.Parameters.AddWithValue("@TotalSeats", totalSeats);
                cmd.Parameters.AddWithValue("@AvailableSeats", totalSeats);  
                cmd.Parameters.AddWithValue("@TicketPrice", ticketPrice);
                cmd.Parameters.AddWithValue("@EventType", eventType);
                cmd.Parameters.AddWithValue("@VenueName", venue.VenueName);
                cmd.Parameters.AddWithValue("@VenueAddress", venue.Address);
                cmd.ExecuteNonQuery();

                Console.WriteLine("Event created and stored in the database successfully.");

                 return new ConcreteEventTask11(1, eventName, DateTime.Parse(date), TimeSpan.Parse(time), venue, totalSeats, ticketPrice, eventType);
            }
        }

        // Retrieve all event details from the database
        public List<EventTask11> GetEventDetails()
        {
            List<EventTask11> events = new List<EventTask11>();

            using (SqlConnection conn = DBUtilTask11.getDBConn())
            {
                string query = "SELECT * FROM Events";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    VenueTask11 venue = new VenueTask11(reader["VenueName"].ToString(), reader["VenueAddress"].ToString());
                    EventTask11 eventObj = new ConcreteEventTask11(
                Convert.ToInt32(reader["EventID"]),
                reader["EventName"].ToString(),
                Convert.ToDateTime(reader["EventDate"]),
                TimeSpan.Parse(reader["EventTime"].ToString()),
                venue,
                Convert.ToInt32(reader["TotalSeats"]),
                Convert.ToDecimal(reader["TicketPrice"]),
                reader["EventType"].ToString()
            );
                    eventObj.AvailableSeats = Convert.ToInt32(reader["AvailableSeats"]);
                    events.Add(eventObj);
                }
            }

            return events;
        }

        // Get the number of available seats for an event
        public int GetAvailableNoOfTickets(string eventName)
        {
            using (SqlConnection conn = DBUtilTask11.getDBConn())
            {
                string query = "SELECT AvailableSeats FROM Events WHERE EventName = @EventName";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@EventName", eventName);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        // Book tickets for an event and update the database
        public BookingTask11 BookTickets(string eventName, int numTickets, List<CustomerTask11> customers)
        {
            using (SqlConnection conn = DBUtilTask11.getDBConn())
            {
                // Update available seats for the event
                string updateQuery = "UPDATE Events SET AvailableSeats = AvailableSeats - @NumTickets WHERE EventName = @EventName AND AvailableSeats >= @NumTickets";
                SqlCommand updateCmd = new SqlCommand(updateQuery, conn);
                updateCmd.Parameters.AddWithValue("@EventName", eventName);
                updateCmd.Parameters.AddWithValue("@NumTickets", numTickets);

                int rowsAffected = updateCmd.ExecuteNonQuery();
                if (rowsAffected == 0)
                {
                    throw new Exception("Not enough available seats or event does not exist.");
                }

                // Insert the booking details into the Bookings table
                string insertBookingQuery = "INSERT INTO Bookings (EventName, NumTickets, TotalCost, BookingDate) " +
                                            "VALUES (@EventName, @NumTickets, @TotalCost, @BookingDate); SELECT SCOPE_IDENTITY();";
                SqlCommand insertCmd = new SqlCommand(insertBookingQuery, conn);
                insertCmd.Parameters.AddWithValue("@EventName", eventName);
                insertCmd.Parameters.AddWithValue("@NumTickets", numTickets);
                insertCmd.Parameters.AddWithValue("@TotalCost", CalculateBookingCost(numTickets, GetEventDetails().Find(e => e.EventName == eventName).TicketPrice));
                insertCmd.Parameters.AddWithValue("@BookingDate", DateTime.Now);

                int bookingId = Convert.ToInt32(insertCmd.ExecuteScalar());

                // Insert customers into a hypothetical Customers table if needed

                EventTask11 eventToBook = GetEventDetails().Find(e => e.EventName == eventName);
                BookingTask11 booking = new BookingTask11(eventToBook, customers, numTickets);

                Console.WriteLine("Booking created and stored in the database successfully.");
                return booking;
            }
        }

        // Cancel a booking and update the database
        public void CancelBooking(int bookingId)
        {
            using (SqlConnection conn = DBUtilTask11.getDBConn())
            {
                // Get the number of tickets booked for the event
                string getBookingQuery = "SELECT NumTickets, EventName FROM Bookings WHERE BookingID = @BookingID";
                SqlCommand getBookingCmd = new SqlCommand(getBookingQuery, conn);
                getBookingCmd.Parameters.AddWithValue("@BookingID", bookingId);
                SqlDataReader reader = getBookingCmd.ExecuteReader();

                if (!reader.HasRows)
                {
                    throw new Exception("Booking ID not found.");
                }

                reader.Read();
                int numTickets = Convert.ToInt32(reader["NumTickets"]);
                string eventName = reader["EventName"].ToString();
                reader.Close();

                // Update the available seats
                string updateQuery = "UPDATE Events SET AvailableSeats = AvailableSeats + @NumTickets WHERE EventName = @EventName";
                SqlCommand updateCmd = new SqlCommand(updateQuery, conn);
                updateCmd.Parameters.AddWithValue("@NumTickets", numTickets);
                updateCmd.Parameters.AddWithValue("@EventName", eventName);
                updateCmd.ExecuteNonQuery();

                // Delete the booking
                string deleteQuery = "DELETE FROM Bookings WHERE BookingID = @BookingID";
                SqlCommand deleteCmd = new SqlCommand(deleteQuery, conn);
                deleteCmd.Parameters.AddWithValue("@BookingID", bookingId);
                deleteCmd.ExecuteNonQuery();

                Console.WriteLine("Booking canceled and database updated successfully.");
            }
        }

        // Retrieve booking details from the database
        public BookingTask11 GetBookingDetails(int bookingId)
        {
            using (SqlConnection conn = DBUtilTask11.getDBConn())
            {
                string query = "SELECT * FROM Bookings WHERE BookingID = @BookingID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@BookingID", bookingId);

                SqlDataReader reader = cmd.ExecuteReader();

                if (!reader.HasRows)
                {
                    throw new Exception("Booking not found.");
                }

                reader.Read();
                string eventName = reader["EventName"].ToString();
                int numTickets = Convert.ToInt32(reader["NumTickets"]);
                decimal totalCost = Convert.ToDecimal(reader["TotalCost"]);
                DateTime bookingDate = Convert.ToDateTime(reader["BookingDate"]);

                // Retrieve event details from the events table
                EventTask11 eventDetails = GetEventDetails().Find(e => e.EventName == eventName);
                List<CustomerTask11> customers = new List<CustomerTask11>(); 

                BookingTask11 booking = new BookingTask11(eventDetails, customers, numTickets);
                booking.BookingDate = bookingDate;
                booking.TotalCost = totalCost;

                return booking;
            }
        }

        // Helper method to calculate the booking cost
        private decimal CalculateBookingCost(int numTickets, decimal ticketPrice)
        {
            return numTickets * ticketPrice;
        }
    }
}
