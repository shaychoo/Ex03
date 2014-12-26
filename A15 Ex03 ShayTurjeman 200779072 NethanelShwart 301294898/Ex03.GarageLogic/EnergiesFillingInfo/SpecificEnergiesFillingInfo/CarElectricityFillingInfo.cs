using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic.EnergiesFillingInfo.SpecificEnergiesFillingInfo
{
    public class CarElectricityFillingInfo : ElectricityFillingInfo
    {
        public override float MaximumAmount
        {
            get { return 2.6f; }
        }
    }
}
