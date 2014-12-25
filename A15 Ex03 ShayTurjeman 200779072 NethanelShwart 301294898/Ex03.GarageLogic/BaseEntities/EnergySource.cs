using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic.BaseEntities
{
    public abstract class EnergySource
    {
        public abstract void Fill(EnergyFillingInfo i_Energy);
    }
}
