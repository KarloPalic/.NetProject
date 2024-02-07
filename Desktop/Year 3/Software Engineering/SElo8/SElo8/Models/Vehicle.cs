using SElo8.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SElo8.Models
{
    public abstract class Vehicle
    {
        public int Ticketprice { get; set; }

        public string Name { get; set; }
        public TrainType TypeOfTrain { get; set; }
        public int Fuel { get; set; }
        public FuelType TypeOfFuel { get; set; }

        public Vehicle(FuelType fuelType, string name)
        {
            TypeOfFuel = fuelType;
            Ticketprice = SetTicketPrice();
            TypeOfTrain = SetTrainType();
            Fuel = SetFuel();
            Name = name;
        }

        private static int SetFuel()
        {
            Random rnd = new();
            return rnd.Next(1, 100);
        }

        public abstract TrainType SetTrainType();
        public abstract int SetTicketPrice();

        public override string ToString()
        => $"Ticket Price: {Ticketprice}, Type of Vehicle: {TypeOfTrain}, Fuel Type: {TypeOfFuel}, Fuel: {Fuel}";
    }
}
