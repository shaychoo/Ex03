using System.Collections.Generic;

namespace Ex03.GarageLogic.BaseEntities
{
    public abstract class Vehicle
    {
        public string ModelName { get; set; }

        public string LicencePlate { get; set; }

        public float RemainingEnergyPercentage { get; set; }

        public List<Wheel> Wheels { get; set; }

        public EnergySource EnergySource { get; set; }

        public void InflateWheelsToMaximum()
        {
            foreach (var wheel in Wheels)
            {
                float amountToInflate = wheel.MaximumAirPressure - wheel.CurrentAirPressure;
                wheel.Inflate(amountToInflate);
            }
        }
    }
}
