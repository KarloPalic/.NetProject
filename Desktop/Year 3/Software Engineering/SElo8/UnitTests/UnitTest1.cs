using SElo8.Enums;
using SElo8.Models;
using SElo8.Repository;

namespace UnitTests
{
    public class Tests
    {
        private Employee emploee;
        private Vehicle vehicle;
        private Train train;
        private VehicleRepository vehicleRepository;
        private EmployeeRepository employeeRepository;

        [SetUp]
        public void Setup()
        {
            emploee = new Employee("Karlo", 11);
            vehicle = new Car(FuelType.Gas, "Lambo");
            train = new Train(TrainType.Small);
            vehicleRepository = new VehicleRepository();
            employeeRepository = new EmployeeRepository();
        }

        [Test]
        public void TestCarTicketPrice()
        {
            Assert.Equals(vehicle.Ticketprice, 7);
        }

        [Test]
        public void TestEmployeeRefuel()
        {
            vehicle.Fuel = 7;
            emploee.Refuel(vehicle);
            if (vehicle.Fuel < 10)
            {
                Assert.Fail();
            }
            else
            {
                Assert.Pass();
            }
        }

        [Test]
        public void TestVehicleDeparted()
        {
            vehicleRepository.Depart(vehicle);
            if (vehicleRepository.GetDeparted().Contains(vehicle))
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail();
            }
        }

        [Test]
        public void TestTrainCapacity()
        {
            emploee.ParkVehicle(vehicle, train);
            train.Capacity = 4;
            Assert.IsTrue(train.IsFull());
        }

        [Test]
        public void TestAddEmployee()
        {
            employeeRepository.AddEmployee(emploee);
            if (employeeRepository.GetAll().Contains(emploee))
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail();
            }
        }
        [Test]
        public void TestVehicleAdd()
        {
            vehicleRepository.AddVehicle(vehicle);
            if (vehicleRepository.GetVehicles().Contains(vehicle))
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail();
            }
        }

        [Test] 
        public void TestEmployeeByName()
        { 
            string desiredName = "Karlo";

            Assert.Equals(emploee.Name, desiredName);
        }
    }
}