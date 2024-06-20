using Garage.Types;
using Garage.Vehicles;
using System;
using System.Collections.Generic;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.Entensions
{
    /// <summary>
    /// A class containing Extension methods for IVehicle
    /// </summary>
    internal static class VehicleExtensions
    {
        /// <summary>
        /// Filter a Vehicle by RegNumber, can be used in Linq
        /// </summary>
        /// <param name="vehicle"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        public static bool FilterByRegNumber(
            this IVehicle vehicle,
            string? filter)
        {
            return filter is null ||
                vehicle.RegNumber.Contains(filter);
        }

        /// <summary>
        /// Filter a Vehicle by Color, can be used in Linq
        /// </summary>
        /// <param name="vehicle"></param>
        /// <param name="color"></param>
        /// <returns></returns>
        public static bool FilterByColor(
            this IVehicle vehicle,
            ColorType? color)
        {
            return color is null ||
                ColorType.ANY == color ||
                vehicle.Color == color;
        }

        /// <summary>
        /// Filter a Vehicle by Weels, can be used in Linq
        /// </summary>
        /// <param name="vehicle"></param>
        /// <param name="weels"></param>
        /// <returns></returns>
        public static bool FilterByWeels(
            this IVehicle vehicle,
            int? weels)
        {
            return weels is null ||
                vehicle.Weels == weels;
        }

        /// <summary>
        /// Filter a Vehicle by ExtraProp, can be used in Linq
        /// Go to different methids depending of sub class
        /// </summary>
        /// <param name="vehicle"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        public static bool FilterByExtraProp(
            this IVehicle? vehicle,
            int? filter)
        {
            if (filter is null) { return true; }

            var car = vehicle as ICar;
            if (car is not null) return car.FilterExtraProps(filter);

            var boat = vehicle as IBoat;
            if (boat is not null) return boat.FilterExtraProps(filter);

            var mc = vehicle as IMotorcycle;
            if (mc is not null) return mc.FilterExtraProps(filter);

            var ap = vehicle as IAirplane;
            if (ap is not null) return ap.FilterExtraProps(filter);

            var bus = vehicle as IBus;
            if (bus is not null) return bus.FilterExtraProps(filter);

            return false;
        }

        /// <summary>
        /// Filter a Car by ExtraProp, called from FilterByExtraProp
        /// </summary>
        /// <param name="car"></param>
        /// <param name="fuelType"></param>
        /// <returns></returns>
        private static bool FilterExtraProps(this ICar car, int? fuelType)
        {
            return (int)car.Fueltype == fuelType;
        }

        /// <summary>
        /// Filter a Bus by ExtraProp, called from FilterByExtraProp
        /// </summary>
        /// <param name="bus"></param>
        /// <param name="seats"></param>
        /// <returns></returns>
        private static bool FilterExtraProps(this IBus bus, int? seats)
        {
            return bus.Seats == seats;
        }

        /// <summary>
        /// Filter a Motorcycle by ExtraProp, called from FilterByExtraProp
        /// </summary>
        /// <param name="motorcycle"></param>
        /// <param name="cylinderVolume"></param>
        /// <returns></returns>
        private static bool FilterExtraProps(this IMotorcycle motorcycle, int? cylinderVolume)
        {
            return motorcycle.CylinderVolume == cylinderVolume;
        }

        /// <summary>
        /// Filter a Boat by ExtraProp, called from FilterByExtraProp
        /// </summary>
        /// <param name="boat"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        private static bool FilterExtraProps(this IBoat boat, int? length)
        {
            return boat.Length == length;
        }

        /// <summary>
        /// Filter an Airplane by ExtraProp, called from FilterByExtraProp
        /// </summary>
        /// <param name="airplane"></param>
        /// <param name="engines"></param>
        /// <returns></returns>
        private static bool FilterExtraProps(this IAirplane airplane, int? engines)
        {
            return airplane.Engines == engines;
        }

        /// <summary>
        /// Get to string value for the vehicle subtype
        /// </summary>
        /// <param name="vehicle"></param>
        /// <returns></returns>
        /// <exception cref="NullReferenceException"></exception>
        public static string GetToString(
            this IVehicle? vehicle)
        {
            var car = vehicle as ICar;
            if (car is not null) return car.ToString();

            var boat = vehicle as IBoat;
            if (boat is not null) return boat.ToString();

            var mc = vehicle as IMotorcycle;
            if (mc is not null) return mc.ToString();

            var ap = vehicle as IAirplane;
            if (ap is not null) return ap.ToString();

            var bus = vehicle as IBus;
            if (bus is not null) return bus.ToString();

            throw new NullReferenceException($"vehicle = {vehicle}");
        }
    }
}
