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
            White = 0,
            Green = 1,
            Blue = 2,
            Red = 3,
        }

        public enum eNumberOfDoors
        {
            Two = 0,
            Three = 1,
            Four = 2,
            Five = 3
        }

        public enum eLicenseType
        {
            A = 0,
            A1 = 1,
            AB = 2,
            B2 = 3,
        }
    }
}
