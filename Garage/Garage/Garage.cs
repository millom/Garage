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
         where T : IVehicle?
    {
        private readonly T[] _parkingPlaces;
        private readonly IDictionary<string, int> _regNumberSlotDict;

        public Garage(T[] parkingPlaces, IDictionary<string, int> regNumberSlotDict)
        {
            _parkingPlaces = parkingPlaces;
            _regNumberSlotDict = regNumberSlotDict;
        }

        public void ParkVehicleInSlot(T? vehicle, int slotId)
        {
            if (vehicle is null)
                throw new ArgumentNullException(nameof(vehicle));

            if (slotId < 0 || slotId >= _parkingPlaces.Length)
                throw new ArgumentOutOfRangeException($"slot={slotId}, range {0}-{_parkingPlaces.Length - 1}");

            if (_parkingPlaces[slotId] is not null)
                throw new SlotTakenException($"Fail to add vehicle to slot {slotId}, place taken");

            _regNumberSlotDict[vehicle.RegNumber] = slotId;
            _parkingPlaces[slotId] = vehicle;
        }

        public T UnParkVehicle(string regNumber)
        {
            Throw<ArgumentException>
                .If(string.IsNullOrWhiteSpace(regNumber), $"Illegal Reg number {regNumber}");
            Throw<ArgumentException>
                .If(!_regNumberSlotDict.ContainsKey(regNumber), $"RegNumber {regNumber} not found");

            int slotId = _regNumberSlotDict[regNumber];
            Throw<ArgumentException>
                .If(_parkingPlaces[slotId] is null, $"Conflict between regNumber and slotId");

            T vehicle = _parkingPlaces[slotId];

            CleanupSlot(regNumber, slotId);

            return vehicle;
        }

        public bool FreeAt(int id)
        {
            if (id >= _parkingPlaces.Length || id < 0)
            {
                throw new IndexOutOfRangeException($"Not existing id <{id}>");
            }

            return _parkingPlaces[id] is null;
        }

        public T VehicleAt(int id)
        {
            if (id >= _parkingPlaces.Length || id < 0)
            {
                throw new IndexOutOfRangeException($"Not existing id <{id}>");
            }

            return _parkingPlaces[id];
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var parkingPlace in _parkingPlaces)
            {
                yield return parkingPlace;
            };
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        private void CleanupSlot(string regNumber, int slotId)
        {
            _regNumberSlotDict.Remove(regNumber);
            _parkingPlaces[slotId] = default!;
        }
    }
}
