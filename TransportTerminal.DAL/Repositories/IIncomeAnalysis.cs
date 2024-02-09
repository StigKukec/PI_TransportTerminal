using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportTerminal.DAL.DALModels;

namespace TransportTerminal.DAL.Repositories
{
    public interface IIncomeAnalysis
    {
        double TicketIncome(List<Vehicle> vehicle);
        double EmployeeIncome(List<Vehicle> vehicles);

    }
}
