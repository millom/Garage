using Garage.Entensions;
using Garage.SearchFilter;
using Garage.UI;
using Garage.Vehicles;

namespace Garage.Garage
{
    internal class GarageHandler(
        IUI ui,
        IList<IVehicle> freeVehicles,
        IGarage<IVehicle> garage) : IGarageHandler
    {
        private readonly IUI _ui = ui;
        private readonly IList<IVehicle> _freeVehicles = freeVehicles;
        private readonly IGarage<IVehicle> _garage = garage;

        public void ParkVehicle(
            string regNr,
            int slotId)
        {
            var vehicle = _freeVehicles.FirstOrDefault(v => v.RegNumber == regNr);
            if (vehicle == null)
            {
                throw new NullReferenceException("No vehicle with that regNrb found");
            }
            _garage.ParkVehicleInSlot(vehicle, slotId);
            _freeVehicles.Remove(vehicle);
        }

        public IVehicle GetParkedVehicle(
            string regNumber)
        {
            var vehicle = _garage.UnParkVehicle(regNumber);
            _freeVehicles.Add(vehicle);
            return vehicle;
        }

        public IEnumerable<string> GetSearchResult(ISearchFilter filter)
        {
            foreach (var vehicle in _garage
                .Where(v => v is not null)
                .Where(v => v.FilterByRegNumber(filter?.RegNumber))
                .Where(v => v.FilterByColor(filter?.Color))
                .Where(v => v.FilterByWeels(filter?.Weels))
                .Where(v => v.FilterByExtraProp(filter?.ExtraProp))
            )
            {
                yield return vehicle.GetToString();
            }
        }

        public IEnumerable<int> GetFreeSlots()
        {
            return _garage
                .Select((v, i) => new { item = v, idx = i })
                .Where(x => x.item == null)
                .Select(x => x.idx);
        }

        public IEnumerable<string> GetNotParkedVehicles()
        {
            return _freeVehicles
                .Where(v => v is not null)
                .Select(v => v.ToString());
        }

        public IEnumerable<string> GetAllParkedVehicles()
        {
            return _garage
                .Where(v => v is not null)
                .Select(v => v.ToString());
        }
    }
}
