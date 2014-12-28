namespace Ex03.GarageLogic.BaseEntities
{
    public abstract class EnergySource
    {
        protected const float k_MinimumEnergyFillingValue = 0.0f;
        private readonly EnergyFillingInfo r_EnergyFillingInfo;

        public EnergySource(float i_CurrentEnergyAmount, EnergyFillingInfo i_EnergyFillingInfo)
        {
            CurrentEnergyAmount = i_CurrentEnergyAmount;
            r_EnergyFillingInfo = i_EnergyFillingInfo;

            // check that started energy amount is in range by the energy filling info
            string valueName = "Current energy amount";
            Helpers.IsPossibleAddingValueInRangeCheck(0, CurrentEnergyAmount, k_MinimumEnergyFillingValue,
                r_EnergyFillingInfo.MaximumAmount, valueName);
        }

        public float CurrentEnergyAmount { get; protected set; }

        public float CurrentEnergyAmountInPercentage
        {
            get { return (100.0f * CurrentEnergyAmount) / r_EnergyFillingInfo.MaximumAmount; }
        }

        public abstract void Fill(float i_Amount);

        public override string ToString()
        {
            return string.Format(@"Energy filling info: {0}, Current energy amount: {1}", r_EnergyFillingInfo,
                CurrentEnergyAmount);
        }
    }
}