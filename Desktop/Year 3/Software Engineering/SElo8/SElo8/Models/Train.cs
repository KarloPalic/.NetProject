using SElo8.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SElo8.Models
{
    public class Train
    {
        public int Capacity { get; set; }
        public TrainType TypeOfTrain { get; set; }
        public List<Vehicle> Vehicles { get; set; }
        public Train(TrainType trainType) { 
            Capacity = SetCapacity();
            TypeOfTrain = trainType;
            Vehicles = new List<Vehicle>();
        }

        private int SetCapacity()
        {
            if (TypeOfTrain == TrainType.Small)
            {
                return 8;
            }
            else
            {
                return 6;
            }
        }

        public bool IsFull()
        {
            if (Vehicles.Count == Capacity)
            {
                return true;
            }
            else { return false; }
        }
        public override string ToString() => $"Train Capacity: {Capacity}, Type of train: {TypeOfTrain}";
    }
}
