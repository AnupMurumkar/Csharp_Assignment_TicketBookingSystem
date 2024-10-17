using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TicketBookingSystem.Model;

namespace DAO
{
    internal interface ISportService
    {
        public void DisplaySportDetails(SportsTask5 sports);
    }
}
