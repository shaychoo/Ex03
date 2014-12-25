using System.Collections.Generic;

namespace Ex03.GarageLogic.BaseEntities
{
    public abstract class Vehicle
    {
        public Vehicle(EnergySource i_EnergySources)
        {
            EnergySource = i_EnergySources;
        }

        public string ModelName { get; set; }

        public string LicencePlate { get; set; }

        public float RemainingEnergyPercentage { get; set; }

        public List<Wheel> Wheels { get; set; }

        public EnergySource EnergySource { get; private set; }

        public void InflateWheelsToMaximum()
        {
            foreach (var wheel in Wheels)
            {
                float amountToInflate = wheel.MaximumAirPressure - wheel.CurrentAirPressure;
                wheel.Inflate(amountToInflate);
            }
        }

        public void FillEnergy(EnergyFillingInfo i_Energy)
        {
            this.EnergySource.Fill(i_Energy);
        }
    }
}
