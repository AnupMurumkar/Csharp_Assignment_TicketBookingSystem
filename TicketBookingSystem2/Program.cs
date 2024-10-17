using System;
using TicketBookingSystem.DAO;
using TicketBookingSystem.Model;
using TicketBookingSystem.Exceptions;
namespace TicketBookingSystem2Main
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Select which task to run:");
            Console.WriteLine("1: Task 1 (Conditional Statements)");
            Console.WriteLine("2: Task 2 (Nested Conditional Statements)");
            Console.WriteLine("3: Task 3 (Looping)");
            Console.WriteLine("4: Task 4 (Classes and Objects)");
            Console.WriteLine("5: Task 5(Inheritance and polymorphism");
            Console.WriteLine("6: Task 6(Abstraction) ");
            Console.WriteLine("7: Task 7(Has Relation)");
            Console.WriteLine("8: Task 8(Interface/abstract class, and Single Inheritance, static variable)");
            Console.WriteLine("10: Task 10( Collections)");
            Console.WriteLine("11: Task 10( DatabaseConnectivity)");

            int taskChoice = int.Parse(Console.ReadLine());
            try
            {
                switch (taskChoice)
                {
                    case 1:
                        RunTask1();
                        break;
                    case 2:
                        RunTask2();  // Task 2 method (nested conditionals)
                        break;
                    case 3:
                        RunTask3();  // Task 3 method (looping)
                        break;
                    case 4:
                        RunTask4();
                        break;
                    case 5:
                        RunTask5();
                        break;
                    case 6:
                        RunTask6();
                        break;
                    case 7:
                        RunTask7();
                        break;
                    case 8:
                        RunTask8();
                        break;
                    case 10:
                        RunTask10();
                        break;
                    case 11:
                        RunTask11();    
                        break;


                    default:
                        Console.WriteLine("Invalid task selection.");
                        break;
                }
            }
            catch(NullReferenceException ex)
                {
                    Console.WriteLine("Error: Null reference encountered! " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An unexpected error occurred: " + ex.Message);
            }
        }

        static void RunTask1()
        {
            IBookingServiceTask1 bookingService = new BookingServiceImplTask1();

            Console.WriteLine("Enter available tickets:");
            int availableTickets = int.Parse(Console.ReadLine());

            // Create a BookingTask1 object
            BookingTask1 booking = new BookingTask1(availableTickets);

            Console.WriteLine("Enter number of tickets to book:");
            int noOfTickets = int.Parse(Console.ReadLine());

            // Use the booking service to book tickets
            string result = bookingService.BookTickets(booking, noOfTickets);
            Console.WriteLine(result);
        }

        static void RunTask2()
        {
            IBookingServiceTask2 bookingService = new BookingServiceImplTask2();

            Console.WriteLine("Enter available tickets:");
            int availableTickets = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter ticket type (Silver, Gold, Diamond):");
            string ticketType = Console.ReadLine();

            // Create a BookingTask2 object
            BookingTask2 booking = new BookingTask2(availableTickets, ticketType);

            Console.WriteLine("Enter number of tickets to book:");
            int noOfTickets = int.Parse(Console.ReadLine());

            // Use the booking service to book tickets based on the ticket type
            string result = bookingService.BookTickets(booking, noOfTickets);
            Console.WriteLine(result);
        }

        static void RunTask3()
        {
            IBookingServiceTask3 bookingService = new BookingServiceImplTask3();

            Console.WriteLine("Enter available tickets:");
            int availableTickets = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter ticket type (Silver, Gold, Diamond):");
            string ticketType = Console.ReadLine();

            // Create a BookingTask3 object
            BookingTask3 booking = new BookingTask3(availableTickets, ticketType);

            while (true)
            {
                Console.WriteLine("Enter number of tickets to book (or type 'Exit' to quit):");
                string userInput = Console.ReadLine();

                if (userInput.Equals("Exit", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Exiting Task 3.");
                    break;
                }

                int noOfTickets;
                if (int.TryParse(userInput, out noOfTickets))
                {
                    // Use the booking service to book tickets based on the ticket type
                    string result = bookingService.BookTickets(booking, noOfTickets);
                    Console.WriteLine(result);
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid number of tickets or type 'Exit' to quit.");
                }
            }
        }

        static void RunTask4()
        {
            // Initialize Event and Booking services
            IEventServiceTask4 eventService = new EventServiceImplTask4();
            IBookingServiceTask4 bookingService = new BookingServiceImplTask4();
            ICustomerServiceTask4 customerService = new CustomerServiceImplTask4();
            IVenueServiceTask4 venueService = new VenueServiceImplTask4();

            // Create a venue
            VenueTask4 venue = new VenueTask4("Stadium", "123 Main St.");
            venueService.DisplayVenueDetails(venue);
            

            // Create an event
            EventTask4 concert = new EventTask4("Rock Concert", DateTime.Now.AddDays(10), new TimeSpan(18, 0, 0), venue.VenueName, 100, 1500, "Concert");
            eventService.DisplayEventDetails(concert);

            // Create a customer
            CustomerTask4 customer = new CustomerTask4("John Doe", "john@example.com", "555-1234");
            customerService.DisplayCustomerDetails(customer);

            // Book tickets for the event
            eventService.BookTickets(concert, 5);
            eventService.DisplayEventDetails(concert);

            // Create a booking object with uninitialized TotalCost (will calculate afterward)
            BookingTask4 booking = new BookingTask4(1, concert, 5, 0, DateTime.Now);

            // Calculate the total cost of the booking
            booking.TotalCost = bookingService.CalculateBookingCost(booking);

            // Display booking details
            bookingService.GetEventDetails(booking);
            Console.WriteLine($"Booking ID: {booking.BookingId}, Number of Tickets: {booking.NumTickets}, Total Cost: {booking.TotalCost}");

            // Cancel some tickets and update the event
            Console.WriteLine("Canceling 2 tickets...");
            bookingService.CancelBooking(booking, 2);
            eventService.DisplayEventDetails(concert);

            // Show final revenue for the event
            decimal totalRevenue = eventService.CalculateTotalRevenue(concert);
            Console.WriteLine($"Total revenue for the event: {totalRevenue}");
        }

        static void RunTask5()
        {
            ITicketBookingServiceTask5 bookingService = new TicketBookingServiceImplTask5();
            IEventServiceTask5 eventService = new EventServiceImplTask5();

            while (true)
            {
                Console.WriteLine("Select the type of event to create:");
                Console.WriteLine("1. Movie");
                Console.WriteLine("2. Concert");
                Console.WriteLine("3. Sports");
                Console.WriteLine("4. Exit");
                int choice = int.Parse(Console.ReadLine());

                if (choice == 4) break;

                Console.WriteLine("Enter event name:");
                string eventName = Console.ReadLine();

                Console.WriteLine("Enter venue name:");
                string venueName = Console.ReadLine();

                Console.WriteLine("Enter total seats:");
                int totalSeats = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter ticket price:");
                decimal ticketPrice = decimal.Parse(Console.ReadLine());

                Console.WriteLine("Enter event date (yyyy-mm-dd):");
                string eventDate = Console.ReadLine();

                Console.WriteLine("Enter event time (hh:mm):");
                string eventTime = Console.ReadLine();

                EventTask5 eventObj = null;
                switch (choice)
                {
                    case 1: // Movie
                        Console.WriteLine("Enter movie genre:");
                        string genre = Console.ReadLine();
                        Console.WriteLine("Enter actor name:");
                        string actorName = Console.ReadLine();
                        Console.WriteLine("Enter actress name:");
                        string actressName = Console.ReadLine();
                        eventObj = bookingService.create_event(eventName, eventDate, eventTime, totalSeats, ticketPrice, "movie", venueName, genre, actorName,actressName);
                        break;
                    case 2: // Concert
                        Console.WriteLine("Enter artist name:");
                        string artist = Console.ReadLine();
                        Console.WriteLine("Enter concert type (Theatrical, Classical, Rock, Recital):");
                        string type = Console.ReadLine();
                        eventObj = bookingService.create_event(eventName, eventDate, eventTime, totalSeats, ticketPrice, "concert", venueName, artist, type , null);
                        break;
                    case 3: // Sports
                        Console.WriteLine("Enter sport name:");
                        string sportName = Console.ReadLine();
                        Console.WriteLine("Enter team names (e.g., India vs Pakistan):");
                        string teamsName = Console.ReadLine();
                        eventObj = bookingService.create_event(eventName, eventDate, eventTime, totalSeats, ticketPrice, "sports", venueName, sportName, teamsName ,null);
                        break;
                }

                // Display event details using polymorphism
                eventService.display_event_details(eventObj);

                // Book tickets
                Console.WriteLine("Enter number of tickets to book:");
                int numTickets = int.Parse(Console.ReadLine());
                decimal cost = eventService.book_tickets(eventObj, numTickets);
                Console.WriteLine($"Total cost: {cost}");

                // Cancel tickets
                Console.WriteLine("Do you want to cancel tickets? (yes/no)");
                string cancelChoice = Console.ReadLine();
                if (cancelChoice.ToLower() == "yes")
                {
                    Console.WriteLine("Enter number of tickets to cancel:");
                    int cancelTickets = int.Parse(Console.ReadLine());
                    eventService.cancel_tickets(eventObj, cancelTickets);
                }
            }
        }

        static void RunTask6()
        {
            TicketBookingSystemImplTask6 bookingSystem = new TicketBookingSystemImplTask6();

            while (true)
            {
                Console.WriteLine("\nCommands: create_event, book_tickets, cancel_tickets, get_available_seats, display_event, exit");
                string command = Console.ReadLine();

                if (command == "exit")
                    break;

                switch (command)
                {
                    case "create_event":
                        Console.WriteLine("Enter event type (movie, concert, sports):");
                        string eventType = Console.ReadLine();
                        Console.WriteLine("Enter event name:");
                        string eventName = Console.ReadLine();
                        Console.WriteLine("Enter venue name:");
                        string venueName = Console.ReadLine();
                        Console.WriteLine("Enter total seats:");
                        int totalSeats = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter ticket price:");
                        decimal ticketPrice = decimal.Parse(Console.ReadLine());
                        Console.WriteLine("Enter event date (yyyy-mm-dd):");
                        string eventDate = Console.ReadLine();
                        Console.WriteLine("Enter event time (hh:mm):");
                        string eventTime = Console.ReadLine();
                        Console.WriteLine("Enter extra attribute 1:");
                        string extraAttribute1 = Console.ReadLine();
                        Console.WriteLine("Enter extra attribute 2:");
                        string extraAttribute2 = Console.ReadLine();

                        bookingSystem.create_event(eventName, eventDate, eventTime, totalSeats, ticketPrice, eventType, venueName, extraAttribute1, extraAttribute2);
                        break;

                    case "book_tickets":
                        Console.WriteLine("Enter event name:");
                        eventName = Console.ReadLine();
                        Console.WriteLine("Enter number of tickets:");
                        int numTickets = int.Parse(Console.ReadLine());
                        bookingSystem.book_tickets(eventName, numTickets);
                        break;

                    case "cancel_tickets":
                        Console.WriteLine("Enter event name:");
                        eventName = Console.ReadLine();
                        Console.WriteLine("Enter number of tickets to cancel:");
                        numTickets = int.Parse(Console.ReadLine());
                        bookingSystem.cancel_tickets(eventName, numTickets);
                        break;

                    case "get_available_seats":
                        Console.WriteLine("Enter event name:");
                        eventName = Console.ReadLine();
                        int availableSeats = bookingSystem.get_available_seats(eventName);
                        Console.WriteLine($"Available seats: {availableSeats}");
                        break;

                    case "display_event":
                        Console.WriteLine("Enter event name:");
                        eventName = Console.ReadLine();
                        bookingSystem.display_event_details(eventName);
                        break;

                    default:
                        Console.WriteLine("Invalid command.");
                        break;
                }
            }
        }

        static void RunTask7()
        {
            BookingSystemImplTask7 bookingSystem = new BookingSystemImplTask7();

            while (true)
            {
                Console.WriteLine("\nCommands: create_event, book_tickets, cancel_tickets, get_available_seats, get_event_details, exit");
                string command = Console.ReadLine();

                if (command == "exit")
                    break;

                switch (command)
                {
                    case "create_event":
                        Console.WriteLine("Enter event type (movie, concert, sports):");
                        string eventType = Console.ReadLine();
                        Console.WriteLine("Enter event name:");
                        string eventName = Console.ReadLine();
                        Console.WriteLine("Enter venue name:");
                        string venueName = Console.ReadLine();
                        Console.WriteLine("Enter venue address:");
                        string venueAddress = Console.ReadLine();
                        VenueTask7 venue = new VenueTask7(venueName, venueAddress);
                        Console.WriteLine("Enter total seats:");
                        int totalSeats = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter ticket price:");
                        decimal ticketPrice = decimal.Parse(Console.ReadLine());
                        Console.WriteLine("Enter event date (yyyy-mm-dd):");
                        string eventDate = Console.ReadLine();
                        Console.WriteLine("Enter event time (hh:mm):");
                        string eventTime = Console.ReadLine();
                        Console.WriteLine("Enter extra attribute 1:");
                        string extraAttribute1 = Console.ReadLine();
                        Console.WriteLine("Enter extra attribute 2:");
                        string extraAttribute2 = Console.ReadLine();

                        bookingSystem.create_event(eventName, eventDate, eventTime, totalSeats, ticketPrice, eventType, venue, extraAttribute1, extraAttribute2);
                        break;

                    case "book_tickets":
                        Console.WriteLine("Enter event name:");
                        eventName = Console.ReadLine();
                        Console.WriteLine("Enter number of tickets:");
                        int numTickets = int.Parse(Console.ReadLine());

                        CustomerTask7[] customers = new CustomerTask7[numTickets];
                        for (int i = 0; i < numTickets; i++)
                        {
                            Console.WriteLine($"Enter details for customer {i + 1}:");
                            Console.WriteLine("Customer name:");
                            string customerName = Console.ReadLine();
                            Console.WriteLine("Customer email:");
                            string customerEmail = Console.ReadLine();
                            Console.WriteLine("Customer phone number:");
                            string customerPhone = Console.ReadLine();
                            customers[i] = new CustomerTask7(customerName, customerEmail, customerPhone);
                        }

                        bookingSystem.book_tickets(eventName, numTickets, customers);
                        break;

                    case "cancel_tickets":
                        Console.WriteLine("Enter booking ID:");
                        int bookingId = int.Parse(Console.ReadLine());
                        bookingSystem.cancel_booking(bookingId);
                        break;

                    case "get_available_seats":
                        Console.WriteLine("Enter event name:");
                        eventName = Console.ReadLine();
                        int availableSeats = bookingSystem.getAvailableNoOfTickets(eventName);
                        Console.WriteLine($"Available seats: {availableSeats}");
                        break;

                    case "get_event_details":
                        Console.WriteLine("Enter event name:");
                        eventName = Console.ReadLine();
                        bookingSystem.getEventDetails(eventName);
                        break;

                    default:
                        Console.WriteLine("Invalid command.");
                        break;
                }
            }
        }

        static void RunTask8()
        {
            BookingSystemServiceProviderImplTask8 bookingSystem = new BookingSystemServiceProviderImplTask8();

            while (true)
            {
                Console.WriteLine("\nCommands: create_event, book_tickets, cancel_tickets, get_available_seats, get_event_details, exit");
                string command = Console.ReadLine();

                if (command == "exit")
                    break;
                try
                {
                    switch (command)
                    {
                        case "create_event":
                            Console.WriteLine("Enter event type (movie, concert, sports):");
                            string eventType = Console.ReadLine();
                            Console.WriteLine("Enter event name:");
                            string eventName = Console.ReadLine();
                            Console.WriteLine("Enter venue name:");
                            string venueName = Console.ReadLine();
                            Console.WriteLine("Enter venue address:");
                            string venueAddress = Console.ReadLine();
                            VenueTask8 venue = new VenueTask8(venueName, venueAddress);
                            Console.WriteLine("Enter total seats:");
                            int totalSeats = int.Parse(Console.ReadLine());
                            Console.WriteLine("Enter ticket price:");
                            decimal ticketPrice = decimal.Parse(Console.ReadLine());
                            Console.WriteLine("Enter event date (yyyy-mm-dd):");
                            string eventDate = Console.ReadLine();
                            Console.WriteLine("Enter event time (hh:mm):");
                            string eventTime = Console.ReadLine();

                            bookingSystem.create_event(eventName, eventDate, eventTime, totalSeats, ticketPrice, eventType, venue);
                            break;

                        case "book_tickets":
                            Console.WriteLine("Enter event name:");
                            eventName = Console.ReadLine();
                            Console.WriteLine("Enter number of tickets:");
                            int numTickets = int.Parse(Console.ReadLine());

                            CustomerTask8[] customers = new CustomerTask8[numTickets];
                            for (int i = 0; i < numTickets; i++)
                            {
                                Console.WriteLine($"Enter details for customer {i + 1}:");
                                Console.WriteLine("Customer name:");
                                string customerName = Console.ReadLine();
                                Console.WriteLine("Customer email:");
                                string customerEmail = Console.ReadLine();
                                Console.WriteLine("Customer phone number:");
                                string customerPhone = Console.ReadLine();
                                customers[i] = new CustomerTask8(customerName, customerEmail, customerPhone);
                            }

                            bookingSystem.book_tickets(eventName, numTickets, customers);
                            break;

                        case "cancel_tickets":
                            Console.WriteLine("Enter booking ID:");
                            int bookingId = int.Parse(Console.ReadLine());
                            bookingSystem.cancel_booking(bookingId);
                            break;

                        case "get_available_seats":
                            Console.WriteLine("Enter event name:");
                            eventName = Console.ReadLine();
                            int availableSeats = bookingSystem.getAvailableNoOfTickets(eventName);
                            Console.WriteLine($"Available seats: {availableSeats}");
                            break;

                        case "get_event_details":
                            EventTask8[] events = bookingSystem.getEventDetails();
                            foreach (var eventObj in events)
                            {
                                eventObj.display_event_details();
                            }
                            break;

                        default:
                            Console.WriteLine("Invalid command.");
                            break;
                    }
                }
                catch(EventNotFoundExceptionTask9 ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
                catch (InvalidBookingIDExceptionTask9 ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An unexpected error occurred: " + ex.Message);
                }
            }
        }

        static void RunTask10()
        {
            IBookingSystemRepositoryTask10 bookingRepository = new BookingSystemRepositoryImplTask10();

            while (true)
            {
                Console.WriteLine("\n--- Ticket Booking System ---");
                Console.WriteLine("1. Create Event");
                Console.WriteLine("2. Book Tickets");
                Console.WriteLine("3. Cancel Booking");
                Console.WriteLine("4. Get Available Seats");
                Console.WriteLine("5. Get Event Details");
                Console.WriteLine("6. Exit");
                Console.Write("Select an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        CreateEvent(bookingRepository);
                        break;

                    case "2":
                        BookTickets(bookingRepository);
                        break;

                    case "3":
                        CancelBooking(bookingRepository);
                        break;

                    case "4":
                        GetAvailableSeats(bookingRepository);
                        break;

                    case "5":
                        GetEventDetails(bookingRepository);
                        break;

                    case "6":
                        Console.WriteLine("Exiting the system. Thank you!");
                        return;

                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }


            static void CreateEvent(IBookingSystemRepositoryTask10 bookingRepository)
            {
                Console.Write("Enter Event Name: ");
                string eventName = Console.ReadLine();

                Console.Write("Enter Event Date (yyyy-mm-dd): ");
                DateTime eventDate = DateTime.Parse(Console.ReadLine());

                Console.Write("Enter Event Time (hh:mm): ");
                TimeSpan eventTime = TimeSpan.Parse(Console.ReadLine());

                Console.Write("Enter Venue Name: ");
                string venueName = Console.ReadLine();

                Console.Write("Enter Venue Address: ");
                string venueAddress = Console.ReadLine();
                VenueTask10 venue = new VenueTask10(venueName, venueAddress);

                Console.Write("Enter Total Seats: ");
                int totalSeats = int.Parse(Console.ReadLine());

                Console.Write("Enter Ticket Price: ");
                decimal ticketPrice = decimal.Parse(Console.ReadLine());

                Console.Write("Enter Event Type (Movie, Concert, Sports): ");
                string eventType = Console.ReadLine();

                EventTask10 newEvent = new EventTask10(1, eventName, eventDate, eventTime, venue, totalSeats, ticketPrice, eventType);
                bookingRepository.CreateEvent(newEvent);
                Console.WriteLine("Event created successfully!");
            }

            static void BookTickets(IBookingSystemRepositoryTask10 bookingRepository)
            {
                Console.Write("Enter Event Name: ");
                string eventName = Console.ReadLine();

                Console.Write("Enter Number of Tickets: ");
                int numTickets = int.Parse(Console.ReadLine());

                Console.Write("Enter Customer Name: ");
                string customerName = Console.ReadLine();
                Console.Write("Enter Email: ");
                string email = Console.ReadLine();
                Console.Write("Enter Phone Number: ");
                string phoneNumber = Console.ReadLine();

                CustomerTask10 customer = new CustomerTask10(customerName, email, phoneNumber);
                HashSet<CustomerTask10> customers = new HashSet<CustomerTask10> { customer };

                var booking = new BookingTask10(bookingRepository.GetEventDetails().Find(e => e.EventName.Equals(eventName, StringComparison.OrdinalIgnoreCase)),
                                                          new HashSet<CustomerTask10> { customer }, numTickets);

                bookingRepository.BookTickets(booking);
                Console.WriteLine("Booking successful!");
            }

            static void CancelBooking(IBookingSystemRepositoryTask10 bookingRepository)
            {
                Console.Write("Enter Booking ID: ");
                int bookingId = int.Parse(Console.ReadLine());
                bookingRepository.CancelBooking(bookingId);
                Console.WriteLine("Booking canceled successfully!");
            }

            static void GetAvailableSeats(IBookingSystemRepositoryTask10 bookingRepository)
            {
                Console.Write("Enter Event Name: ");
                string eventName = Console.ReadLine();
                int availableSeats = bookingRepository.GetAvailableNoOfTickets(eventName);
                Console.WriteLine($"Available Seats for {eventName}: {availableSeats}");
            }

            static void GetEventDetails(IBookingSystemRepositoryTask10 bookingRepository)
            {
                foreach (var eventObj in bookingRepository.GetEventDetails())
                {
                    Console.WriteLine($"Event Name: {eventObj.EventName}, Date: {eventObj.EventDate}, Available Seats: {eventObj.AvailableSeats}");
                }
            }
        }

        static void RunTask11()
        {
            IBookingSystemRepositoryTask11 bookingRepository = new BookingSystemRepositoryImplTask11();

            while (true)
            {
                Console.WriteLine("\n--- Ticket Booking System ---");
                Console.WriteLine("1. Create Event");
                Console.WriteLine("2. Book Tickets");
                Console.WriteLine("3. Cancel Booking");
                Console.WriteLine("4. Get Available Seats");
                Console.WriteLine("5. Get Event Details");
                Console.WriteLine("6. Exit");
                Console.Write("Select an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        CreateEvent(bookingRepository);
                        break;

                    case "2":
                        BookTickets(bookingRepository);
                        break;

                    case "3":
                        CancelBooking(bookingRepository);
                        break;

                    case "4":
                        GetAvailableSeats(bookingRepository);
                        break;

                    case "5":
                        GetEventDetails(bookingRepository);
                        break;

                    case "6":
                        Console.WriteLine("Exiting the system. Thank you!");
                        return;

                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        static void CreateEvent(IBookingSystemRepositoryTask11 bookingRepository)
        {
            Console.Write("Enter Event Name: ");
            string eventName = Console.ReadLine();

            Console.Write("Enter Event Date (yyyy-mm-dd): ");
            string eventDate = Console.ReadLine();

            Console.Write("Enter Event Time (hh:mm): ");
            string eventTime = Console.ReadLine();

            Console.Write("Enter Venue Name: ");
            string venueName = Console.ReadLine();

            Console.Write("Enter Venue Address: ");
            string venueAddress = Console.ReadLine();
            VenueTask11 venue = new VenueTask11(venueName, venueAddress);

            Console.Write("Enter Total Seats: ");
            int totalSeats = int.Parse(Console.ReadLine());

            Console.Write("Enter Ticket Price: ");
            decimal ticketPrice = decimal.Parse(Console.ReadLine());

            Console.Write("Enter Event Type (Movie, Concert, Sports): ");
            string eventType = Console.ReadLine();

            bookingRepository.CreateEvent(eventName, eventDate, eventTime, totalSeats, ticketPrice, eventType, venue);
            Console.WriteLine("Event created successfully!");
        }

        static void BookTickets(IBookingSystemRepositoryTask11 bookingRepository)
        {
            Console.Write("Enter Event Name: ");
            string eventName = Console.ReadLine();

            Console.Write("Enter Number of Tickets: ");
            int numTickets = int.Parse(Console.ReadLine());

            List<CustomerTask11> customers = new List<CustomerTask11>();
            for (int i = 0; i < numTickets; i++)
            {
                Console.WriteLine($"Enter details for customer {i + 1}:");
                Console.Write("Customer Name: ");
                string customerName = Console.ReadLine();
                Console.Write("Customer Email: ");
                string email = Console.ReadLine();
                Console.Write("Customer Phone: ");
                string phone = Console.ReadLine();
                customers.Add(new CustomerTask11(customerName, email, phone));
            }

            bookingRepository.BookTickets(eventName, numTickets, customers);
            Console.WriteLine("Tickets booked successfully!");
        }

        static void CancelBooking(IBookingSystemRepositoryTask11 bookingRepository)
        {
            Console.Write("Enter Booking ID: ");
            int bookingId = int.Parse(Console.ReadLine());
            bookingRepository.CancelBooking(bookingId);
            Console.WriteLine("Booking canceled successfully!");
        }

        static void GetAvailableSeats(IBookingSystemRepositoryTask11 bookingRepository)
        {
            Console.Write("Enter Event Name: ");
            string eventName = Console.ReadLine();
            int availableSeats = bookingRepository.GetAvailableNoOfTickets(eventName);
            Console.WriteLine($"Available seats for {eventName}: {availableSeats}");
        }

        static void GetEventDetails(IBookingSystemRepositoryTask11 bookingRepository)
        {
            foreach (var eventObj in bookingRepository.GetEventDetails())
            {
                eventObj.DisplayEventDetails();
            }
        }

    }
}
