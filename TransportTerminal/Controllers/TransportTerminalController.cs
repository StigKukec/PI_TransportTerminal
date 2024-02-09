using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using System.Text.Json;
using TransportTerminal.DAL.DALModels;
using TransportTerminal.DAL.Repositories;

namespace TransportTerminal.Controllers
{
    public class TransportTerminalController : Controller
    {
        #region constants
        private const string bigVehiclePatrialView = "BigVehiclePartial";
        private const string smallVehiclePatrialView = "SmallVehiclePartial";
        private const string totalIncomePatrialView = "TotalIncomePartial";
        private const string employeeIncomePatrialView = "EmployeeIncomePartial";
        #endregion
        private RepositoryFactory _repoFactory = RepositoryFactory.Instance;
        private List<BigVehicle> _bigVehicles;
        private List<SmallVehicle> _smallVehicles;

        public TransportTerminalController()
        {
            Init();
        }

        private void Init()
        {
            _bigVehicles = _repoFactory.Files.Value.GetBigVehicles();
            _smallVehicles = _repoFactory.Files.Value.GetSmallVehicles();
        }

        // GET: TransportTerminalController
        public ActionResult Index()
        {
            var bigVehicles = GetDerivedClasses(typeof(Vehicle), typeof(BigVehicle));
            var smallVehicles = GetDerivedClasses(typeof(Vehicle), typeof(SmallVehicle));
           
            ViewBag.BigVehicles = bigVehicles;
            ViewBag.SmallVehicles = smallVehicles;

            return View();
        }
        public ActionResult BigVehiclesPartial(string type)
        {
            switch (type)
            {
                case nameof(TransportTruck):
                    var tTruck = TransportTruck();
                    _bigVehicles.Add(tTruck);
                    break;
                case nameof(Bus):
                    var bus = Bus();
                    _bigVehicles.Add(bus);
                    break;
                default:
                    break;
            }
            List<Vehicle> vehicles = new(_bigVehicles);
            vehicles.ToList().ForEach(v => _repoFactory.Files.Value.SaveData(v));

            return PartialView(bigVehiclePatrialView, _bigVehicles);
        }
        public ActionResult SmallVehiclesPartial(string type)
        {
            switch (type)
            {
                case nameof(Van):
                    var van = Van();
                    _smallVehicles.Add(van);
                    break;
                case nameof(Car):
                    var car = Car();
                    _smallVehicles.Add(car);
                    break;
                default:
                    break;
            }
            List<Vehicle> vehicles = new(_smallVehicles);
            vehicles.ToList().ForEach(v => _repoFactory.Files.Value.SaveData(v));

            return PartialView(smallVehiclePatrialView, _smallVehicles);
        }
        public ActionResult TotalIncomePartial()
        {
            List<Vehicle> vehicles = new();
            vehicles.AddRange(_bigVehicles);
            vehicles.AddRange(_smallVehicles);

            var totalIncome = _repoFactory.IncomeAnalysis.Value.TicketIncome(vehicles);
            ViewBag.TotalIncome = totalIncome;

            return PartialView(totalIncomePatrialView, vehicles);
        }
        public ActionResult EmployeeIncomePartial()
        {
            List<Vehicle> vehicles = new ();
            vehicles.AddRange(_bigVehicles);
            vehicles.AddRange(_smallVehicles);

            var employeeIncome = _repoFactory.IncomeAnalysis.Value.EmployeeIncome(vehicles);
            ViewBag.EmployeeIncome = employeeIncome;

            return PartialView(employeeIncomePatrialView, vehicles);
        }
        static IEnumerable<Type> GetDerivedClasses(Type baseClass, Type subClass)
        {
            var derivedClasses = Assembly.GetAssembly(baseClass)
                .GetTypes()
                .Where(type => type.IsSubclassOf(subClass));

            return derivedClasses;
        }
        public ActionResult DeleteVehicles()
        {
            _repoFactory.Files.Value.DeleteAll();
            return Ok();
        }
       
        public Car Car()
        {
            var car = new Car();
            return car;
        }
        public Van Van()
        {
            var van = new Van();
            return van;
        }
        public TransportTruck TransportTruck()
        {
            var transportTruck = new TransportTruck();
            return transportTruck;
        }
        public Bus Bus()
        {
            var bus = new Bus();
            return bus;
        }
    }
}
