using Garage.Types;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.Vehicles
{
    internal class Car(
        string regNumber,
        ColorType color,
        int weels,
        FuelType fueltype = FuelType.GASOLINE)
        : Vehicle(regNumber, color, weels), ICar
    {
        public FuelType Fueltype { get; } = fueltype;
    }
}
