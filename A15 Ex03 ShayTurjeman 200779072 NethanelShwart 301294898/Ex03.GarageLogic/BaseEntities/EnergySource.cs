using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic.BaseEntities
{
    public abstract class EnergySource
    {
        private readonly EnergyFillingInfo r_EnergyFillingInfo;

        protected const float k_MinimumEnergyFillingValue = 0.0f;

        public EnergySource(float i_CurrentEnergyAmount, EnergyFillingInfo i_EnergyFillingInfo)
        {
            CurrentEnergyAmount = i_CurrentEnergyAmount;
            r_EnergyFillingInfo = i_EnergyFillingInfo;

            // check that started energy amount is in range by the energy filling info
            Helpers.AddingValueInRangeCheck(0, CurrentEnergyAmount, k_MinimumEnergyFillingValue,
               r_EnergyFillingInfo.MaximumAmount);
        }

        public abstract void Fill(float i_Amount);

        public float CurrentEnergyAmount { get; protected set; }

        public float CurrentEnergyAmountInPercentage
        {
            get { return (100.0f * CurrentEnergyAmount) / r_EnergyFillingInfo.MaximumAmount; }
        }

        public override string ToString()
        {
            return string.Format(@"{0}", r_EnergyFillingInfo);
        }
    }
}
