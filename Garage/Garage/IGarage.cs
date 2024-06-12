using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Garage.Test")]
namespace Garage.Garage
{
    internal interface IGarage<T>: IEnumerable<T>
        where T : IParkingPlace
    {
    }
}