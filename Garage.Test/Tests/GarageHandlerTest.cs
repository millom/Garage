using Garage.Garage;
using Garage.Types;
using Garage.Vehicles;
using Garage.Entensions;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.Test.Tests
{
    public class GarageHandlerTest
    {
        [Fact]
        public void Test()
        {
            var parkingPlaces = new Vehicle[5]
            {
                new Car("ABC123", ColorType.BLUE, 4, FuelType.DIESEL),
                new Bus("ABC124", ColorType.BLUE, 4, 26),
                new Boat("ABC125", ColorType.BLUE, 4, 12),
                new Motorcycle("ABC126", ColorType.BLUE, 2, 120),
                new Airplane("ABC127", ColorType.YELLOW, 4, 2)
            };

            var regNumberSlotDict = new Dictionary<string, int>();
            var garage = new Garage<IVehicle>(parkingPlaces, regNumberSlotDict);
            foreach (var vehicle in garage
                .Where(v => v != null)
                .Where(v => v.FilterByRegNumber("ABC"))
                .Where(v => v.FilterByColor((int)ColorType.BLUE))
                .Where(v => v.FilterByExtraProp(2)))
            {
                Console.WriteLine(vehicle);
            }
        }
    }
}
