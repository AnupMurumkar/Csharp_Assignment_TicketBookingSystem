namespace TicketBookingSystem.Model
{
    public class CustomerTask7
    {
        public string CustomerName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        // Constructor
        public CustomerTask7(string customerName, string email, string phoneNumber)
        {
            CustomerName = customerName;
            Email = email;
            PhoneNumber = phoneNumber;
        }

        // Display customer details
        public void display_customer_details()
        {
            Console.WriteLine($"Customer: {CustomerName}, Email: {Email}, Phone: {PhoneNumber}");
        }
    }
}
