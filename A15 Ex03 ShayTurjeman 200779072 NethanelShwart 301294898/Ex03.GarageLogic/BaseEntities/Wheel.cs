namespace Ex03.GarageLogic.BaseEntities
{
    public class Wheel
    {
        private const float k_MinInflatingValue = 0.0f;

        public Wheel(string i_ManufacturerName, float i_CurrentAirPressure, float i_MaximumAirPressure)
        {
            ManufacturerName = i_ManufacturerName;
            CurrentAirPressure = i_CurrentAirPressure;
            MaximumAirPressure = i_MaximumAirPressure;
        }

        public string ManufacturerName { get; set; }

        public float CurrentAirPressure { get; set; }

        public float MaximumAirPressure { get; set; }

        public void Inflate(float i_Amount)
        {
            string valueName = "Amount of air to inflate";
            Helpers.IsPossibleAddingValueInRangeCheck(i_Amount, CurrentAirPressure, k_MinInflatingValue,
                MaximumAirPressure, valueName);
            CurrentAirPressure += i_Amount;
        }

        public override string ToString()
        {
            return string.Format("Manufacturer name: {0}, Maximum air pressure: {1}, Current air pressure: {2}",
                ManufacturerName, MaximumAirPressure, CurrentAirPressure);
        }
    }
}