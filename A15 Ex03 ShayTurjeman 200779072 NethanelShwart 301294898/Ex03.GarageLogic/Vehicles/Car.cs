using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic.BaseEntities;

namespace Ex03.GarageLogic.Vehicles
{
    public class Car : Vehicle
    {
        public Car(EnergySource i_EnergySources, Enums.eCarColor i_CarColor, Enums.eDoorsNumber i_NumberOfDoors)
            : base(i_EnergySources)
        {
            CarColor = i_CarColor;
            NumberOfDoors = i_NumberOfDoors;
        }

        public Enums.eCarColor CarColor { get; set; }

        public Enums.eDoorsNumber NumberOfDoors { get; set; }

        protected override int MumberOfWheels
        {
            get { return 4; }
        }

        protected override float WheelsMaximumAirPressure
        {
            get { return 29.0f; }
        }
    }
}
