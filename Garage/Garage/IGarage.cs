using Garage.Vehicles;

using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Garage.Test")]
namespace Garage.Garage
{
    internal interface IGarage<T>: IEnumerable<T>
        where T : IVehicle
    {
        public bool FreeAt(int id);
        public T? VehicleAt(int id);
        public void ParkVehicleInSlot(T vehicle, int slotId);
    }
}