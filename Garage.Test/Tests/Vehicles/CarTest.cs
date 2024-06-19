using Garage.Test.Utils;
using Garage.Types;
using Garage.Vehicles;

namespace Garage.Test.Tests.Vehicles
{
    public class CarTest : BaseVehicleTest
    {
        private const FuelType _fueltype = FuelType.ELECTRICITY;
        private const string _type = "Car";

        [Theory]
        [InlineData(FuelType.ELECTRICITY)]
        [InlineData(FuelType.GASOLINE)]
        [InlineData(FuelType.DIESEL)]
        public void GivenLegalExpectedFueltype_WhenCreateCarWithExpectedFueltype_ThenFueltypeIsExpectedFueltype(
            FuelType expectedFueltype)
        {
            // Act
            IVehicle vehicle = new Car(_regNumber, _color, _weels, expectedFueltype);
            ICar? car = vehicle as ICar;

            // Assert
            Assert.NotNull(car);
            Assert.Equal(expectedFueltype, car.Fueltype);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(-2)]
        public void Ctor_GivenBadExpectedFuelType_WhenCreateCarWithExpected_ThenThrowExpectedException(
            int expectedFuelType)
        {
            // Arrange
            string userDefinedMessage = $"Argument fuelType={(int)expectedFuelType} (must be >= 0)";
            string expectedMessage = "Specified argument was out of the range of valid values." +
                $" (Parameter '{userDefinedMessage}')";

            // Act & Assert
            ArgumentOutOfRangeException ex = Assert.Throws<ArgumentOutOfRangeException>(
                () => new Car(_regNumber, _color, _weels, (FuelType)expectedFuelType)
            );

            // Assert
            Assert.Equal(expectedMessage, ex.Message);
        }

        [Fact]
        public void DefaultCtor_GivenExpectedPropValues_WhenCreateAirplane_ThenHasExpectedValues()
        {
            // Act
            var car = new Car
            {
                RegNumber = _regNumber,
                Color = _color,
                Weels = _weels,
                Fueltype = _fueltype
            };

            // Assert
            Assert.Equal(_regNumber, car.RegNumber);
            Assert.Equal(_color, car.Color);
            Assert.Equal(_weels, car.Weels);
            Assert.Equal(_fueltype, car.Fueltype);
        }

        [Theory]
        [ExernalToStringTestData]
        public void ToString_GivenExpectedPropValues_WhenExecToString_ThenExpected(
            string regNumber, int color, int weels, int fuelType)
        {
            // Arange
            var baseString =
                $"Reg:{regNumber}, " +
                $"Color:{(ColorType)color}, " +
                $"Weels:{weels}, " +
                $"Type:{_type}";
            var expectedString = $"{baseString}, FuelType:{(FuelType)fuelType}";
            var car = new Car
            {
                RegNumber = regNumber,
                Color = (ColorType)color,
                Weels = weels,
                Fueltype = (FuelType)fuelType
            };

            // Act
            var result = car.ToString();

            // Assert
            Assert.Equal(expectedString, result);
        }
    }
}
