using Garage.Types;
using Garage.Vehicles;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.Test.Tests.Vehicles
{
    public class CarTest : BaseVehicleTest
    {

        [Theory]
        [InlineData(FuelType.ELECTRICITY)]
        [InlineData(FuelType.GASOLINE)]
        [InlineData(FuelType.DIESEL)]
        public void GivenLegalExpectedFueltype_WhenCreateCarWithExpectedFueltype_ThenFueltypeIsExpectedFueltype(
            FuelType expectedFueltype)
        {
            // Act
            IVehicle vehicle = new Car(regNumber, color, weels, expectedFueltype);
            ICar? car = vehicle as ICar;

            // Assert
            Assert.NotNull(car);
            Assert.Equal(expectedFueltype, car.Fueltype);
        }
    }
}
