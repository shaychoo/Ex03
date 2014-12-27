using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic.BaseEntities;
using Ex03.GarageLogic.EnergiesFillingInfo;

namespace Ex03.GarageLogic.EnergySources
{
    public class FuelEnergySource : EnergySource
    {
        private readonly FuelFillingInfo r_FuelFillingInfo;

        public FuelEnergySource(float i_CurrentEnergyAmount, EnergyFillingInfo i_EnergyFillingInfo)
            : base(i_CurrentEnergyAmount, i_EnergyFillingInfo)
        {
            r_FuelFillingInfo = Helpers.StrongArgumentNeededTypeCheckAndCast<FuelFillingInfo>(i_EnergyFillingInfo);
        }

        public FuelFillingInfo FuelFillingInfo
        {
            get { return r_FuelFillingInfo; }
        }

        public bool IsCorrectFuelType(Enums.eFuelType i_FuelType)
        {
            return FuelFillingInfo.FuelType == i_FuelType;
        }

        public override void Fill(float i_Amount)
        {
            Helpers.AddingValueInRangeCheck(i_Amount, CurrentEnergyAmount, k_MinimumEnergyFillingValue,
                FuelFillingInfo.MaximumAmount);
            CurrentEnergyAmount += i_Amount;
        }
    }
}
