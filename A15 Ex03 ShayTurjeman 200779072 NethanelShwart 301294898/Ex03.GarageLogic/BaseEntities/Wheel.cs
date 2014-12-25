using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic.Exceptions;

namespace Ex03.GarageLogic.BaseEntities
{
    public class Wheel
    {
        private const float k_MinValue = 0.0f;

        public string ManufacturerName { get; set; }

        public float CurrentAirPressure { get; set; }

        public float MaximumAirPressure { get; set; }

        public void Inflate(float i_Amount)
        {
            float maxAllowedAirPressure = MaximumAirPressure - CurrentAirPressure;

            if (i_Amount < k_MinValue)
            {
                throw new ValueOutOfRangeException(k_MinValue, maxAllowedAirPressure, "Trying to inflate less then minimum allowed air pressure");
            }
            if (i_Amount > maxAllowedAirPressure)
            {
                throw new ValueOutOfRangeException(k_MinValue, maxAllowedAirPressure, "Trying to inflate more then maximum allowed air pressure");
            }
            CurrentAirPressure += i_Amount;
        }
    }
}
