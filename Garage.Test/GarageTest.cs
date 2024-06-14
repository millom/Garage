using Garage;
using Garage.Garage;
using Garage.Types;
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
        public void GivenEmptyGarage_WhenExecuteFreeAtWithLegalId_ThenSlotIsFree(int id)
        {
            // Act & Assert
            Assert.True(Garage.FreeAt(id));
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(20)]
        public void GivenEmptyGarage_WhenExecuteFreeAtWithBadId_ThenThrowExpectedExecpten(int id)
        {
            // Arrange
            var expectedMessage = $"Not existing id <{id}>";

            // Act & Assert
            var ex = Assert.Throws<IndexOutOfRangeException>(() => Garage.FreeAt(id));

            // Assert
            Assert.Equal(expectedMessage, ex.Message);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(4)]
        [InlineData(9)]
        [InlineData(14)]
        [InlineData(19)]
        public void GivenEmptyGarage_WhenExecuteVehicleAtWithId_GivesSlotIsNull(int id)
        {
            // Act & Assert
            Assert.Null(Garage.VehicleAt(id));
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(20)]
        public void GivenEmptyGarage_WhenExecuteVehicleAtWithBadId_ThenThrowExpectedExecpten(int id)
        {
            // Arrange
            var expectedMessage = $"Not existing id <{id}>";

            // Act & Assert
            var ex = Assert.Throws<IndexOutOfRangeException>(() => Garage.VehicleAt(id));

            // Assert
            Assert.Equal(expectedMessage, ex.Message);
        }

        [Fact]
        public void ParkCar()
        {
            // Arrange
            IVehicle car1 = new Car("ABC123", ColorType.BLUE, 4);
            IVehicle car2 = new Car("ABC124", ColorType.YELLOW, 4);
            Garage.ParkVehicleInSlot(car1, 0);
            Garage.ParkVehicleInSlot(car2, 1);
            var enumerator = Garage.GetEnumerator();

            // Act & Assert
            enumerator.MoveNext();
            Assert.Equal(car1, enumerator.Current);
            enumerator.MoveNext();
            Assert.Equal(car2, enumerator.Current);
            enumerator.MoveNext();
            Assert.Null(enumerator.Current);
        }
    }
}