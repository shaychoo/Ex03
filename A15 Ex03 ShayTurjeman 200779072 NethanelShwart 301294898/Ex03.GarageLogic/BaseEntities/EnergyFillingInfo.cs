namespace Ex03.GarageLogic.BaseEntities
{
    public abstract class EnergyFillingInfo
    {
        protected readonly float r_MaximumEnergyFillingAmount;

        public EnergyFillingInfo(float i_MaximumEnergyFillingAmount)
        {
            r_MaximumEnergyFillingAmount = i_MaximumEnergyFillingAmount;
        }

        public float MaximumAmount
        {
            get { return r_MaximumEnergyFillingAmount; }
        }

        public override string ToString()
        {
            return string.Format("Maximum amount:{0}", MaximumAmount);
        }
    }
}