using Garage.Types;
using Garage.UI;
using Garage.Vehicles;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.Garage
{
    internal class GarageHandler(
        IUI ui,
        IEnumerable<IVehicle> freeVehicles,
        Garage<IVehicle> _garage)
    {
        public readonly IEnumerable<IVehicle> _freeVehicles = freeVehicles;

        public void ParkVehicle(
            IVehicle vehicle,
            int slotId)
        {
            _garage.ParkVehicleInSlot(vehicle, slotId);
        }

        public void UnparkVehicle(
            string regNumber)
        {
            _garage.UnParkVehicle(regNumber);
        }

        //public IEnumerable<IVehicle> FilterByRegNumber(string item)
        //{
        //    return _garage.Where(v => v.RegNumber.Contains(item));
        //}

        //public IEnumerable<IVehicle> FilterByColor(ColorType color)
        //{
        //    return _garage.Where(v => v.Color == color);
        //}

        //public IEnumerable<IVehicle> FilterByWeels(int weels)
        //{
        //    return _garage.Where(v => v.Weels == weels);
        //}

        //public IEnumerable<IVehicle> FilterByExtraProps(int xtra)
        //{
        //    return _garage.Where(v => v.Weels == weels);
        //}


        //.Where(v => v.FilterExtraProps(120))
    }
}
