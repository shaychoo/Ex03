using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic.BaseEntities;

namespace Ex03.GarageLogic.VehiclesInfo
{
    public class MotorcycleInfo : VehicleInfo
    {
        public MotorcycleInfo(string i_ModelName, string i_LicensePlate, int i_NumberOfWheels,
            float i_WheelsMaximumAirPressure, Enums.eLicenseType i_LicenseType, int i_EngineVolume)
            : base(i_ModelName, i_LicensePlate, i_NumberOfWheels, i_WheelsMaximumAirPressure)
        {
            LicenseType = i_LicenseType;
            EngineVolume = i_EngineVolume;
        }

        public Enums.eLicenseType LicenseType { get; set; }

        public int EngineVolume { get; set; }
    }
}
