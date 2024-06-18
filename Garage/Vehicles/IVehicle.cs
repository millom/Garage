using Garage.Types;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.Vehicles
{
    internal interface IVehicle
    {
        string RegNumber { get; }
        ColorType Color { get; }
        int Weels { get; }
        string ToString();
    }
}
