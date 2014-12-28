using System;

namespace Ex03.GarageLogic
{
    public class Enums
    {
        public enum eCarColor
        {
            White = 0,
            Green = 1,
            Blue = 2,
            Red = 3,
        }

        public enum eFuelType
        {
            Octan98,
            Octan96,
            Octan95,
            Soler
        }

        public enum eLicenseType
        {
            A = 0,
            A1 = 1,
            AB = 2,
            B2 = 3,
        }

        public enum eNumberOfDoors
        {
            Two = 0,
            Three = 1,
            Four = 2,
            Five = 3
        }

        [Flags]
        public enum eStatusInGarage
        {
            InRepair = 1,
            Repaired = 2,
            Paid = 4,
        }
    }
}