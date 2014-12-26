using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic.BaseEntities;

namespace Ex03.GarageLogic.Vehicles
{
    public class Motorcycle : Vehicle
    {
        public Motorcycle(EnergySource i_EnergySources, Enums.eLicenseType i_LicenseType, int i_EngineVolume)
            : base(i_EnergySources)
        {
            LicenseType = i_LicenseType;
            EngineVolume = i_EngineVolume;
        }

        public Enums.eLicenseType LicenseType { get; set; }

        public int EngineVolume { get; set; }

        protected override int MumberOfWheels
        {
            get { return 2; }
        }

        protected override float WheelsMaximumAirPressure
        {
            get { return 30.0f; }
        }
    }
}
