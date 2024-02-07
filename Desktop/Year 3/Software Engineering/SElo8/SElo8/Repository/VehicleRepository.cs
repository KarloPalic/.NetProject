using SElo8.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SElo8.Repository
{
    public class VehicleRepository : IVehicleRepository
    {
        private List<Vehicle> vehicles;
        private List<Vehicle> departed;

        public VehicleRepository()
        {
            vehicles = new List<Vehicle>();
            departed = new List<Vehicle>();
        }
        public void AddVehicle(Vehicle vehicle)
        {
            vehicles.Add(vehicle);
        }

        public void Depart(Vehicle vehicle)
        {
            departed.Add(vehicle);
        }

        public List<Vehicle> GetDeparted()
        {
            return departed;
        }

        public Vehicle GetVehicleByName(string name)
        {
           return vehicles.FirstOrDefault(v => v.Name.Equals(name));
        }

        public List<Vehicle> GetVehicles()
        {
            return vehicles;
        }
    }
}
