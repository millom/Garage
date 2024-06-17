using Garage.Vehicles;

using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Garage.Test")]
namespace Garage.Garage
{
    internal interface IGarage<T>: IEnumerable<T>
        where T : IVehicle
    {
        bool FreeAt(int id);
        T? VehicleAt(int id);
        void ParkVehicleInSlot(T vehicle, int slotId);
        T UnParkVehicle(string regNumber);
    }
}