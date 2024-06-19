using Garage.Test.Utils;
using Garage.Types;
using Garage.Vehicles;

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Garage.Test.Tests.Vehicles
{
    public class AirplaneTest
        : BaseVehicleTest
    {
        private const int _engines = 2;
        private const string _type = "Airplane";

        [Theory]
        [InlineData(1)]
        [InlineData(4)]
        public void GivenLegalExpectedEngines_WhenCreateAirplaneWithExpectedEngines_ThenEnginesIsExpectedEngines(
            int expectedEngines)
        {
            // Act
            IVehicle vehicle = new Airplane(_regNumber, _color, _weels, expectedEngines);
            IAirplane? airplane = vehicle as IAirplane;

            // Assert
            Assert.NotNull(airplane);
            Assert.Equal(expectedEngines, airplane.Engines);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void Ctor_GivenBadExpectedEngines_WhenCreateAirplaneWithExpectedEngines_ThenThrowExpectedException(
            int expectedEngines)
        {
            // Arrange
            string userDefinedMessage = $"Argument engines={expectedEngines} (must be > 0)";
            string expectedMessage = "Specified argument was out of the range of valid values." +
                $" (Parameter '{userDefinedMessage}')";

            // Act & Assert
            ArgumentOutOfRangeException ex = Assert.Throws<ArgumentOutOfRangeException>(
                () => new Airplane(_regNumber, _color, _weels, expectedEngines)
            );

            // Assert
            Assert.Equal(expectedMessage, ex.Message);
        }

        [Fact]
        public void DefaultCtor_GivenExpectedPropValues_WhenCreateAirplane_ThenHasExpectedValues()
        {
            // Act
            var airplane = new Airplane
            {
                RegNumber = _regNumber,
                Color = _color,
                Weels = _weels,
                Engines = _engines
            };

            // Assert
            Assert.Equal(_regNumber, airplane.RegNumber);
            Assert.Equal(_color, airplane.Color);
            Assert.Equal(_weels, airplane.Weels);
            Assert.Equal(_engines, airplane.Engines);
        }

        [Theory]
        [ExernalToStringTestData]
        public void ToString_GivenExpectedPropValues_WhenExecToString_ThenExpected(
            string regNumber, int color, int weels, int engines)
        {
            // Arange
            var baseString =
                $"Reg:{regNumber}, " +
                $"Color:{(ColorType)color}, " +
                $"Weels:{weels}, " +
                $"Type:{_type}";
            var expectedString = $"{baseString}, Engines:{engines}";
            var airplane = new Airplane
            {
                RegNumber = regNumber,
                Color = (ColorType)color,
                Weels = weels,
                Engines = engines
            };

            // Act
            var result = airplane.ToString();

            // Assert
            Assert.Equal(expectedString, result);
        }
    }
}
