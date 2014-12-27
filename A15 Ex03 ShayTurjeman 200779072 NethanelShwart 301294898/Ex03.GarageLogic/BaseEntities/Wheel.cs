using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic.Exceptions;

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
            Helpers.AddingValueInRangeCheck(i_Amount, CurrentAirPressure, k_MinInflatingValue, MaximumAirPressure);
            CurrentAirPressure += i_Amount;
        }
    }
}
