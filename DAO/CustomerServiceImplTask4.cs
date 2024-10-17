using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBookingSystem.Model;

namespace TicketBookingSystem.DAO
{
    public class CustomerServiceImplTask4 : ICustomerServiceTask4
    {
        public void DisplayCustomerDetails(CustomerTask4 customer)
        {
            Console.WriteLine($"CustomerName : {customer.CustomerName}, phoneNumber: {customer.PhoneNumber}, Email : {customer.Email}");
        }
    }
}
