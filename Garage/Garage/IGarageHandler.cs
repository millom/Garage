using Garage.Vehicles;

namespace Garage.Garage
{
    internal interface IGarageHandler
    {
        IEnumerable<string> GetSearchResult(ISearchFilter filter);
        IVehicle GetParkedVehicle(string regNumber);
        void ParkVehicle(IVehicle vehicle, int slotId);
    }
}