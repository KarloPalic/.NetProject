using SElo8.Enums;
using SElo8.Models;
using SElo8.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SElo8
{
    class Program
    {
        private static EmployeeRepository employeeRepository = new EmployeeRepository();
        private static VehicleRepository vehicleRepository = new VehicleRepository();
        static void Main(string[] args)
        {
            InitData();
            while (true)
            {
                Console.WriteLine(
                    "To buy a ticket enter command (buy)\n" +
                    "To check Train capacity enter command (vehicles)\n" +
                    "To check employee enter command (employee)");

                string command = Console.ReadLine();

                switch (command)
                {
                    case "buy":
                        BuyTicket();
                        break;

                    case "vehicles":
                        CheckVehicles();
                        break;

                    case "employee":
                        CheckEmployees();
                        break;

                    default:
                        Console.WriteLine("Invalid command. Try again.");
                        break;
                }
            }
        }

        private static void CheckEmployees()
        {
            List<Employee> employees = employeeRepository.GetAll();
            Console.WriteLine("Employees\n");
            foreach (Employee employee in employees)
            {
                Console.WriteLine($"Employee Name: {employee.Name}, Salary: {employee.TicketPercentage}, Income: {employee.Income}");
            }
        }

        private static void CheckVehicles()
        {
            List<Vehicle> vehicles = vehicleRepository.GetVehicles();
            List<Vehicle> departed = vehicleRepository.GetDeparted();

            Console.WriteLine("Available Vehicles:\n");
            foreach (Vehicle vehicle in vehicles)
            {
                Console.WriteLine($"Ticket price: {vehicle.Ticketprice}, Name: {vehicle.Name}, Fuel Type: {vehicle.TypeOfFuel}, Fuel: {vehicle.Fuel}");
            }

            Console.WriteLine("Departed Vehicles:\n");
            foreach (Vehicle vehicle1 in departed)
            {
                Console.WriteLine($"Ticket price: {vehicle1.Ticketprice}, Name: {vehicle1.Name}, Fuel Type: {vehicle1.TypeOfFuel}, Fuel: {vehicle1.Fuel}");
            }
        }

        private static void BuyTicket()
        {
            Vehicle vehicle = SelectRandomVehicle();
            Console.WriteLine($"Your vehicle: {vehicle}");

            Employee employee = SelectRandomEmployee();
            Console.WriteLine($"The employee: {employee.Name} has earnings: {employee.DetermineEmployeeSalary(vehicle)}");

            Console.WriteLine($"Fuel is at: {vehicle.Fuel}");
            if (vehicle.Fuel < 10)
            {
                employee.Refuel(vehicle);
                Console.WriteLine("Vehicle has been refueled");
                Console.WriteLine($"Fuel is now at: {vehicle.Fuel}");
            }

            if (vehicle.TypeOfTrain == TrainType.Small)
            {
                employee.ParkVehicle(vehicle, new Train(TrainType.Small));
                Console.WriteLine("Vehicle has been parked into the small train");
            }
            else
            {
                employee.ParkVehicle(vehicle, new Train(TrainType.Large));
                Console.WriteLine("Vehicle has been parked into the large train");
            }

            vehicleRepository.Depart(vehicle);
            Console.WriteLine("Vehicle departed");
        }

        private static Employee SelectRandomEmployee()
        {
            Random random = new Random();
            List<Employee> employees = employeeRepository.GetAll();
            int employeeIndex = random.Next(employees.Count);
            return employees[employeeIndex];
        }

        private static Vehicle SelectRandomVehicle()
        {
            Random random = new Random();
            List<Vehicle> vehicles = vehicleRepository.GetVehicles();
            int vehicleIndex = random.Next(vehicles.Count);
            return vehicles[vehicleIndex];
        }

        private static void InitData()
        {
            employeeRepository.AddEmployee(new Employee("Karlo", 10));
            employeeRepository.AddEmployee(new Employee("Banana", 11));

            vehicleRepository.AddVehicle(new Car(FuelType.Battery, "Car"));
            vehicleRepository.AddVehicle(new Van(FuelType.Gas, "Van"));
            vehicleRepository.AddVehicle(new Truck(FuelType.Gas, "Truck"));
            vehicleRepository.AddVehicle(new Bus(FuelType.Battery, "Bus"));
        }
    }
}
