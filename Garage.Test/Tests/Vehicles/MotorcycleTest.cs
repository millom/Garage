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
    public class MotorcycleTest : BaseVehicleTest
    {
        private const int _cylinderVolume = 2;
        private const string _type = "Motorcycle";

        [Theory]
        [InlineData(1)]
        [InlineData(4)]
        [InlineData(9)]
        public void GivenLegalExpectedCylinderVolume_WhenCreateMotorcycleWithExpectedCylinderVolume_ThenCylinderVolumeIsExpected(
            int expectedCylinderVolume)
        {
            // Act
            IVehicle vehicle = new Motorcycle(_regNumber, _color, _weels, expectedCylinderVolume);
            IMotorcycle? motorcycle = vehicle as IMotorcycle;

            // Assert
            Assert.NotNull(motorcycle);
            Assert.Equal(expectedCylinderVolume, motorcycle.CylinderVolume);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void GivenBadExpectedCylinderVolume_WhenCreateMotorcycleWithExpectedCylinderVolume_ThenThrowExpectedException(
            int expectedCylinderVolume)
        {
            // Arrange
            string userDefinedMessage = $"Argument cylinderVolume={expectedCylinderVolume} (must be > 0)";
            string expectedMessage = "Specified argument was out of the range of valid values." +
                $" (Parameter '{userDefinedMessage}')";

            // Act & Assert
            ArgumentOutOfRangeException ex = Assert.Throws<ArgumentOutOfRangeException>(
                () => new Motorcycle(_regNumber, _color, _weels, expectedCylinderVolume)
            );

            // Assert
            Assert.Equal(expectedMessage, ex.Message);
        }

        [Fact]
        public void DefaultCtor_GivenExpectedPropValues_WhenCreateAirplane_ThenHasExpectedValues()
        {
            // Act
            var motorcycle = new Motorcycle
            {
                RegNumber = _regNumber,
                Color = _color,
                Weels = _weels,
                CylinderVolume = _cylinderVolume
            };

            // Assert
            Assert.Equal(_regNumber, motorcycle.RegNumber);
            Assert.Equal(_color, motorcycle.Color);
            Assert.Equal(_weels, motorcycle.Weels);
            Assert.Equal(_cylinderVolume, motorcycle.CylinderVolume);
        }

        [Theory]
        [ExernalToStringTestData]
        public void ToString_GivenExpectedPropValues_WhenExecToString_ThenExpected(
            string regNumber, int color, int weels, int cylinderVolym)
        {
            // Arange
            var baseString =
                $"Reg:{regNumber}, " +
                $"Color:{(ColorType)color}, " +
                $"Weels:{weels}, " +
                $"Type:{_type}";
            var expectedString = $"{baseString}, CylinderVolume:{cylinderVolym}";
            var motorcycle = new Motorcycle
            {
                RegNumber = regNumber,
                Color = (ColorType)color,
                Weels = weels,
                CylinderVolume = cylinderVolym
            };

            // Act
            var result = motorcycle.ToString();

            // Assert
            Assert.Equal(expectedString, result);
        }
    }
}
