using Garage.Exceptions;
using Garage.Vehicles;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("Garage.Test")]
namespace Garage.Garage
{
    internal class Garage<T> : IGarage<T>
         where T : IVehicle
    {
        private readonly T[] ParkingPlaces;

        public Garage(T[] parkingPlaces)
        {
            ParkingPlaces = parkingPlaces;
        }

        public void ParkVehicleInSlot(T? vehicle, int slotId)
        {
            if (vehicle is null)
                throw new ArgumentNullException(nameof(vehicle));

            if (slotId < 0 || slotId >= ParkingPlaces.Length)
                throw new ArgumentOutOfRangeException($"slot={slotId}, range {0}-{ParkingPlaces.Length - 1}");

            if (ParkingPlaces[slotId] is not null)
                throw new SlotTakenException($"Fail to add vehicle to slot {slotId}, place taken");

            ParkingPlaces[slotId] = vehicle;
        }

        public bool FreeAt(int id)
        {
            if (id >= ParkingPlaces.Length || id < 0)
            {
                throw new IndexOutOfRangeException($"Not existing id <{id}>");
            }

            return ParkingPlaces[id] is null;
        }

        public T? VehicleAt(int id)
        {
            if (id >= ParkingPlaces.Length || id < 0)
            {
                throw new IndexOutOfRangeException($"Not existing id <{id}>");
            }

            return ParkingPlaces[id];
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
