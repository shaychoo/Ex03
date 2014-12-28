using Ex03.GarageLogic.BaseEntities;
using Ex03.GarageLogic.VehiclesInfo;

namespace Ex03.GarageLogic.Vehicles
{
    public class Truck : Vehicle
    {
        private readonly TruckInfo r_TruckInfo;

        public Truck(VehicleInfo i_VehicleInfo, EnergySource i_EnergySource, float i_CurrentAirPressure)
            : base(i_VehicleInfo, i_EnergySource, i_CurrentAirPressure)
        {
            r_TruckInfo = Helpers.StrongArgumentNeededTypeCheckAndCast<TruckInfo>(i_VehicleInfo);
        }

        public TruckInfo TruckInfo
        {
            get { return r_TruckInfo; }
        }
    }
}