using Garage.Exceptions;
using Garage.Vehicles;

using System.Collections;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Garage.Test")]
namespace Garage.Garage
{
    /// <summary>
    /// The garage class
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="parkingPlaces"></param>
    /// <param name="regNumberSlotDict"></param>
    internal class Garage<T>(
        T[] parkingPlaces,
        IDictionary<string, int> regNumberSlotDict)
        : IGarage<T> where T : IVehicle
    {
        private readonly T?[] _parkingPlaces = parkingPlaces;
        private readonly IDictionary<string, int> _regNumberSlotDict = regNumberSlotDict;

        /// <summary>
        /// Park a vehicle, throw exeption on fail
        /// </summary>
        /// <param name="vehicle"></param>
        /// <param name="slotId"></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="SlotTakenException"></exception>
        public void ParkVehicleInSlot(T? vehicle, int slotId)
        {
            if (vehicle?.RegNumber is null)
                throw new ArgumentNullException("vehicle is null");

            if (slotId < 0 || slotId >= _parkingPlaces.Length)
                throw new ArgumentOutOfRangeException($"slot={slotId}, range {0}-{_parkingPlaces.Length - 1}");

            if (_parkingPlaces[slotId] is not null ||
                _regNumberSlotDict.ContainsKey(vehicle.RegNumber))
                throw new SlotTakenException($"Fail to add vehicle to slot {slotId}, place taken");

            ParkVehicle(vehicle, slotId);
        }

        /// <summary>
        /// Unpark a vehicle, throw exeption on fail
        /// </summary>
        /// <param name="regNumber"></param>
        /// <returns></returns>
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
            T vehicle = _parkingPlaces[slotId]!;

            UnparkVehicle(regNumber, slotId);

            return vehicle;
        }

        /// <summary>
        /// Check if a slot is taken
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="IndexOutOfRangeException"></exception>
        public bool FreeAt(int id)
        {
            if (id >= _parkingPlaces.Length || id < 0)
            {
                throw new IndexOutOfRangeException($"Not existing id <{id}>");
            }

            return _parkingPlaces[id] is null;
        }

        /// <summary>
        /// Return a vehicle or null. Throw exeption if index is out of range
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="IndexOutOfRangeException"></exception>
        public T? VehicleAt(int id)
        {
            if (id >= _parkingPlaces.Length || id < 0)
            {
                throw new IndexOutOfRangeException($"Not existing id <{id}>");
            }

            return _parkingPlaces[id];
        }

        /// <summary>
        /// Return indexes for free parking slots
        /// </summary>
        /// <returns></returns>
        public IEnumerable<int> GetEmptyIndexes()
        {
            for (int i = 0; i < _parkingPlaces.Length; i++)
            {
                if (_parkingPlaces[i] is not null) continue;
                yield return  i;
            };
        }

        /// <summary>
        /// Get an Enumerator, jump over if null
        /// </summary>
        /// <returns></returns>
        public IEnumerator<T> GetEnumerator()
        {
            foreach (var parkingPlace in _parkingPlaces)
            {
                if (parkingPlace is null) continue;
                yield return parkingPlace;
            };
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        private void ParkVehicle(T vehicle, int slotId)
        {
            //if (vehicle is null) throw new ArgumentNullException(nameof(vehicle));
            _regNumberSlotDict[vehicle.RegNumber] = slotId;
            _parkingPlaces[slotId] = vehicle;
        }

        private void UnparkVehicle(string regNumber, int slotId)
        {
            _regNumberSlotDict.Remove(regNumber);
            _parkingPlaces[slotId] = default;
        }
    }
}
