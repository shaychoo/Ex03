using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic.BaseEntities
{
    public class VehicleInGarageInfo
    {
        public string OwnerName { get; set; }

        public string OwnerPhone { get; set; }

        public Enums.eStatusInGarage Status { get; set; }
    }
}
