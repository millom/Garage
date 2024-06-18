using Garage.Exceptions;
using Garage.Vehicles;

using System.Collections;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Garage.Test")]
namespace Garage.Garage
{
    internal class Garage<T>(
        T[] parkingPlaces,
        IDictionary<string, int> regNumberSlotDict)
        : IGarage<T> where T : IVehicle
    {
        private readonly T[] _parkingPlaces = parkingPlaces;
        private readonly IDictionary<string, int> _regNumberSlotDict = regNumberSlotDict;

        public void ParkVehicleInSlot(T? vehicle, int slotId)
        {
            if (vehicle is null)
                throw new ArgumentNullException(nameof(vehicle));

            if (slotId < 0 || slotId >= _parkingPlaces.Length)
                throw new ArgumentOutOfRangeException($"slot={slotId}, range {0}-{_parkingPlaces.Length - 1}");

            if (_parkingPlaces[slotId] is not null)
                throw new SlotTakenException($"Fail to add vehicle to slot {slotId}, place taken");

            ParkVehicle(vehicle, slotId);
        }

        public T UnParkVehicle(string regNumber)
        {
            Throw<ArgumentException>
                .If(string.IsNullOrWhiteSpace(regNumber), $"Illegal Reg number, {regNumber}");
            Throw<RegNumberNotFoundException>
                .If(!_regNumberSlotDict.ContainsKey(regNumber), $"RegNumber {regNumber} not found");

            int slotId = _regNumberSlotDict[regNumber];

            // This should not be possible, maybe later
            //Throw<ArgumentException>
            //    .If(_parkingPlaces[slotId] is null, $"Conflict between regNumber and slotId");

            T vehicle = _parkingPlaces[slotId];

            UnparkVehicle(regNumber, slotId);

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

        public T? VehicleAt(int id)
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

        private void ParkVehicle(T vehicle, int slotId)
        {
            _regNumberSlotDict[vehicle!.RegNumber] = slotId;
            _parkingPlaces[slotId] = vehicle;
        }

        private void UnparkVehicle(string regNumber, int slotId)
        {
            _regNumberSlotDict.Remove(regNumber);
            _parkingPlaces[slotId] = default!;
        }
    }
}
