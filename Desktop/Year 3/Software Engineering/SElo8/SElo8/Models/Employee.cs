using SElo8.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SElo8.Models
{
    public class Employee
    {
        public string? Name { get; set; }
        public int TicketPercentage { get; set; }

        public double Income { get; set; }

        public Employee(string name, int ticketPercentage) 
        {
            Name = name;
            TicketPercentage = ticketPercentage;
        }
        public void Refuel(Vehicle vehicle)
        {
            vehicle.Fuel = 100;
        }

        public void ParkVehicle(Vehicle vehicle, Train train)
        {
            if (!train.IsFull())
            {
                train.Vehicles.Add(vehicle);
            }
        }

        public double DetermineEmployeeSalary(Vehicle vehicle)
        {
            double salary = vehicle.Ticketprice * (TicketPercentage / 100.0);
            Income += salary;
            return salary;
        }

        public override string ToString()
        => $"Name: {Name}, Ticket Percentage: {TicketPercentage}";
    }
}
