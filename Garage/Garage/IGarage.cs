using Garage.Vehicles;

using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Garage.Test")]
namespace Garage.Garage
{
    /// <summary>
    /// An interface defining a Garage class
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal interface IGarage<T>: IEnumerable<T>
        where T : IVehicle
    {
        bool FreeAt(int id);
        T? VehicleAt(int id);
        void ParkVehicleInSlot(T? vehicle, int slotId);
        T UnParkVehicle(string regNumber);
        IEnumerable<int> GetEmptyIndexes();
    }
}