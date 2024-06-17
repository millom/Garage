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
        int weels,
        int seats)
        : Vehicle(regNumber, color, weels), IVehicle, IBus
    {
        public int Seats { get; } = seats > 0
            ? seats
            : throw new ArgumentOutOfRangeException(
                $"Argument seats={seats} (must be > 0)"
              );
    }
}
