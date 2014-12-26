using Ex03.GarageLogic.BaseEntities;

namespace Ex03.GarageLogic.EnergiesFillingInfo
{
    public abstract class FuelFillingInfo : EnergyFillingInfo
    {
        public abstract Enums.eFuelType FuelType { get;  }
    }
}
