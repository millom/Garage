using Garage.Vehicles;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("Garage.Test")]
namespace Garage.Garage
{
    internal class Garage<T> : IGarage<T>
         where T : IParkingPlace
    {
        private readonly T[] ParkingPlaces;

        public Garage(T[] parkingPlaces)
        {
            ParkingPlaces = parkingPlaces;
        }

        public bool FreeAt(int id)
        {
            if (id >= ParkingPlaces.Length || id < 0)
            {
                throw new IndexOutOfRangeException($"Not existing id <{id}>");
            }

            return ParkingPlaces[id] is null;
        }

        public IVehicle? VehicleAt(int id)
        {
            if (id >= ParkingPlaces.Length || id < 0)
            {
                throw new IndexOutOfRangeException($"Not existing id <{id}>");
            }

            return ParkingPlaces[id].Vehicle;
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var parkingPlace in ParkingPlaces)
            {
                yield return parkingPlace;
            };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
