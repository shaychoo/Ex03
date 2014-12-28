using Ex03.GarageLogic.BaseEntities;

namespace Ex03.GarageLogic.VehiclesInfo
{
    public class MotorcycleInfo : VehicleInfo
    {
        public MotorcycleInfo(string i_VehicleModelName, string i_WheelsManufacturerName, string i_LicensePlate,
            int i_NumberOfWheels,
            float i_WheelsMaximumAirPressure, Enums.eLicenseType i_LicenseType, int i_EngineVolume)
            : base(
                i_VehicleModelName, i_WheelsManufacturerName, i_LicensePlate, i_NumberOfWheels,
                i_WheelsMaximumAirPressure)
        {
            LicenseType = i_LicenseType;
            EngineVolume = i_EngineVolume;
        }

        public Enums.eLicenseType LicenseType { get; set; }

        public int EngineVolume { get; set; }

        public override string ToString()
        {
            return string.Format("{0}, License type: {1}, Engine volume: {2}", base.ToString(), LicenseType,
                EngineVolume);
        }
    }
}