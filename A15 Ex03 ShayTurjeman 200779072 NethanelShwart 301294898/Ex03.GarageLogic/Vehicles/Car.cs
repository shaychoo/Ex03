using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic.BaseEntities;

namespace Ex03.GarageLogic.Vehicles
{
    public class Car : Vehicle
    {
        public Car(EnergySource i_EnergySources) : base(i_EnergySources)
        {
        }
    }
}
