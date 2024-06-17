using Garage.Types;

using Microsoft.Extensions.Hosting;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.Vehicles
{
    internal class Boat(
        string regNumber,
        ColorType color,
        int weels,
        int length)
        : Vehicle(regNumber, color, weels), IVehicle, IBoat
    {
        public int Length { get; } = length > 0
            ? length
            : throw new ArgumentOutOfRangeException(
                $"Argument length={length} (must be > 0)"
              );
    }
}
