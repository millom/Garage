using Garage.Types;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Garage.Vehicles
{
    [JsonDerivedType(typeof(Airplane), typeDiscriminator: "Airplane")]
    internal class Airplane(
        string regNumber,
        ColorType color,
        int weels,
        int engines)
        : Vehicle(regNumber, color, weels), IVehicle, IAirplane
    {
        public int Engines { get; set; } = engines > 0
            ? engines
            : throw new ArgumentOutOfRangeException(
                $"Argument engines={engines} (must be > 0)"
              );

        public Airplane() : this("abc123", ColorType.BLUE, 3, 1)
        {
            
        }

        public override string ToString()
        {
            return $"{base.ToString()} Engines:{Engines}";
        }
    }
}
