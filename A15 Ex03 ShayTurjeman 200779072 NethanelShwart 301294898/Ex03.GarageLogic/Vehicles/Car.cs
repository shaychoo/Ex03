﻿using Ex03.GarageLogic.BaseEntities;
using Ex03.GarageLogic.VehiclesInfo;

namespace Ex03.GarageLogic.Vehicles
{
    public class Car : Vehicle
    {
        private readonly CarInfo r_CarInfo;

        public Car(VehicleInfo i_VehicleInfo, EnergySource i_EnergySource, float i_CurrentAirPressure)
            : base(i_VehicleInfo, i_EnergySource, i_CurrentAirPressure)
        {
            r_CarInfo = Helpers.StrongArgumentNeededTypeCheckAndCast<CarInfo>(i_VehicleInfo);
        }

        public CarInfo CarInfo
        {
            get { return r_CarInfo; }
        }
    }
}