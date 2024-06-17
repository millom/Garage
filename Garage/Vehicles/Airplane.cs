using Garage.Types;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.Vehicles
{
    internal class Airplane(
        string regNumber,
        ColorType color,
        int weels,
        int? engines = null)
        : Vehicle(regNumber, color, weels), IVehicle, IAirplane
    {
        public int Engines { get; } //= engines;
    }
}
