using Garage.Vehicles;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.Garage
{
    internal interface IParkingPlace
    {
        int Id { get; }
        IVehicle? Vehicle { get; set; }
        bool IsFree { get; }
    }
}
