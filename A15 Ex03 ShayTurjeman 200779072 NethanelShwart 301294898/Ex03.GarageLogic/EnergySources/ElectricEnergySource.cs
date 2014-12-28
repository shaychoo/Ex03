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

        public ElectricEnergySource(float i_CurrentEnergyAmount, EnergyFillingInfo i_EnergyFillingInfo)
            : base(i_CurrentEnergyAmount, i_EnergyFillingInfo)
        {
            r_ElectricityFillingInfo =
                Helpers.StrongArgumentNeededTypeCheckAndCast<ElectricityFillingInfo>(i_EnergyFillingInfo);
        }

        public ElectricityFillingInfo ElectricityFillingInfo
        {
            get { return r_ElectricityFillingInfo; }
        }

        public override void Fill(float i_Amount)
        {
            string valueName = "Amount of electricity to add";
            Helpers.IsPossibleAddingValueInRangeCheck(i_Amount, CurrentEnergyAmount, k_MinimumEnergyFillingValue,
                ElectricityFillingInfo.MaximumAmount, valueName);
            CurrentEnergyAmount += i_Amount;
        }

        public override string ToString()
        {
            return string.Format("{0}", base.ToString());
        }
    }
}
