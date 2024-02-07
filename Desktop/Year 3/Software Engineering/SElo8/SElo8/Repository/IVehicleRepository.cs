using SElo8.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SElo8.Repository
{
    public interface IVehicleRepository
    {
        public List<Vehicle> GetVehicles();

        public Vehicle GetVehicleByName(string name);
        public void AddVehicle(Vehicle vehicle);

        public List<Vehicle> GetDeparted();
        public void Depart(Vehicle vehicle);
    }
}
