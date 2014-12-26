using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic.BaseEntities;

namespace Ex03.GarageLogic.Vehicles
{
    public class Truck : Vehicle
    {
        public Truck(EnergySource i_EnergySources) : base(i_EnergySources)
        {
        }

        protected override int MumberOfWheels
        {
            get { return 8; }
        }

        protected override float WheelsMaximumAirPressure
        {
            get { return 24.0f; }
        }
    }
}
