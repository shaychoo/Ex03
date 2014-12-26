using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic.EnergiesFillingInfo.SpecificEnergiesFillingInfo
{
    public class MotorcycelFuelFillingInfo : FuelFillingInfo
    {
        public override float MaximumAmount
        {
            get { return 6.5f; }
        }

        public override Enums.eFuelType FuelType
        {
            get { return Enums.eFuelType.Octan96; }
        }
    }
}
