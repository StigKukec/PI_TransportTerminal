using FluentAssertions;
using TransportTerminal.DAL.DALModels;
using TransportTerminal.DAL.Repositories;

namespace TransportTerminal.Test
{
    public class IncomeAnalysisTest
    {
        [Fact]
        public void IncomeAnalysis_EmployeeIncome_ReturnDouble()
        {
            //Arange
            RepositoryFactory repo = RepositoryFactory.Instance;
            Car car = new Car();
            Bus bus = new Bus();
            List<Vehicle> vehicles = new List<Vehicle>
            {
                car,
                bus
            };
            //Act
            var result = repo.IncomeAnalysis.Value.EmployeeIncome(vehicles);

            //Assert
            result.Should().Be(12);
            result.Should().NotBe(null);

        }

        [Fact]
        public void IncomeAnalysis_TicketIncome_ReturnDouble()
        {
            //Arange
            RepositoryFactory repo = RepositoryFactory.Instance;
            Car car = new Car();
            Bus bus = new Bus();
            List<Vehicle> vehicles = new List<Vehicle>
            {
                car,
                bus
            };
            //Act
            var result = repo.IncomeAnalysis.Value.TicketIncome(vehicles);

            //Assert
            result.Should().Be(120);
            result.Should().NotBe(null);

        }
    }
}