using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic.BaseEntities;

namespace Ex03.GarageLogic.VehiclesInfo
{
    public class TruckInfo : VehicleInfo
    {
        public TruckInfo(string i_ModelName, string i_LicensePlate, int i_NumberOfWheels,float i_WheelsMaximumAirPressure)
            : base(i_ModelName, i_LicensePlate, i_NumberOfWheels, i_WheelsMaximumAirPressure)
        {
        }
    }
}
