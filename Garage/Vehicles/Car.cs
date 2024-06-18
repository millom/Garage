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
    internal class Car : Vehicle, ICar
    {
        [JsonPropertyOrder(4)]
        public FuelType Fueltype { get; set; }

        public Car(
            string regNumber,
            ColorType color,
            int weels,
            FuelType fueltype) : base(regNumber, color, weels)
        {
            Fueltype = fueltype;
        }

        [JsonConstructor]
        public Car() : this("aabc123", ColorType.BLUE, 3, FuelType.ELECTRICITY)
        {
            
        }

        public override string ToString()
        {
            return $"{base.ToString()} FuelType:{Fueltype}";
        }
    }
}
