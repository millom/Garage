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
    internal static class VehicleExtensions
    {
        public static bool FilterByRegNumber(
            this IVehicle vehicle,
            string? filter)
        {
            return filter is null ||
                vehicle.RegNumber.Contains(filter);
        }

        public static bool FilterByColor(
            this IVehicle vehicle,
            ColorType? color)
        {
            return color is null ||
                ColorType.ANY == color ||
                vehicle.Color == color;
        }

        public static bool FilterByWeels(
            this IVehicle vehicle,
            int? weels)
        {
            return weels is null ||
                vehicle.Weels == weels;
        }

        //public static IEnumerable<IVehicle> FilterByRegNumber(
        //    this IEnumerable<IVehicle> vehicles,
        //    string filter)
        //{
        //    return vehicles.Where(v => v.RegNumber.Contains(filter));
        //}

        //public static IEnumerable<IVehicle> FilterByColor(
        //    this IEnumerable<IVehicle> vehicles,
        //    int color)
        //{
        //    return vehicles.Where(v => (int)v.Color == color);
        //}

        //public static IEnumerable<IVehicle> FilterByWeels(
        //    this IEnumerable<IVehicle> vehicles,
        //    int weels)
        //{
        //    return vehicles.Where(v => v.Weels == weels);
        //}

        //public static IEnumerable<IVehicle> FilterByExtraProps(
        //    this IEnumerable<IVehicle> vehicles,
        //    int weels)
        //{
        //    return vehicles.Where(v => v.FilterByExtraProp(weels));
        //}

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

        private static bool FilterExtraProps(this ICar car, int? fuelType)
        {
            return (int)car.Fueltype == fuelType;
        }

        private static bool FilterExtraProps(this IBus bus, int? seats)
        {
            return bus.Seats == seats;
        }

        private static bool FilterExtraProps(this IMotorcycle motorcycle, int? cylinderVolume)
        {
            return motorcycle.CylinderVolume == cylinderVolume;
        }

        private static bool FilterExtraProps(this IBoat boat, int? length)
        {
            return boat.Length == length;
        }

        private static bool FilterExtraProps(this IAirplane airplane, int? engines)
        {
            return airplane.Engines == engines;
        }


        public static string GetToString(
            this IVehicle? vehicle)
        {
            var car = vehicle as ICar;
            if (car is not null) return car.ToString()!;

            var boat = vehicle as IBoat;
            if (boat is not null) return boat.ToString()!;

            var mc = vehicle as IMotorcycle;
            if (mc is not null) return mc.ToString()!;

            var ap = vehicle as IAirplane;
            if (ap is not null) return ap.ToString()!;

            var bus = vehicle as IBus;
            if (bus is not null) return bus.ToString()!;

            throw new NullReferenceException($"vehicle = {vehicle}");
        }
    }
}
