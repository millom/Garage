using Garage;
using Garage.Garage;

using System.Diagnostics;
using System.Drawing;

using Xunit.Abstractions;

namespace Garage.Test
{
    public class GarageTest
    {
        private readonly ITestOutputHelper output;
        private IGarage<IParkingPlace> Garage;
        private const int SIZE = 20;

        public GarageTest(ITestOutputHelper output)
        {
            this.output = output;
            var pp = new ParkingPlace[SIZE];
            for (int i = 0; i < SIZE; i++)
            {
                pp[i] = new ParkingPlace();
            }
            Garage = new Garage<IParkingPlace>(pp);
        }

        [Fact]
        public void Ctor_CreateGarage_GiveParkingPlacesOfExpectedSize()
        {
            foreach (var place in Garage)
            {
                //output.WriteLine(place.ToString());
                Console.WriteLine(place.ToString());
                //Debugger.Log(0, "1", place.ToString());
            }
        }
    }
}