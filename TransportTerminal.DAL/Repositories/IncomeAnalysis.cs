using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportTerminal.DAL.DALModels;

namespace TransportTerminal.DAL.Repositories
{
    internal class IncomeAnalysis : IIncomeAnalysis
    {
        public double EmployeeIncome(List<Vehicle> vehicles)
        {
            double employeeIncome = 0;
            foreach (var vehicle in vehicles)
            {
                var incomePercent = (vehicle.TicketPrice * 10) / 100;
                employeeIncome += incomePercent;
            }
            return employeeIncome;
        }

        public double TicketIncome(List<Vehicle> vehicles)
        {
            double ticketIncome = 0;
            foreach (var vehicle in vehicles)
            {
                ticketIncome += vehicle.TicketPrice;
            }
            return ticketIncome;
        }
    }
}
