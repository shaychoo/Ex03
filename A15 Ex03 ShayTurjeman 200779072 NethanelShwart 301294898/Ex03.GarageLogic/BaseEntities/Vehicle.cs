using System.Collections.Generic;

namespace Ex03.GarageLogic.BaseEntities
{
    public abstract class Vehicle
    {
        public Vehicle(VehicleInfo i_VehicleInfo,EnergySource i_EnergySource)
        {
            VehicleInfo = i_VehicleInfo;
            EnergySource = i_EnergySource;
        }

        protected VehicleInfo VehicleInfo { get; set; }

        public List<Wheel> Wheels { get; set; }

        public EnergySource EnergySource { get; private set; }

        public float RemainingEnergyPercentage
        {
            get { return EnergySource.CurrentEnergyAmountInPercentage; }
        }

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

        public string LicensePlate { get { return VehicleInfo.LicensePlate; } }
    }
}
