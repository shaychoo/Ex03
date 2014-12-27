using Ex03.GarageLogic.BaseEntities;

namespace Ex03.GarageLogic.EnergiesFillingInfo
{
    public sealed class FuelFillingInfo : EnergyFillingInfo
    {
        private readonly Enums.eFuelType r_FuelType;

        public FuelFillingInfo(Enums.eFuelType i_FuelType, float i_MaximumEnergyFillingAmount)
            : base(i_MaximumEnergyFillingAmount)
        {
            r_FuelType = i_FuelType;
        }

        public Enums.eFuelType FuelType { get { return r_FuelType; } }

        public override string ToString()
        {
            return string.Format("{0}, Fuel type:{1}", base.ToString(), FuelType);
        }
    }
}
