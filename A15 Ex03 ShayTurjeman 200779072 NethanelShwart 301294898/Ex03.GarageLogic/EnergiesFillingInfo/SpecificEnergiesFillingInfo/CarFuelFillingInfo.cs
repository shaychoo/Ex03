using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic.EnergiesFillingInfo.SpecificEnergiesFillingInfo
{
    public class CarFuelFillingInfo : FuelFillingInfo
    {
        public override float MaximumAmount
        {
            get { return 45.0f; }
        }

        public override Enums.eFuelType FuelType
        {
            get { return Enums.eFuelType.Octan95; }
        }
    }
}
