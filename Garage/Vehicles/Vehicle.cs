using Garage.Types;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.Vehicles
{
    internal abstract class Vehicle(
        string regNumber,
        ColorType color,
        int weels) : IVehicle
    {
        public string RegNumber { get; } =
            string.IsNullOrWhiteSpace(regNumber) || regNumber.Length < 4
            ? throw new ArgumentException($"Bad regNumber: <{regNumber}>")
            : regNumber;
        public ColorType Color { get; } = color;
        public int Weels { get; } = weels;
    }
}
