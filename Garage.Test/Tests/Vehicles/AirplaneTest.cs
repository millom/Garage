using Garage.Types;
using Garage.Vehicles;

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Garage.Test.Tests.Vehicles
{
    public class AirplaneTest
    {
        private const string regNumber = "ABC123";
        private const ColorType color = ColorType.BLUE;
        private const int weels = 4;

        [Theory]
        [InlineData(1)]
        [InlineData(4)]
        public void GivenLegalExpectedEngines_WhenCreateAirplaneWithExpectedEngines_ThenEnginesIsExpectedEngines(
            int expectedEngines)
        {
            // Act
            IVehicle vehicle = new Airplane(regNumber, color, weels, expectedEngines);
            IAirplane? airplane = vehicle as IAirplane;

            // Assert
            Assert.NotNull(airplane);
            Assert.Equal(expectedEngines, airplane.Engines);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void GivenBadExpectedEngines_WhenCreateAirplaneWithExpectedEngines_ThenThrowExpectedException(
            int expectedEngines)
        {
            // Arrange
            string userDefinedMessage = $"Argument engines={expectedEngines} (must be > 0)";
            string expectedMessage = "Specified argument was out of the range of valid values." +
                $" (Parameter '{userDefinedMessage}')";

            // Act & Assert
            ArgumentOutOfRangeException ex = Assert.Throws<ArgumentOutOfRangeException>(
                () => new Airplane(regNumber, color, weels, expectedEngines)
            );
            Assert.Equal(expectedMessage, ex.Message);
        }
    }
}
