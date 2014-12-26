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
        public FuelEnergySource(EnergyFillingInfo i_EnergyFillingInfo) 
            : base(i_EnergyFillingInfo)
        {
            FuelFillingInfo fuelFillingInfo = r_EnergyFillingInfo as FuelFillingInfo;

            if (fuelFillingInfo == null)
            {
                throw new ArgumentException(
                    "can't create FuelEnergySource with a EnergyFillingInfo that is not FuelFillingInfo");
            }
            r_FuelFillingInfo = fuelFillingInfo;
        }

        public override void Fill(float i_Amount)
        {
            Helpers.AddingValueInRangeCheck(i_Amount,CurrentEnergyAmount, k_MinimumEnergyFillingValue,r_FuelFillingInfo.MaximumAmount );
            CurrentEnergyAmount += i_Amount;
        }

        public bool IsCorrectFuelType(Enums.eFuelType i_FuelType)
        {
            return r_FuelFillingInfo.FuelType == i_FuelType;
        }
    }
}
