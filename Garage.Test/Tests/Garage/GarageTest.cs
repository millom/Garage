using Garage.Exceptions;
using Garage.Garage;
using Garage.Test.Utils;
using Garage.Types;
using Garage.Vehicles;

using System.Diagnostics;
using System.Drawing;
using System.Security.Cryptography;

using Xunit.Abstractions;

namespace Garage.Test.Tests.Garage
{
    public class GarageTest
    {
        private readonly ITestOutputHelper output;
        private const int SIZE = 20;
        private readonly IGarage<IVehicle> Garage;
        private const int weels = 4;
        private const FuelType fuelType = FuelType.GASOLINE;
        private readonly IVehicle[] vehicleArr;
        private readonly IDictionary<string, int> regNumberSlotDict;

        public GarageTest(ITestOutputHelper output)
        {
            this.output = output;
            vehicleArr = new Vehicle[SIZE];
            regNumberSlotDict = new Dictionary<string, int>();
            Garage = new Garage<IVehicle>(vehicleArr, regNumberSlotDict);
        }

        [Theory]
        [MemberData(nameof(ExernalSlotTestData.TestData), MemberType = typeof(ExernalSlotTestData))]
        public void GivenEmptyGarage_WhenExecuteFreeAtWithLegalId_ThenSlotIsFree(int id)
        {
            // Act & Assert
            Assert.True(Garage.FreeAt(id));
        }

        [Theory]
        [InternalSlotTestData]
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
        [ExernalSlotTestData]
        public void GivenEmptyGarage_WhenExecuteVehicleAtWithId_GivesSlotIsNull(int id)
        {
            // Act & Assert
            Assert.Null(Garage.VehicleAt(id));
        }

        [Theory]
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
            IVehicle car1 = new Car("ABC123", ColorType.BLUE, 4, fuelType);
            IVehicle car2 = new Car("ABC124", ColorType.YELLOW, 4, fuelType);
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
            IVehicle car = new Car("ABC123", ColorType.BLUE, 4, fuelType);

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
        [MemberData(nameof(InternalSlotTestData.TestData), MemberType = typeof(InternalSlotTestData))]
        public void GivenOneCarOutsideGarage_WhenParkingLegalCarOutsideSlots_ThenThrowExpectedException(
            int slotId)
        {
            // Arrange
            string userDefinedMessage = $"slot={slotId}, range {0}-{SIZE - 1}";
            string expectedMessage = "Specified argument was out of the range of valid values." +
                $" (Parameter '{userDefinedMessage}')";
            IVehicle? car = new Car("ABC123", ColorType.BLUE, 4, fuelType);

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
            IVehicle car1 = new Car("ABC123", ColorType.BLUE, 4, fuelType);
            IVehicle car2 = new Car("ABC124", ColorType.YELLOW, 4, fuelType);
            Garage.ParkVehicleInSlot(car1, slotId);

            // Act & Assert
            SlotTakenException ex = Assert.Throws<SlotTakenException>(
                () => Garage.ParkVehicleInSlot(car2, slotId)
            );

            // Assert
            Assert.Equal(expectedMessage, ex.Message);
        }

        [Fact]
        public void GivenOneCarsInGarage_WhenUnparkCar_ThenTheIsUnparked()
        {
            // Arrange
            int slotId = 0;
            string regNumber = "ABC123";
            ParkVehicle(slotId, regNumber, ColorType.BLUE);

            // Act
            IVehicle car = Garage.UnParkVehicle(regNumber);

            Assert.Equal(regNumber, car.RegNumber);
        }

        [Fact]
        public void GivenOneCarInGarage_WhenUnparkCar_ThenCarsIsParkingSlotIsFree()
        {
            // Arrange
            int slotId = 0;
            string regNumber = "ABC123";
            ParkVehicle(slotId, regNumber, ColorType.BLUE);

            // Act
            IVehicle car = Garage.UnParkVehicle(regNumber);

            // Assert
            Assert.Null(Garage.VehicleAt(slotId));
        }

        [Fact]
        public void GivenOneUnparkedCarInGarage_WhenUnparkCarAgain_ThenThrowExpectedException()
        {
            // Arrange
            int slotId = 0;
            string regNumber = "ABC123";
            string expectedMessage = $"RegNumber {regNumber} not found";
            ParkVehicle(slotId, regNumber, ColorType.BLUE);
            IVehicle car1 = Garage.UnParkVehicle(regNumber);

            // Act
            ArgumentException ex = Assert.Throws<ArgumentException>(
                () => Garage.UnParkVehicle(regNumber)
            );
            Assert.Equal(expectedMessage, ex.Message);
        }

        [Fact]
        public void GivenNoCarsInGarage_WhenUnparkCar_ThenThrowExpectedException()
        {
            // Arrange
            string regNumber = "";
            string expectedMessage = $"Illegal Reg number, {regNumber}";

            // Act & Assert
            ArgumentException ex = Assert.Throws<ArgumentException>(
                () => Garage.UnParkVehicle(regNumber)
            );

            // Assert
            Assert.Equal(expectedMessage, ex.Message);
        }

        [Fact]
        public void GivenNoCarsInGarage_WhenUnparkWithEmptyRegNumber_ThenThrowExpectedException()
        {
            // Arrange
            string regNumber = "ABC123";
            string expectedMessage = $"RegNumber {regNumber} not found";

            // Act & Assert
            ArgumentException ex = Assert.Throws<ArgumentException>(
                () => Garage.UnParkVehicle(regNumber)
            );

            // Assert
            Assert.Equal(expectedMessage, ex.Message);
        }

        private void ParkVehicle(int slotId, string regNumber, ColorType colorType)
        {
            IVehicle car = new Car(regNumber, colorType, weels, fuelType);
            Garage.ParkVehicleInSlot(car, slotId);
        }
    }
}