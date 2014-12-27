using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic.BaseEntities;

namespace Ex03.GarageLogic.VehiclesInfo
{
    public class CarInfo : VehicleInfo
    {
        public CarInfo(string i_ModelName, string i_LicensePlate, int i_NumberOfWheels, float i_WheelsMaximumAirPressure,
            Enums.eCarColor i_CarColor, Enums.eNumberOfDoors i_NumberOfDoors)
            : base(i_ModelName, i_LicensePlate, i_NumberOfWheels, i_WheelsMaximumAirPressure)
        {
            CarColor = i_CarColor;
            NumberOfDoors = i_NumberOfDoors;
        }

        public Enums.eCarColor CarColor { get; set; }

        public Enums.eNumberOfDoors NumberOfDoors { get; set; }
    }
}
