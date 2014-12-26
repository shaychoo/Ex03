using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic.EnergiesFillingInfo.SpecificEnergiesFillingInfo
{
    public class MotorcycelElectricityFillingInfo : ElectricityFillingInfo
    {
        public override float MaximumAmount
        {
            get { return 1.8f; }
        }
    }
}
