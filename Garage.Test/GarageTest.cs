using Garage;
using Garage.Garage;
using Garage.Vehicles;

using System.Diagnostics;
using System.Drawing;

using Xunit.Abstractions;

namespace Garage.Test
{
    public class GarageTest
    {
        private readonly ITestOutputHelper output;
        private Garage<IVehicle> Garage;
        private const int SIZE = 20;

        public GarageTest(ITestOutputHelper output)
        {
            this.output = output;
            Garage = new Garage<IVehicle>(new Vehicle[SIZE]);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(4)]
        [InlineData(9)]
        [InlineData(14)]
        [InlineData(19)]
        public void GivenEmptyGarage_WhenCheckingAnySlot_GivesSlotIsFree(int id)
        {
            // Act & Assert
            Assert.True(Garage.FreeAt(id));
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(20)]
        public void GivenEmptyGarage_WhenCheckingSlotNotInGarage_GivesException(int id)
        {
            // Arrange
            var expectedMessage = $"Not existing id <{id}>";

            // Act & Assert
            var ex = Assert.Throws<IndexOutOfRangeException>(() => Garage.FreeAt(id));

            // Assert
            Assert.Equal(expectedMessage, ex.Message);
        }
    }
}