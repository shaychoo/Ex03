using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic.BaseEntities;

namespace Ex03.GarageLogic.VehiclesInfo
{
    public class TruckInfo : VehicleInfo
    {
        public TruckInfo(string i_VehicleModelName, string i_WheelsManufacturerName, string i_LicensePlate, int i_NumberOfWheels, float i_WheelsMaximumAirPressure)
            : base(i_VehicleModelName, i_WheelsManufacturerName, i_LicensePlate, i_NumberOfWheels, i_WheelsMaximumAirPressure)
        {
        }

        public override string ToString()
        {
            return string.Format("{0}", base.ToString());
        }
    }
}
