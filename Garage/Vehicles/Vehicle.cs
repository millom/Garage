using Garage.Types;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Garage.Vehicles
{
    //[JsonPolymorphic]
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "$type")]
    //[JsonDerivedType(typeof(Car), 0)]
    [JsonDerivedType(typeof(Car), typeDiscriminator: "Car")]
    [JsonDerivedType(typeof(Boat), typeDiscriminator: "Boat")]
    [JsonDerivedType(typeof(Motorcycle), typeDiscriminator: "Motorcycle")]
    [JsonDerivedType(typeof(Airplane), typeDiscriminator: "Airplane")]
    [JsonDerivedType(typeof(Bus), typeDiscriminator: "Bus")]
    internal abstract class Vehicle : IVehicle
    {
        [JsonPropertyOrder(1)]
        public string RegNumber { get; set; }
        [JsonPropertyOrder(2)]
        public ColorType Color { get; set; }
        [JsonPropertyOrder(3)]
        public int Weels { get; set; }

        public Vehicle(
            string regNumber,
            ColorType color,
            int weels)
        {
            RegNumber =
                string.IsNullOrWhiteSpace(regNumber) || regNumber.Length <= 4
                ? throw new ArgumentException($"Bad regNumber: <{regNumber}>")
                : regNumber;
            Color = color;
            Weels = weels;
        }

        //[JsonConstructor]
        public Vehicle() : this("abc123", ColorType.BLUE, 3) {}

        public override string ToString()
        {
            return $"Reg:{RegNumber}, Color:{Color}, Weels:{Weels} Type:{GetType().Name}";
        }
    }
}
