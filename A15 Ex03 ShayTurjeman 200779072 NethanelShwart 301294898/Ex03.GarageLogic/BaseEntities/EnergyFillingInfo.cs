using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic.BaseEntities
{
    public abstract class EnergyFillingInfo
    {
        public EnergyFillingInfo(int i_Amount)
        {
            Amount = i_Amount;
        }
        public float Amount { get; private set; }
    }
}
