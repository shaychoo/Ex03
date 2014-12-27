using System;
using System.Collections.Generic;
using System.Text;
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

        /// <summary>
        /// sets the car status in garage to Enums.eStatusInGarage.InRepair
        /// </summary>
        /// <param name="i_OwnerName"></param>
        /// <param name="i_OwnerPhone"></param>
        /// <param name="i_VehicleType"></param>
        /// <param name="i_EnergySourceType"></param>
        /// <param name="i_CurrentEnergyAmount"></param>
        /// <param name="i_VehicleModelName"></param>
        /// <param name="i_WheelsManufacturerName"></param>
        /// <param name="i_LicensePlate"></param>
        /// <param name="i_CurrentAirPressure"></param>
        /// <param name="i_SpecificVehicleParams">used in case of extra params thats relevant to specific vehicle type (see example)</param>
        /// <example>
        /// 
        /// GarageManager garageManager = new GarageManager();
        /// 
        /// string owner = "Yossi";
        /// string phoneNumber = "050-1234567";
        /// VehicleCreation.eVehicleType vehicleType =VehicleCreation.eVehicleType.Car;
        /// VehicleCreation.eEnergySourceType energySourceType = VehicleCreation.eEnergySourceType.Fuel;
        /// float currentEnergyAmount = 40.0f;
        /// string vehicleModelName = "KIA";
        /// string wheelsManufacturerName = "Michelin";
        /// string licensePlate = "12-345-67";
        /// float currentAirPressure = 20.0f;
        /// 
        /// object[] specificCarParams  = new object[2];
        /// specificCarParams[(int)VehicleCreation.eCarSpecificParams.CarColor] = Enums.eCarColor.Red;
        /// specificCarParams[(int)VehicleCreation.eCarSpecificParams.NumberOfDoors] = Enums.eNumberOfDoors.Four;
        /// 
        /// garageManager.EnterVehicleToGarage(owner,phoneNumber, vehicleType, energySourceType, currentEnergyAmount, 
        ///                             vehicleModelName, wheelsManufacturerName, licensePlate, currentAirPressure, specificCarParams);
        /// </example>
        public void EnterVehicleToGarage(string i_OwnerName, string i_OwnerPhone, VehicleCreation.eVehicleType i_VehicleType,
            VehicleCreation.eEnergySourceType i_EnergySourceType,
            float i_CurrentEnergyAmount, string i_VehicleModelName, string i_WheelsManufacturerName, string i_LicensePlate, float i_CurrentAirPressure,
            params object[] i_SpecificVehicleParams)
        {
            if (!r_VehiclesDictionaryByLicensePlate.ContainsKey(i_LicensePlate))
            {
                //new vehicle
                VehicleInGarageInfo newVehicleInGarageInfo = new VehicleInGarageInfo(i_OwnerName, i_OwnerPhone,
                        Enums.eStatusInGarage.InRepair);
                Vehicle newVehicle = VehicleCreation.CreateNewVehicle(i_VehicleType,
                    i_EnergySourceType, i_CurrentEnergyAmount, i_VehicleModelName, i_WheelsManufacturerName, i_LicensePlate, i_CurrentAirPressure,
                    i_SpecificVehicleParams);
                r_VehiclesDictionaryByLicensePlate.Add(i_LicensePlate, newVehicle);
                r_VehiclesInGarageInfo.Add(newVehicle, newVehicleInGarageInfo);
            }
            else
            {
                //existing vehicle
                r_VehiclesInGarageInfo[r_VehiclesDictionaryByLicensePlate[i_LicensePlate]].StatusInGarage =
                    Enums.eStatusInGarage.InRepair;
            }
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

            r_VehiclesInGarageInfo[theVehicle].StatusInGarage = i_NewStatusInGarage;
        }

        public List<string> GetVehiclesLicensePlatesByStatussInGarage(Enums.eStatusInGarage i_StatussInGarage)
        {
            List<string> vehiclesLicensePlatesByStatussInGarage = new List<string>();

            foreach (KeyValuePair<Vehicle, VehicleInGarageInfo> vehicleInGarageInfoKeyValuePair in r_VehiclesInGarageInfo)
            {
                if ((i_StatussInGarage & vehicleInGarageInfoKeyValuePair.Value.StatusInGarage) == vehicleInGarageInfoKeyValuePair.Value.StatusInGarage)
                {
                    vehiclesLicensePlatesByStatussInGarage.Add(vehicleInGarageInfoKeyValuePair.Key.LicensePlate);
                }
            }

            return vehiclesLicensePlatesByStatussInGarage;
        }

        private Vehicle getVehicleInGarage(string i_LicensePlate)
        {
            bool vehicleIsInGarage = true;
            Vehicle theVehicle = null;
            if (!r_VehiclesDictionaryByLicensePlate.ContainsKey(i_LicensePlate))
            {
                vehicleIsInGarage = false;
            }
            else
            {
                theVehicle = r_VehiclesDictionaryByLicensePlate[i_LicensePlate];
                if (r_VehiclesInGarageInfo[theVehicle].StatusInGarage == Enums.eStatusInGarage.Paid)
                {
                    vehicleIsInGarage = false;
                }
            }
            if (!vehicleIsInGarage)
            {
                throw new VehicleStateInGarageException(vehicleIsInGarage, i_LicensePlate);
            }
            return theVehicle;
        }

        public string GetVehiclesDetails()
        {
            string vehiclesDetails;
            if (r_VehiclesDictionaryByLicensePlate.Count == 0)
            {
                return "There is no vehicles in the garage";
            }
            else
            {
                StringBuilder detailsBuilder = new StringBuilder();
                foreach (Vehicle vehicle in r_VehiclesDictionaryByLicensePlate.Values)
                {
                    detailsBuilder.Append(string.Format(@"

/*
{0}
{1}
*/", r_VehiclesInGarageInfo[vehicle].ToString(), vehicle.ToString()));
                }

                vehiclesDetails = detailsBuilder.ToString();
            }
            return vehiclesDetails;
        }
    }
}
