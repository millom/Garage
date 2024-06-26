﻿using Garage.Types;
using Garage.Vehicles;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.Test.Tests.Vehicles
{
    public class VehicleTest : BaseVehicleTest
    {
        [Theory]
        [InlineData("ABC12")]
        [InlineData("ABC123")]
        public void GeivenParams_WhenCreateVehicleWithParams_ThenPropertiesSamaAsParams(
            string regNumber)
        {
            // Arrange & Act
            IVehicle vehicle = new Car(regNumber, _color, _weels, FuelType.GASOLINE);

            // Assert
            Assert.Equal(regNumber, vehicle.RegNumber);
            Assert.Equal(_color, vehicle.Color);
            Assert.Equal(_weels, vehicle.Weels);
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
                () => new Car(badRegNumber, _color, _weels, FuelType.GASOLINE));

            // Assert
            Assert.Equal(expectedMessage, ex.Message);
        }
    }
}
