using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic.BaseEntities
{
    public abstract class VehicleInfo
    {
        public VehicleInfo(string i_ModelName, string i_LicensePlate, int i_NumberOfWheels,
            float i_WheelsMaximumAirPressure)
        {
            ModelName = i_ModelName;
            Helpers.CheckLicensePlateFormat(i_LicensePlate);
            LicensePlate = i_LicensePlate;
            NumberOfWheels = i_NumberOfWheels;
            WheelsMaximumAirPressure = i_WheelsMaximumAirPressure;
        }

        public string ModelName { get; set; }

        public string LicensePlate { get; set; }

        public int NumberOfWheels { get; set; }

        public float WheelsMaximumAirPressure { get; set; }
    }
}
