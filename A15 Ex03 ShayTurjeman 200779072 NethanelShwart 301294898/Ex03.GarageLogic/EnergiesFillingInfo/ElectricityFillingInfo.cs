using Ex03.GarageLogic.BaseEntities;

namespace Ex03.GarageLogic.EnergiesFillingInfo
{
    public sealed class ElectricityFillingInfo : EnergyFillingInfo
    {
        public ElectricityFillingInfo( float i_MaximumEnergyFillingAmount)
            : base(i_MaximumEnergyFillingAmount)
        {
            
        }

        public override string ToString()
        {
            return string.Format("{0}", base.ToString());
        }
    }
}