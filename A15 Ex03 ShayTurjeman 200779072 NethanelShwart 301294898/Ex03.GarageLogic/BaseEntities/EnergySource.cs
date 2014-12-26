using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic.BaseEntities
{
    public abstract class EnergySource
    {
        protected const float k_MinimumEnergyFillingValue = 0;

        protected readonly EnergyFillingInfo r_EnergyFillingInfo;

        public EnergySource(EnergyFillingInfo i_EnergyFillingInfo)
        {
            r_EnergyFillingInfo = i_EnergyFillingInfo;
        }

        public abstract void Fill(float i_Amount);

        public float CurrentEnergyAmount { get; set; }

        public float CurrentEnergyAmountInPercentage
        {
            get { return (100.0f * CurrentEnergyAmount) / r_EnergyFillingInfo.MaximumAmount; }
        }
    }
}
