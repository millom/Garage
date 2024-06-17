using Garage.Entensions;
using Garage.Types;
using Garage.UI;
using Garage.Vehicles;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.Garage
{
    internal class GarageHandler(
        IUI ui,
        IEnumerable<IVehicle> freeVehicles,
        Garage<IVehicle> garage) : IGarageHandler
    {
        private readonly IUI _ui = ui;
        private readonly IEnumerable<IVehicle> _freeVehicles = freeVehicles;
        private readonly Garage<IVehicle> _garage = garage;

        public void ParkVehicle(
            IVehicle vehicle,
            int slotId)
        {
            _garage.ParkVehicleInSlot(vehicle, slotId);
        }

        public IVehicle GetParkedVehicle(
            string regNumber)
        {
            return _garage.UnParkVehicle(regNumber);
        }

        public IEnumerable<string> GetSearchResult(ISearchFilter filter)
        {
            foreach (var vehicle in _garage
                .Where(v => v != null)
                .Where(v => v.FilterByRegNumber(filter?.RegNumber))
                .Where(v => v.FilterByColor(filter?.Color))
                .Where(v => v.FilterByWeels(filter?.Weels))
                .Where(v => v.FilterByExtraProp(filter?.ExtraProp)))
            {
                yield return vehicle.GetToString();
            }
        }
    }
}
