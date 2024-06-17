using Garage.Exceptions;
using Garage.Garage;
using Garage.Test.Utils;
using Garage.Types;
using Garage.Vehicles;

using System.Diagnostics;
using System.Drawing;

using Xunit.Abstractions;

namespace Garage.Test.Tests.Garage
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
        //[InlineData(0)]
        //[InlineData(4)]
        //[InlineData(9)]
        //[InlineData(14)]
        //[InlineData(19)]
        //[MemberData(nameof(ExernalSlotTestData.TestData),
        //    MemberType = typeof(ExernalSlotTestData))]
        [ExernalSlotTestData]
        public void GivenEmptyGarage_WhenExecuteVehicleAtWithId_GivesSlotIsNull(int id)
        {
            // Act & Assert
            Assert.Null(Garage.VehicleAt(id));
        }

        [Theory]
        //[InlineData(-1)]
        //[InlineData(20)]
        //[MemberData(nameof(InternalSlotTestData.TestData),
        //    MemberType = typeof(InternalSlotTestData))]
        [InternalSlotTestData]
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
        public void GivenTwoCarsInGarage_WhenIterateOverGarage_ThenExpectedCarsReached()
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

        [Fact]
        public void GivenOneCarOutsideGarage_WhenParkingLegalCarAndSlotGarage_ThenCarIsParked()
        {
            // Arrange
            IVehicle car = new Car("ABC123", ColorType.BLUE, 4);

            // Act
            Garage.ParkVehicleInSlot(car, 0);

            Assert.False(Garage.FreeAt(0));
            Assert.Same(car, Garage.VehicleAt(0));
        }

        [Fact]
        public void GivenOneCarOutsideGarage_WhenParkingNullCar_ThenThrowExpectedException()
        {
            // Arrange
            string userDefinedMessage = "vehicle";
            string expectedMessage = "Value cannot be null." +
                $" (Parameter '{userDefinedMessage}')";
            IVehicle? car = null;

            // Act & Assert
            ArgumentNullException ex = Assert.Throws<ArgumentNullException>(() => Garage.ParkVehicleInSlot(car, 0));

            // Assert
            Assert.Equal(expectedMessage, ex.Message);
        }

        [Theory]
        //[MemberData("TestData", MemberType = typeof(InternalSlotTestData))]
        [InlineData(-1)]
        [InlineData(SIZE)]
        public void GivenOneCarOutsideGarage_WhenParkingLegalCarOutsideSlots_ThenThrowExpectedException(
            int slotId)
        {
            // Arrange
            string userDefinedMessage = $"slot={slotId}, range {0}-{SIZE - 1}";
            string expectedMessage = "Specified argument was out of the range of valid values." +
                $" (Parameter '{userDefinedMessage}')";
            IVehicle? car = new Car("ABC123", ColorType.BLUE, 4);

            // Act & Assert
            ArgumentOutOfRangeException ex = Assert.Throws<ArgumentOutOfRangeException>(
                () => Garage.ParkVehicleInSlot(car, slotId)
            );

            // Assert
            Assert.Equal(expectedMessage, ex.Message);
        }

        [Fact]
        public void GivenOneCarOutsideGarage_WhenAddingCarToTakenParkingSlot_ThenThrowExpectedException()
        {
            // Arrange
            int slotId = 0;
            string expectedMessage =
                $"Fail to add vehicle to slot {slotId}, place taken";
            IVehicle car1 = new Car("ABC123", ColorType.BLUE, 4);
            IVehicle car2 = new Car("ABC124", ColorType.YELLOW, 4);
            Garage.ParkVehicleInSlot(car1, slotId);

            // Act & Assert
            SlotTakenException ex = Assert.Throws<SlotTakenException>(
                () => Garage.ParkVehicleInSlot(car2, slotId)
            );

            // Assert
            Assert.Equal(expectedMessage, ex.Message);
        }
    }
}