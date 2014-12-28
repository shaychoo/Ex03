namespace Ex03.GarageLogic.BaseEntities
{
    public abstract class VehicleInfo
    {
        public VehicleInfo(string i_VehicleModelName, string i_WheelsManufacturerName, string i_LicensePlate,
            int i_NumberOfWheels, float i_WheelsMaximumAirPressure)
        {
            VehicleModelName = i_VehicleModelName;
            WheelsManufacturerName = i_WheelsManufacturerName;
            Helpers.CheckLicensePlateFormat(i_LicensePlate);
            LicensePlate = i_LicensePlate;
            NumberOfWheels = i_NumberOfWheels;
            WheelsMaximumAirPressure = i_WheelsMaximumAirPressure;
        }

        public string VehicleModelName { get; set; }

        public string WheelsManufacturerName { get; set; }

        public string LicensePlate { get; set; }

        public int NumberOfWheels { get; set; }

        public float WheelsMaximumAirPressure { get; set; }

        public override string ToString()
        {
            return string.Format("Vehicle model name: {0}, Number of wheels: {1}"
                , VehicleModelName, NumberOfWheels);
        }
    }
}