using Garage.SearchFilter;
using Garage.Vehicles;

namespace Garage.Garage
{
    internal interface IGarageHandler
    {
        IEnumerable<string> GetSearchResult(ISearchFilter filter);
        IVehicle GetParkedVehicle(string regNumber);
        IVehicle ParkVehicle(string regNr, int slotId);
        IEnumerable<int> GetFreeSlots();
        IEnumerable<string> GetNotParkedVehicles();
        IEnumerable<string> GetAllParkedVehicles();
        IEnumerable<int> GetEmptyIndexes();
        IEnumerable<IdValuePair<string>> GetParkedIdxRegNumber();
    }
}