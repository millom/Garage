using Garage.Types;

using Microsoft.VisualBasic.FileIO;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Garage.Vehicles
{
    [JsonDerivedType(typeof(Bus), typeDiscriminator: "Bus")]
    internal class Bus(
        string regNumber,
        ColorType color,
        int weels,
        int seats)
        : Vehicle(regNumber, color, weels), IVehicle, IBus
    {
        [JsonPropertyOrder(4)]
        public int Seats { get; set; } = seats > 0
            ? seats
            : throw new ArgumentOutOfRangeException(
                $"Argument seats={seats} (must be > 0)"
              );

        public Bus() : this("abc123", ColorType.BLUE, 3, 1)
        {
            
        }

        public override string ToString()
        {
            return $"{base.ToString()}, Seats:{Seats}";
        }
    }
}
