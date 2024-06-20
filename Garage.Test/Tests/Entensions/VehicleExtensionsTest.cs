using Garage.Entensions;
using Garage.Test.Tests.Vehicles;
using Garage.Types;
using Garage.Vehicles;

namespace Garage.Test.Tests.Entensions
{
    public class VehicleExtensionsTest : BaseVehicleTest
    {
        private readonly IVehicle _car;
        private const FuelType _fueltype = FuelType.ELECTRICITY;

        private readonly IVehicle _boat;
        private const int _length = 12;

        private readonly IVehicle _bus;
        private const int _seats = 22;

        private readonly IVehicle _motorcycle;
        private const int _cylinderVolume = 2;

        private readonly IVehicle _airplane;
        private const int _engines = 2;

        public VehicleExtensionsTest()
        {
            _car = new Car(_regNumber, _color, _weels, _fueltype);
            _boat = new Boat(_regNumber, _color, _weels, _length);
            _bus = new Bus(_regNumber, _color, _weels, _seats);
            _motorcycle = new Motorcycle(_regNumber, _color, _weels, _cylinderVolume);
            _airplane = new Airplane(_regNumber, _color, _weels, _engines);
        }

        [Theory]
        [InlineData("123", true)]
        [InlineData("ABC", true)]
        [InlineData("BC1", true)]
        [InlineData("", true)]
        [InlineData(null, true)] // Ignored and always true
        [InlineData("AC", false)]
        [InlineData("24", false)]
        public void FilterByRegNumber_GivenCarWithExpectedRegNumber_WhenFilterByRegNumber_ThenTrueResult(
            string? filter, bool expectedResult)
        {
            // Act
            var result = _car.FilterByRegNumber(filter);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(null, true)] // Ignored and always true
        [InlineData(ColorType.ANY, true)] // Ignored and always true
        [InlineData(ColorType.BLUE, true)]
        [InlineData(ColorType.YELLOW, false)]
        [InlineData(ColorType.GREEN, false)]
        public void FilterColor_GivenCarWithExpectedRegNumber_WhenFilterByRegNumber_ThenTrueResult(
            ColorType? filter, bool expectedResult)
        {
            // Act
            var result = _car.FilterByColor(filter);

            // Assert
            Assert.Equal(expectedResult, result);
        }
    }
}
