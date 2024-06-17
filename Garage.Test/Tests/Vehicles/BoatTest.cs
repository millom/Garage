using Garage.Types;
using Garage.Vehicles;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.Test.Tests.Vehicles
{
    public class BoatTest
    {
        private const string regNumber = "ABC123";
        private const ColorType color = ColorType.BLUE;
        private const int weels = 4;

        [Theory]
        [InlineData(1)]
        [InlineData(25)]
        public void GivenLegalExpectedEngines_WhenCreateAirplaneWithExpectedEngines_ThenEnginesIsExpectedEngines(
            int expectedLength)
        {
            // Act
            IVehicle vehicle = new Boat(regNumber, color, weels, expectedLength);
            IBoat? boat = vehicle as IBoat;

            // Assert
            Assert.NotNull(boat);
            Assert.Equal(expectedLength, boat.Length);
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
                () => new Boat(regNumber, color, weels, expectedLength)
            );

            // Assert
            Assert.Equal(expectedMessage, ex.Message);
        }
    }
}
