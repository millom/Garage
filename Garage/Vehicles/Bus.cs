using Garage.Types;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.Vehicles
{
    internal class Bus(
        string regNumber,
        ColorType color,
        int weels)
        : Vehicle(regNumber, color, weels), IVehicle, IBus
    {
        public int Seats { get; }
    }
}
