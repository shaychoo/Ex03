using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic.BaseEntities;

namespace Ex03.GarageLogic.Energies
{
    public class FuelFillingInfo : EnergyFillingInfo
    {
        public FuelFillingInfo(Enums.eFuelType i_FuelType, int i_Amount)
            : base(i_Amount)
        {
            FuelType = i_FuelType;
        }
        public Enums.eFuelType FuelType { get; private set; }
    }
}
