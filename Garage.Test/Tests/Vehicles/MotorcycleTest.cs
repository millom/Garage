using Garage.Types;
using Garage.Vehicles;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.Test.Tests.Vehicles
{
    public class MotorcycleTest : BaseVehicleTest
    {
        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(4)]
        public void GivenLegalExpectedCylinderVolume_WhenCreateMotorcycleWithExpectedCylinderVolume_ThenCylinderVolumeIsExpected(
            int expectedCylinderVolume)
        {
            // Act
            IVehicle vehicle = new Motorcycle(regNumber, color, weels, expectedCylinderVolume);
            IMotorcycle? motorcycle = vehicle as IMotorcycle;

            // Assert
            Assert.NotNull(motorcycle);
            Assert.Equal(expectedCylinderVolume, motorcycle.CylinderVolume);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(-2)]
        public void GivenBadExpectedCylinderVolume_WhenCreateMotorcycleWithExpectedCylinderVolume_ThenThrowExpectedException(
            int expectedCylinderVolume)
        {
            // Arrange
            string userDefinedMessage = $"Argument engines={expectedCylinderVolume} (must be >= 0)";
            string expectedMessage = "Specified argument was out of the range of valid values." +
                $" (Parameter '{userDefinedMessage}')";

            // Act & Assert
            ArgumentOutOfRangeException ex = Assert.Throws<ArgumentOutOfRangeException>(
                () => new Motorcycle(regNumber, color, weels, expectedCylinderVolume)
            );

            // Assert
            Assert.Equal(expectedMessage, ex.Message);
        }
    }
}
