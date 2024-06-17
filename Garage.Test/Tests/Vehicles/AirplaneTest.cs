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
        //private const string regNumber  = "ABC123";
        private const ColorType color = ColorType.BLUE;
        private const int weels = 4;

        [Theory]
        [InlineData("ABC12")]
        [InlineData("ABC123")]
        public void GeivenParams_WhenCreateVehicleWithParams_ThenPropertiesSamaAsParams(
            string regNumber)
        {
            // Arrange & Act
            IVehicle vehicle = new Car(regNumber, color, weels);

            // Assert
            Assert.Equal(regNumber, vehicle.RegNumber);
            Assert.Equal(color, vehicle.Color);
            Assert.Equal(weels, vehicle.Weels);
        }

        [Theory]
        [InlineData("")]
        [InlineData("ABC1")]
        public void GeivenBadRegNumber_WhenCreateVehicleWithParams_ThenThrowExpectedException(
            string badRegNumber)
        {
            // Arrange
            string expectedMessage = $"Bad regNumber: <{badRegNumber}>";

            // Act
            ArgumentException ex = Assert.Throws<ArgumentException>(
                () => new Car(badRegNumber, color, weels));

            // Assert
            Assert.Equal(expectedMessage, ex.Message);
        }
    }
}
