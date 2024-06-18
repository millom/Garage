using Garage.Vehicles;

namespace Garage.Garage
{
    internal interface IGarageHandler
    {
        IEnumerable<string> GetSearchResult(ISearchFilter filter);
        IVehicle GetParkedVehicle(string regNumber);
        void ParkVehicle(string regNr, string slotId);
        IEnumerable<int> GetFreeSlots();
        IEnumerable<string> GetNotParkedVehicles();
        IEnumerable<string> GetAllParkedVehicles();
    }
}