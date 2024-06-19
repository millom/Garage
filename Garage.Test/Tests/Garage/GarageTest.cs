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
        public void FreeAt_GivenEmptyGarage_WhenExecuteFreeAtWithLegalId_ThenSlotIsFree(int id)
        {
            // Act & Assert
            Assert.True(Garage.FreeAt(id));
        }

        [Theory]
        [InternalSlotTestData]
        public void FreeAt_GivenEmptyGarage_WhenExecuteFreeAtWithBadId_ThenThrowExpectedExecpten(int id)
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
        public void VehicleAt_GivenEmptyGarage_WhenExecuteVehicleAtWithId_GivesSlotIsNull(int id)
        {
            // Act & Assert
            Assert.Null(Garage.VehicleAt(id));
        }

        [Theory]
        [InternalSlotTestData]
        public void VehicleAt_GivenEmptyGarage_WhenExecuteVehicleAtWithBadId_ThenThrowExpectedExecpten(int id)
        {
            // Arrange
            var expectedMessage = $"Not existing id <{id}>";

            // Act & Assert
            var ex = Assert.Throws<IndexOutOfRangeException>(() => Garage.VehicleAt(id));

            // Assert
            Assert.Equal(expectedMessage, ex.Message);
        }

        [Fact]
        public void Enumerator_GivenTwoCarsInGarage_WhenIterateOverGarage_ThenExpectedCarsReached()
        {
            // Arrange
            IVehicle car1 = new Car("ABC123", ColorType.BLUE, 4, fuelType);
            IVehicle car2 = new Car("ABC124", ColorType.YELLOW, 4, fuelType);
            Garage.ParkVehicleInSlot(car1, 0);
            Garage.ParkVehicleInSlot(car2, 1);
            var enumerator = Garage.GetEnumerator();

            // Act & Assert
            Assert.True(enumerator.MoveNext());
            Assert.Equal(car1, enumerator.Current);
            Assert.True(enumerator.MoveNext());
            Assert.Equal(car2, enumerator.Current);
            Assert.False(enumerator.MoveNext());
        }

        [Fact]
        public void ParkVehicleInSlot_GivenOneLegalCarSlot_WhenParkingCarInSlot_ThenCarIsParked()
        {
            // Arrange
            IVehicle car = new Car("ABC123", ColorType.BLUE, 4, fuelType);
            int legalSlot = 0;

            // Act
            Garage.ParkVehicleInSlot(car, legalSlot);

            Assert.False(Garage.FreeAt(0));
            Assert.Same(car, Garage.VehicleAt(legalSlot));
        }

        [Fact]
        public void ParkVehicleInSlot_GivenOneNullCar_WhenParkingCar_ThenThrowExpectedException()
        {
            // Arrange
            string userDefinedMessage = "vehicle is null";
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
        public void ParkVehicleInSlot_GivenOneLegalCar_WhenParkingCarOutsideGarage_ThenThrowExpectedException(
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
        public void ParkVehicleInSlot_GivenTwoLegalCars_WhenParkingSecondCarToSameSlot_ThenThrowExpectedException()
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
        public void UnParkVehicle_GivenOneCarsInGarage_WhenUnparkCar_ThenTheIsUnparked()
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
        public void UnParkVehicle_GivenOneCarInGarage_WhenUnparkCar_ThenCarsIsParkingSlotIsFree()
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
        public void UnParkVehicle_GivenOneUnparkedCarInGarage_WhenUnparkCarAgain_ThenThrowExpectedException()
        {
            // Arrange
            int slotId = 0;
            string regNumber = "ABC123";
            string expectedMessage = $"RegNumber {regNumber} not found";
            ParkVehicle(slotId, regNumber, ColorType.BLUE);
            IVehicle car1 = Garage.UnParkVehicle(regNumber);

            // Act
            RegNumberNotFoundException ex = Assert.Throws<RegNumberNotFoundException>(
                () => Garage.UnParkVehicle(regNumber)
            );
            Assert.Equal(expectedMessage, ex.Message);
        }

        [Fact]
        public void UnParkVehicle_GivenNoCarsInGarage_WhenUnparkCar_ThenThrowExpectedException()
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
        public void UnParkVehicle_GivenNoCarsInGarage_WhenUnparkWithEmptyRegNumber_ThenThrowExpectedException()
        {
            // Arrange
            string regNumber = "ABC123";
            string expectedMessage = $"RegNumber {regNumber} not found";

            // Act & Assert
            RegNumberNotFoundException ex = Assert.Throws<RegNumberNotFoundException>(
                () => Garage.UnParkVehicle(regNumber)
            );

            // Assert
            Assert.Equal(expectedMessage, ex.Message);
        }

        [Theory]
        [InlineData(0, 19)]
        [InlineData(1, 18)]
        public void GetEmptyIndexes_GivenTwoParkedCarsPos0and19_WhenGetEmptyIndexes_ThenGetSize18(
            int idx1,
            int idx2
        )
        {
            // Arrange
            int expectedSize = 18;
            IVehicle car1 = new Car("ABC123", ColorType.BLUE, 4, fuelType);
            IVehicle car2 = new Car("ABC124", ColorType.YELLOW, 4, fuelType);
            Garage.ParkVehicleInSlot(car1, idx1);
            Garage.ParkVehicleInSlot(car2, idx2);

            // Act
            var IdxListSize = Garage.GetEmptyIndexes().Count();

            // Assert
            Assert.Equal(expectedSize, IdxListSize);
        }

        private void ParkVehicle(int slotId, string regNumber, ColorType colorType)
        {
            IVehicle car = new Car(regNumber, colorType, weels, fuelType);
            Garage.ParkVehicleInSlot(car, slotId);
        }
    }
}