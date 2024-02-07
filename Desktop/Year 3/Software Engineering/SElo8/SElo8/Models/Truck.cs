using SElo8.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SElo8.Models
{
    public class Truck : Vehicle
    {
        public Truck(FuelType fuelType, string name) : base(fuelType, name)
        {
        }

        public override int SetTicketPrice()
        => 10;

        public override TrainType SetTrainType()
        => TrainType.Large;
    }
}
