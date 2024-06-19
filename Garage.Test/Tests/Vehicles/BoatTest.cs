using Garage.Test.Utils;
using Garage.Types;
using Garage.Vehicles;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Garage.Test.Tests.Vehicles
{
    public class BoatTest : BaseVehicleTest
    {
        private const int _length = 12;
        private const string _type = "Boat";

        [Theory]
        [InlineData(1)]
        [InlineData(25)]
        public void GivenLegalExpectedEngines_WhenCreateAirplaneWithExpectedEngines_ThenEnginesIsExpectedEngines(
            int expectedLength)
        {
            // Act
            IVehicle vehicle = new Boat(_regNumber, _color, _weels, expectedLength);
            IBoat? boat = vehicle as IBoat;

            // Assert
            Assert.NotNull(boat);
            Assert.Equal(expectedLength, boat.Length);
        }


        [Fact]
        public void DefaultCtor_GivenExpectedPropValues_WhenCreateAirplane_ThenHasExpectedValues()
        {
            // Act
            var boat = new Boat
            {
                RegNumber = _regNumber,
                Color = _color,
                Weels = _weels,
                Length = _length
            };

            // Assert
            Assert.Equal(_regNumber, boat.RegNumber);
            Assert.Equal(_color, boat.Color);
            Assert.Equal(_weels, boat.Weels);
            Assert.Equal(_length, boat.Length);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void GivenBadExpectedEngines_WhenCreateBoatWithExpectedLength_ThenThrowExpectedException(
            int expectedLength)
        {
            // Arrange
            string userDefinedMessage = $"Argument length={expectedLength} (must be > 0)";
            string expectedMessage = "Specified argument was out of the range of valid values." +
                $" (Parameter '{userDefinedMessage}')";

            // Act & Assert
            ArgumentOutOfRangeException ex = Assert.Throws<ArgumentOutOfRangeException>(
                () => new Boat(_regNumber, _color, _weels, expectedLength)
            );

            // Assert
            Assert.Equal(expectedMessage, ex.Message);
        }

        [Theory]
        [ExernalToStringTestData]
        public void ToString_GivenExpectedPropValues_WhenExecToString_ThenExpected(
            string regNumber, int color, int weels, int length)
        {
            // Arange
            var baseString =
                $"Reg:{regNumber}, " +
                $"Color:{(ColorType)color}, " +
                $"Weels:{weels}, " +
                $"Type:{_type}";
            var expectedString = $"{baseString}, Length:{length}";
            var boat = new Boat
            {
                RegNumber = regNumber,
                Color = (ColorType)color,
                Weels = weels,
                Length = length
            };

            // Act
            var result = boat.ToString();

            // Assert
            Assert.Equal(expectedString, result);
        }
    }
}
