using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.Vehicles
{
    internal class Vehicle(string regNumber, string color, int weels) : IVehicle
    {
        public string RegNumber { get; } = regNumber;
        public string Color { get; } = color;
        public int Weels { get; } = weels;
    }
}
