using Garage.Types;
using Garage.Vehicles;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            string expectedMessage = $"Engines={expectedEngines} (must be > 0)";

            // Act & Assert
            ArgumentOutOfRangeException ex = Assert.Throws<ArgumentOutOfRangeException>(
                () => new Airplane(regNumber, color, weels, expectedEngines)
            );
        }
    }
}
