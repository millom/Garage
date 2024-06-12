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
        private const int SMALL_SIZE = 4;
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
            var pp = new ParkingPlace[SMALL_SIZE];
            for (int i = 0; i < SMALL_SIZE; i++)
            {
                pp[i] = new ParkingPlace();
            }
            var garage = new Garage<IParkingPlace>(pp);

            //Assert.Equal(SmallGarage.);
        }
    }
}