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
    //[Json]
    [JsonDerivedType(typeof(Car), typeDiscriminator: "Car")]
    internal class Car(
        string regNumber,
        ColorType color,
        int weels,
        FuelType fueltype) : Vehicle(regNumber, color, weels), ICar
    {
        [JsonPropertyOrder(4)]
        public FuelType Fueltype { get; set; } = (int)fueltype >= 0
            ? fueltype
            : throw new ArgumentOutOfRangeException(
                $"Argument fuelType={(int)fueltype} (must be >= 0)"
              );

        //[JsonConstructor]
        public Car() : this("aabc123", ColorType.BLUE, 3, FuelType.ELECTRICITY)
        {
            
        }

        public override string ToString()
        {
            return $"{base.ToString()}, FuelType:{Fueltype}";
        }
    }
}
