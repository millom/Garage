using Garage.Test.Utils;
using Garage.Types;
using Garage.Vehicles;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.Test.Tests.Vehicles
{
    public class BusTest : BaseVehicleTest
    {
        private const int _seats = 22;
        private const string _type = "Bus";

        [Theory]
        [InlineData(1)]
        [InlineData(15)]
        public void GivenLegalExpectedLength_WhenCreateBusWithExpectedLength_ThenLengthIsExpectedLength(
            int expectedSeats)
        {
            // Act
            IVehicle vehicle = new Bus(_regNumber, _color, _weels, expectedSeats);
            IBus? bus = vehicle as IBus;

            // Assert
            Assert.NotNull(bus);
            Assert.Equal(expectedSeats, bus.Seats);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void GivenBadExpectedLength_WhenCreateBusWithExpectedSeats_ThenThrowExpectedException(
            int expectedLength)
        {
            // Arrange
            string userDefinedMessage = $"Argument seats={expectedLength} (must be > 0)";
            string expectedMessage = "Specified argument was out of the range of valid values." +
                $" (Parameter '{userDefinedMessage}')";

            // Act & Assert
            ArgumentOutOfRangeException ex = Assert.Throws<ArgumentOutOfRangeException>(
                () => new Bus(_regNumber, _color, _weels, expectedLength)
            );
            Assert.Equal(expectedMessage, ex.Message);
        }

        [Fact]
        public void DefaultCtor_GivenExpectedPropValues_WhenCreateAirplane_ThenHasExpectedValues()
        {
            // Act
            var bus = new Bus
            {
                RegNumber = _regNumber,
                Color = _color,
                Weels = _weels,
                Seats = _seats
            };

            // Assert
            Assert.Equal(_regNumber, bus.RegNumber);
            Assert.Equal(_color, bus.Color);
            Assert.Equal(_weels, bus.Weels);
            Assert.Equal(_seats, bus.Seats);
        }

        [Theory]
        [ExernalToStringTestData]
        public void ToString_GivenExpectedPropValues_WhenExecToString_ThenExpected(
            string regNumber, int color, int weels, int seats)
        {
            // Arange
            var baseString =
                $"Reg:{regNumber}, " +
                $"Color:{(ColorType)color}, " +
                $"Weels:{weels}, " +
                $"Type:{_type}";
            var expectedString = $"{baseString}, Seats:{seats}";
            var bus = new Bus
            {
                RegNumber = regNumber,
                Color = (ColorType)color,
                Weels = weels,
                Seats = seats
            };

            // Act
            var result = bus.ToString();

            // Assert
            Assert.Equal(expectedString, result);
        }
    }
}