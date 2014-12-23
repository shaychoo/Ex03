using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic.BaseEntities
{
    public class Wheel
    {
        public string ManufacturerName { get; set; }

        public float CurrentAirPressure { get; set; }

        public float MaximumAirPressure { get; set; }

        public void Inflate(float i_Amount)
        {
            if (CurrentAirPressure == MaximumAirPressure)
            {
                throw new Exception("");
            }
        }
    }
}
