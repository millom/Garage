using Garage.Vehicles;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("Garage.Test")]
namespace Garage.Garage
{
    internal class Garage<T> : IGarage<T>
         where T : IParkingPlace //, new()
    {
        private T[] ParkingPlaces;

        public Garage(T[] parkingPlaces)
        {
            ParkingPlaces = parkingPlaces;
            //for (int i = 0; i < ParkingPlaces.Length; i++)
            //{
            //    ParkingPlaces[i] = new T();
            //}
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var parkingPlace in ParkingPlaces)
            {
                yield return parkingPlace;
            };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
