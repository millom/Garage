using Garage.Types;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Garage.Vehicles
{
    [JsonDerivedType(typeof(Motorcycle), typeDiscriminator: "Motorcycle")]
    internal class Motorcycle(
        string regNumber,
        ColorType color,
        int weels,
        int cylinderVolume)
        : Vehicle(regNumber, color, weels), IVehicle, IMotorcycle
    {
        [JsonPropertyOrder(4)]
        public int CylinderVolume { get; set; } = cylinderVolume > 0
            ? cylinderVolume
            : throw new ArgumentOutOfRangeException(
                $"Argument cylinderVolume={cylinderVolume} (must be > 0)"
              );

        public Motorcycle() : this("abc123", ColorType.BLUE, 3, 1)
        {
            
        }

        public override string ToString()
        {
            return $"{base.ToString()}, CylinderVolume:{CylinderVolume}";
        }
    }
}
