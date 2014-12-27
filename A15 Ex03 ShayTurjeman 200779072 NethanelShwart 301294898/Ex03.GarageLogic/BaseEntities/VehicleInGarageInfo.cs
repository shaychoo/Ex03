using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic.BaseEntities
{
    public class VehicleInGarageInfo
    {
        public VehicleInGarageInfo(string i_OwnerName, string i_OwnerPhone, Enums.eStatusInGarage i_Status)
        {
            OwnerName = i_OwnerName;
            Helpers.CheckPhoneFormat(i_OwnerPhone);
            OwnerPhone = i_OwnerPhone;
            Status = i_Status;
        }

        public string OwnerName { get; set; }

        public string OwnerPhone { get; set; }

        public Enums.eStatusInGarage Status { get; set; }

    }
}
