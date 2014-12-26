using System;
using System.Collections.Generic;
using Ex03.GarageLogic.BaseEntities;
using Ex03.GarageLogic.EnergiesFillingInfo;
using Ex03.GarageLogic.EnergySources;
using Ex03.GarageLogic.Exceptions;

namespace Ex03.GarageLogic
{
    public class GarageManager
    {
        private readonly Dictionary<string, Vehicle> r_VehiclesDictionaryByLicensePlate = new Dictionary<string, Vehicle>();
        private readonly Dictionary<Vehicle, VehicleInGarageInfo> r_VehiclesInGarageInfo = new Dictionary<Vehicle, VehicleInGarageInfo>();
        
        public void EnterNewCar()
        {

        }

        public void RefillFuel(string i_LicensePlate, Enums.eFuelType i_FuelType, int i_Amount)
        {
            Vehicle theVehicle = getVehicleInGarage(i_LicensePlate);
            FuelEnergySource fuelEnergySource = theVehicle.EnergySource as FuelEnergySource;
            
            if (fuelEnergySource == null)
            {
                throw new ArgumentException("license plate doesn't belong to fuel vehicle");
            }

            bool isCorrectFuelType = fuelEnergySource.IsCorrectFuelType(i_FuelType);

            if (!isCorrectFuelType)
            {
                throw new ArgumentException("fuel type is incorrect");
            }

            theVehicle.FillEnergy(i_Amount);
        }

        public void RechargeElectricity(string i_LicensePlate, int i_Amount)
        {
            Vehicle theVehicle = getVehicleInGarage(i_LicensePlate);
            ElectricEnergySource electricEnergySource = theVehicle.EnergySource as ElectricEnergySource;

            if (electricEnergySource == null)
            {
                throw new ArgumentException("license plate doesn't belong to electric vehicle");
            }

            theVehicle.FillEnergy(i_Amount);
        }

        

        public void InflateWheelsToMaximum(string i_LicensePlate)
        {
            getVehicleInGarage(i_LicensePlate).InflateWheelsToMaximum();
        }

        public void ChangeCarStatuse(string i_LicensePlate, Enums.eStatusInGarage i_NewStatusInGarage)
        {
            Vehicle theVehicle = getVehicleInGarage(i_LicensePlate);

            r_VehiclesInGarageInfo[theVehicle].Status = i_NewStatusInGarage;
        }

        public List<string> GetVehiclesLicensePlatesByStatussInGarage(Enums.eStatusInGarage i_StatussInGarage)
        {
            List<string> vehiclesLicensePlatesByStatussInGarage = new List<string>();

            foreach (KeyValuePair<Vehicle, VehicleInGarageInfo> vehicleInGarageInfoKeyValuePair in r_VehiclesInGarageInfo)
            {
                if ((i_StatussInGarage & vehicleInGarageInfoKeyValuePair.Value.Status) == vehicleInGarageInfoKeyValuePair.Value.Status)
                {
                    vehiclesLicensePlatesByStatussInGarage.Add(vehicleInGarageInfoKeyValuePair.Key.LicensePlate);
                }
            }

            return vehiclesLicensePlatesByStatussInGarage;
        }

        private Vehicle getVehicleInGarage(string i_LicensePlate)
        {
            if (!r_VehiclesDictionaryByLicensePlate.ContainsKey(i_LicensePlate))
            {
                throw new NotInGarageException("Vehicle is not found in the garage");
            }

            Vehicle theVehicle = r_VehiclesDictionaryByLicensePlate[i_LicensePlate];

            if (r_VehiclesInGarageInfo[theVehicle].Status == Enums.eStatusInGarage.Paid)
            {
                throw new NotInGarageException("Vehicle already left the garage");
            }

            return theVehicle;
        }
    }
}
