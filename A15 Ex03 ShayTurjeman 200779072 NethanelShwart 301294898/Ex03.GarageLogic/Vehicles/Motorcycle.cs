using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic.BaseEntities;
using Ex03.GarageLogic.VehiclesInfo;

namespace Ex03.GarageLogic.Vehicles
{
    public class Motorcycle : Vehicle
    {
        private readonly MotorcycleInfo r_MotorcycleInfo;
        public Motorcycle(VehicleInfo i_VehicleInfo, EnergySource i_EnergySource)
            : base(i_VehicleInfo, i_EnergySource)
        {
            r_MotorcycleInfo = Helpers.StrongArgumentNeededTypeCheckAndCast<MotorcycleInfo>(i_VehicleInfo);
        }

        public MotorcycleInfo MotorcycleInfo
        {
            get { return r_MotorcycleInfo; }
        }

    }
}
