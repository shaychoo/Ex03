using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Enums
    {
        public enum eFuelType
        {
            Octan98,
            Octan96,
            Octan95,
            Soler
        }

        [Flags]
        public enum eStatusInGarage
        {
            InRepair = 1,
            Repaired = 2,
            Paid = 4,
        }

        public enum eCarColor
        {
            White,
            Green,
            Blue,
            Red,
        }

        public enum eNumberOfDoors
        {
            Two,
            Three,
            Four,
            Five
        }

        public enum eLicenseType
        {
            A,
            A1,
            AB,
            B2,
        }
    }
}
