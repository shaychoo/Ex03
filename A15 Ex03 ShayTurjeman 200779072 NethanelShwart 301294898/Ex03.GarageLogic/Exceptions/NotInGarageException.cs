using System;

namespace Ex03.GarageLogic.Exceptions
{
    public class VehicleStateInGarageException : Exception
    {
        public VehicleStateInGarageException(bool i_IsInGarage, string i_LicensePlate)
        {
            IsInGarage = i_IsInGarage;
            LicensePlate = i_LicensePlate;
        }

        public bool IsInGarage { get; set; }
        public string LicensePlate { get; set; }

        public override string Message
        {
            get
            {
                return string.Format("Vehicle with license plate {0} {1}", LicensePlate,
                    IsInGarage ? "is not in the garage" : "is already in the garage");
            }
        }
    }
}