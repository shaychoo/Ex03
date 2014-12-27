using System;
using Ex03.GarageLogic.BaseEntities;
using Ex03.GarageLogic.EnergiesFillingInfo;
using Ex03.GarageLogic.EnergySources;
using Ex03.GarageLogic.Vehicles;
using Ex03.GarageLogic.VehiclesInfo;

namespace Ex03.GarageLogic
{
    public static class VehicleCreation
    {
        public static Vehicle CreateNewVehicle(eVehicleType i_VehicleType, eEnergySourceType i_EnergySourceType,
            float i_CurrentEnergyAmount, string i_VehicleModelName, string i_WheelsManufacturerName, string i_LicensePlate, float i_CurrentAirPressure,
            params object[] i_SpecificVehicleParams)
        {
            VehicleInfo vehicleInfo = getVehicleInfo(i_VehicleType, i_VehicleModelName, i_WheelsManufacturerName, i_LicensePlate, i_SpecificVehicleParams);
            EnergySource energySource = getEnergySource(i_VehicleType, i_EnergySourceType, i_CurrentEnergyAmount);
            Vehicle resultVehicle = getVehicle(i_VehicleType, vehicleInfo, energySource, i_CurrentAirPressure);

            return resultVehicle;
        }

        private static Vehicle getVehicle(eVehicleType i_VehicleType, VehicleInfo vehicleInfo, EnergySource energySource, float i_CurrentAirPressure)
        {
            Vehicle resultVehicle;
            switch (i_VehicleType)
            {
                case eVehicleType.Car:
                    resultVehicle = new Car(vehicleInfo, energySource, i_CurrentAirPressure);
                    break;
                case eVehicleType.Motorcycle:
                    resultVehicle = new Motorcycle(vehicleInfo, energySource, i_CurrentAirPressure);
                    break;
                case eVehicleType.Truck:
                    resultVehicle = new Truck(vehicleInfo, energySource, i_CurrentAirPressure);
                    break;
                default:
                    throw new ArgumentOutOfRangeException("i_VehicleType");
            }
            return resultVehicle;
        }

        private static EnergySource getEnergySource(eVehicleType i_VehicleType, eEnergySourceType i_EnergySourceType,
            float i_CurrentEnergyAmount)
        {
            EnergySource energySource;
            switch (i_EnergySourceType)
            {
                case eEnergySourceType.Fuel:
                    energySource = new FuelEnergySource(i_CurrentEnergyAmount,
                        getFuelEnergyFillingInfoByVehicleType(i_VehicleType));
                    break;
                case eEnergySourceType.Electricity:
                    energySource = new ElectricEnergySource(i_CurrentEnergyAmount,
                        getElectricityEnergyFillingInfoByVehicleType(i_VehicleType));
                    break;
                default:
                    throw new ArgumentOutOfRangeException("i_EnergySourceType");
            }
            return energySource;
        }

        private static VehicleInfo getVehicleInfo(eVehicleType i_VehicleType, string i_VehicleModelName, string i_WheelsManufacturerName, string i_LicensePlate,
            object[] i_SpecificVehicleParams)
        {
            VehicleInfo vehicleInfo;

            switch (i_VehicleType)
            {
                case eVehicleType.Car:
                    Enums.eCarColor carColor =
                        Helpers.StrongArgumentNeededTypeCheckAndCast<Enums.eCarColor>(
                            i_SpecificVehicleParams[(int)eCarSpecificParams.CarColor]);
                    Enums.eNumberOfDoors numberOfDoors =
                        Helpers.StrongArgumentNeededTypeCheckAndCast<Enums.eNumberOfDoors>(
                            i_SpecificVehicleParams[(int)eCarSpecificParams.NumberOfDoors]);

                    vehicleInfo = new CarInfo(i_VehicleModelName, i_WheelsManufacturerName, i_LicensePlate, Constants.k_CarWheelsNumber,
                        Constants.k_CarWheelsMaxAirPressure,
                        carColor, numberOfDoors);

                    break;
                case eVehicleType.Motorcycle:
                    Enums.eLicenseType licenseType =
                        Helpers.StrongArgumentNeededTypeCheckAndCast<Enums.eLicenseType>(
                            i_SpecificVehicleParams[(int)eMotorcycelSpecificParams.LicenseType]);
                    int engineVolume =
                        Helpers.StrongArgumentNeededTypeCheckAndCast<int>(
                            i_SpecificVehicleParams[(int)eMotorcycelSpecificParams.EngineVolume]);

                    vehicleInfo = new MotorcycleInfo(i_VehicleModelName, i_WheelsManufacturerName, i_LicensePlate, Constants.k_MotorcycleWheelsNumber,
                        Constants.k_MotorcycleWheelsMaxAirPressure, licenseType, engineVolume);

                    break;
                case eVehicleType.Truck:

                    vehicleInfo = new TruckInfo(i_VehicleModelName, i_WheelsManufacturerName, i_LicensePlate, Constants.k_TruckWheelsNumber,
                        Constants.k_TruckWheelsMaxAirPressure);

                    break;
                default:
                    throw new ArgumentOutOfRangeException("i_VehicleType");
            }
            return vehicleInfo;
        }

        private static EnergyFillingInfo getElectricityEnergyFillingInfoByVehicleType(eVehicleType i_VehicleType)
        {
            EnergyFillingInfo electricityFillingInfo = null;
            switch (i_VehicleType)
            {
                case eVehicleType.Car:
                    electricityFillingInfo = new ElectricityFillingInfo(Constants.k_CarBatteryCapacity);
                    break;
                case eVehicleType.Motorcycle:
                    electricityFillingInfo = new ElectricityFillingInfo(Constants.k_MotorcycleBatteryCapacity);
                    break;
                case eVehicleType.Truck:
                    throw new NotSupportedException("Truck with electricity engine is not supported");
                default:
                    throw new ArgumentOutOfRangeException("i_VehicleType");
            }
            return electricityFillingInfo;
        }

        private static EnergyFillingInfo getFuelEnergyFillingInfoByVehicleType(eVehicleType i_VehicleType)
        {
            EnergyFillingInfo fuelFillingInfo = null;
            switch (i_VehicleType)
            {
                case eVehicleType.Car:
                    fuelFillingInfo = new FuelFillingInfo(Constants.k_CarFuelType, Constants.k_CarFuelTankVolume);
                    break;
                case eVehicleType.Motorcycle:
                    fuelFillingInfo = new FuelFillingInfo(Constants.k_MotorcycleFuelType,
                        Constants.k_MotorcycleFuelTankVolume);
                    break;
                case eVehicleType.Truck:
                    fuelFillingInfo = new FuelFillingInfo(Constants.k_TruckFuelType, Constants.k_TruckFuelTankVolume);
                    break;
                default:
                    throw new ArgumentOutOfRangeException("i_VehicleType");
            }
            return fuelFillingInfo;
        }

        public enum eVehicleType
        {
            Car = 0,
            Motorcycle = 1,
            Truck = 2,
        }

        public enum eEnergySourceType
        {
            Fuel = 0,
            Electricity = 1,
        }

        public enum eCarSpecificParams
        {
            CarColor = 0,
            NumberOfDoors = 1,
        }

        public enum eMotorcycelSpecificParams
        {
            LicenseType = 0,
            EngineVolume = 1,
        }

        private static class Constants
        {
            public const float k_MotorcycleWheelsMaxAirPressure = 30.0f;
            public const float k_CarWheelsMaxAirPressure = 29.0f;
            public const float k_TruckWheelsMaxAirPressure = 24.0f;

            public const int k_MotorcycleWheelsNumber = 2;
            public const int k_CarWheelsNumber = 4;
            public const int k_TruckWheelsNumber = 8;

            public const Enums.eFuelType k_MotorcycleFuelType = Enums.eFuelType.Octan96;
            public const Enums.eFuelType k_CarFuelType = Enums.eFuelType.Octan95;
            public const Enums.eFuelType k_TruckFuelType = Enums.eFuelType.Soler;

            public const float k_MotorcycleFuelTankVolume = 6.5f;
            public const float k_CarFuelTankVolume = 45.0f;
            public const float k_TruckFuelTankVolume = 200.0f;

            public const float k_MotorcycleBatteryCapacity = 1.8f;
            public const float k_CarBatteryCapacity = 2.6f;
        }
    }
}