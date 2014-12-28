using System.Collections.Generic;

namespace Ex03.GarageLogic.BaseEntities
{
    public abstract class Vehicle
    {
        public Vehicle(VehicleInfo i_VehicleInfo, EnergySource i_EnergySource, float i_CurrentAirPressure)
        {
            VehicleInfo = i_VehicleInfo;
            EnergySource = i_EnergySource;
            Wheels = new List<Wheel>(VehicleInfo.NumberOfWheels);
            for (int i = 0 ; i < VehicleInfo.NumberOfWheels ; i++)
            {
                Wheels.Add(new Wheel(VehicleInfo.WheelsManufacturerName, i_CurrentAirPressure,
                    VehicleInfo.WheelsMaximumAirPressure));
            }
        }

        protected VehicleInfo VehicleInfo { get; set; }

        public List<Wheel> Wheels { get; set; }

        public EnergySource EnergySource { get; private set; }

        public float RemainingEnergyPercentage
        {
            get { return EnergySource.CurrentEnergyAmountInPercentage; }
        }

        public string LicensePlate
        {
            get { return VehicleInfo.LicensePlate; }
        }

        public void InflateWheelsToMaximum()
        {
            foreach (Wheel wheel in Wheels)
            {
                float amountToInflate = wheel.MaximumAirPressure - wheel.CurrentAirPressure;
                wheel.Inflate(amountToInflate);
            }
        }

        public void FillEnergy(float i_Amount)
        {
            EnergySource.Fill(i_Amount);
        }

        public override string ToString()
        {
            return
                string.Format(
                    "License plate: {0}, Remaining energy percentage: {1}. Vehicle info: {2}. Wheels info: {3}. Energy source info: {4}.",
                    LicensePlate, RemainingEnergyPercentage, VehicleInfo, Wheels[0],
                    EnergySource);
        }
    }
}