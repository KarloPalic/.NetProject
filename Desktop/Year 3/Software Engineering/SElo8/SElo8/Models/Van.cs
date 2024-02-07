using SElo8.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SElo8.Models
{
    public class Van : Vehicle
    {
        public Van(FuelType fuelType, string name) : base(fuelType, name)
        {
        }

        public override int SetTicketPrice()
        => 8;

        public override TrainType SetTrainType()
        => TrainType.Small;
    }
}
