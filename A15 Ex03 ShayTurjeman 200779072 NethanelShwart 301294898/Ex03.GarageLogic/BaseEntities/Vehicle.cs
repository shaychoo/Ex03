using System.Collections.Generic;

namespace Ex03.GarageLogic.BaseEntities
{
    public abstract class Vehicle
    {
        protected abstract int MumberOfWheels { get; }

        protected abstract float WheelsMaximumAirPressure { get; }

        public Vehicle(EnergySource i_EnergySources)
        {
            EnergySource = i_EnergySources;
        }

        public string ModelName { get; set; }

        public string LicensePlate { get; set; }

        

        public List<Wheel> Wheels { get; set; }

        public EnergySource EnergySource { get; private set; }

        public float RemainingEnergyPercentage { get { return EnergySource.CurrentEnergyAmountInPercentage; }}

        public void InflateWheelsToMaximum()
        {
            foreach (var wheel in Wheels)
            {
                float amountToInflate = wheel.MaximumAirPressure - wheel.CurrentAirPressure;
                wheel.Inflate(amountToInflate);
            }
        }

        public void FillEnergy(float i_Amount)
        {
            EnergySource.Fill(i_Amount);
        }
    }
}
