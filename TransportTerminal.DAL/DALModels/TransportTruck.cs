using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportTerminal.DAL.DALModels
{
    public class TransportTruck : BigVehicle
    {
        public override double TicketPrice { get; set; } = 90;

    }
}
