using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic.BaseEntities
{
    public abstract class EnergyFillingInfo
    {
        protected readonly float r_MaximumEnergyFillingAmount;

        public EnergyFillingInfo(float i_MaximumEnergyFillingAmount)
        {
            r_MaximumEnergyFillingAmount = i_MaximumEnergyFillingAmount;
        }

        public float MaximumAmount { get { return r_MaximumEnergyFillingAmount; } }
    }
}
