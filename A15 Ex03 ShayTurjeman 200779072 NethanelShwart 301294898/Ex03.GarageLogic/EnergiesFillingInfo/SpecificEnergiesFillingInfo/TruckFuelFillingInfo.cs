using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic.EnergiesFillingInfo.SpecificEnergiesFillingInfo
{
    public class TruckFuelFillingInfo : FuelFillingInfo
    {
        public override float MaximumAmount
        {
            get { return 200.0f; }
        }

        public override Enums.eFuelType FuelType
        {
            get { return Enums.eFuelType.Soler; }
        }
    }
}
