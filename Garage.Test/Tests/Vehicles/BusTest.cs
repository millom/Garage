using Garage.Types;
using Garage.Vehicles;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.Test.Tests.Vehicles
{
    public class BusTest
    {
        private const string regNumber = "ABC123";
        private const ColorType color = ColorType.BLUE;
        private const int weels = 4;

        [Theory]
        [InlineData(1)]
        [InlineData(15)]
        public void GivenLegalExpectedLength_WhenCreateBusWithExpectedLength_ThenLengthIsExpectedLength(
            int expectedSeats)
        {
            // Act
            IVehicle vehicle = new Bus(regNumber, color, weels, expectedSeats);
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
                () => new Bus(regNumber, color, weels, expectedLength)
            );
            Assert.Equal(expectedMessage, ex.Message);
        }
    }
}
