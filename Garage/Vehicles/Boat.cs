using Garage.Types;

using Microsoft.Extensions.Hosting;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml;

namespace Garage.Vehicles
{
    [JsonDerivedType(typeof(Boat), typeDiscriminator: "Boat")]
    internal class Boat(
        string regNumber,
        ColorType color,
        int weels,
        int length)
        : Vehicle(regNumber, color, weels), IVehicle, IBoat
    {
        [JsonPropertyOrder(4)]
        public int Length { get; set; } = length > 0
            ? length
            : throw new ArgumentOutOfRangeException(
                $"Argument length={length} (must be > 0)"
              );

        public Boat() : this("abc123", ColorType.BLUE, 3, 1)
        {
            
        }
    }
}
