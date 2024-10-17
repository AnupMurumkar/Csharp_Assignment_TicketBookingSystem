using System;
using System.Data.SqlClient;

namespace TicketBookingSystem.utils
{
    public static class DBUtilTask11
    {
        private static string connectionString = "Data Source=LAPTOP-8JT18MT0;Initial Catalog=TicketBookingSystem;Integrated Security=True;"; 

        public static SqlConnection getDBConn()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            return connection;
        }
    }
}
