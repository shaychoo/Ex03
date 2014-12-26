using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic.BaseEntities;
using Ex03.GarageLogic.EnergiesFillingInfo;

namespace Ex03.GarageLogic.EnergySources
{
    public class ElectricEnergySource : EnergySource
    {
        private readonly ElectricityFillingInfo r_ElectricityFillingInfo;

        public ElectricEnergySource(EnergyFillingInfo i_EnergyFillingInfo)
            : base(i_EnergyFillingInfo)
        {
            ElectricityFillingInfo electricFillingInfo = r_EnergyFillingInfo as ElectricityFillingInfo;

            if (electricFillingInfo == null)
            {
                throw new ArgumentException(
                    "can't create ElectricEnergySource with a EnergyFillingInfo that is not ElectricityFillingInfo");
            }
            r_ElectricityFillingInfo = electricFillingInfo;
        }

        public override void Fill(float i_Amount)
        {
            Helpers.AddingValueInRangeCheck(i_Amount, CurrentEnergyAmount, k_MinimumEnergyFillingValue,
                r_ElectricityFillingInfo.MaximumAmount);
            CurrentEnergyAmount += i_Amount;
        }
    }
}
