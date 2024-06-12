using Garage.Vehicles;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.Garage
{
    internal class ParkingPlace: IParkingPlace
    {
        private static int _idCounter = 0;
        public int Id { get; }
        public IVehicle? Vehicle { get; set; }

        public ParkingPlace()
        {
            Id = _idCounter++;
        }

        public override string ToString()
        {
            return $"Id:{Id} <{(Vehicle != null ? Vehicle : "Free")}>";
        }
    }
}
