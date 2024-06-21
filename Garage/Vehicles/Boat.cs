using Garage.Exceptions;
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
        int length)
        : Vehicle(regNumber, color, 0), IVehicle, IBoat
    {
        [JsonPropertyOrder(3)]
        public override int Weels
        {
            get => _weels;
            set
            {
                Throw<ArgumentException>.If(value != 0, "Weels must be zero0");

                _weels = value;
            }
        }

        [JsonPropertyOrder(4)]
        public int Length { get; set; } = length > 0
            ? length
            : throw new ArgumentOutOfRangeException(
                $"Argument length={length} (must be > 0)"
              );

        public Boat() : this("abc123", ColorType.BLUE, 1)
        {
            
        }

        public override string ToString()
        {
            return $"{base.ToString()}, Length:{Length}";
        }
    }
}
