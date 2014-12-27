using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic.BaseEntities;

namespace Ex03.GarageLogic.VehiclesInfo
{
    public class CarInfo : VehicleInfo
    {
        public CarInfo(string i_VehicleModelName, string i_WheelsManufacturerName, string i_LicensePlate, int i_NumberOfWheels, float i_WheelsMaximumAirPressure,
            Enums.eCarColor i_CarColor, Enums.eNumberOfDoors i_NumberOfDoors)
            : base(i_VehicleModelName, i_WheelsManufacturerName, i_LicensePlate, i_NumberOfWheels, i_WheelsMaximumAirPressure)
        {
            CarColor = i_CarColor;
            NumberOfDoors = i_NumberOfDoors;
        }

        public Enums.eCarColor CarColor { get; set; }

        public Enums.eNumberOfDoors NumberOfDoors { get; set; }

        public override string ToString()
        {
            return string.Format("{0}, Car color: {1}, Number of doors: {2}", base.ToString(), CarColor, NumberOfDoors);
        }
    }
}
