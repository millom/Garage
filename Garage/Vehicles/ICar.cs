using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Garage.Types;

namespace Garage.Vehicles
{
    internal interface ICar : IVehicle
    {
        FuelType Fueltype { get; }
    }
}
