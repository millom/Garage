using Garage.Types;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.Vehicles
{
    internal class Motorcycle(
        string regNumber,
        ColorType color,
        int weels,
        int cylinderVolume)
        : Vehicle(regNumber, color, weels), IVehicle, IMotorcycle
    {
        public int CylinderVolume { get; } = cylinderVolume >= 0
            ? cylinderVolume
            : throw new ArgumentOutOfRangeException(
                $"Argument engines={cylinderVolume} (must be >= 0)"
              );
    }
}
