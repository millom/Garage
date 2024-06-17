using Garage.Types;

using Microsoft.Extensions.Hosting;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.Vehicles
{
    internal class Boat(
        string regNumber,
        ColorType color,
        int weels,
        int? length = null)
        : Vehicle(regNumber, color, weels), IVehicle, IBoat
    {
        public int Lenght { get; }
    }
}
