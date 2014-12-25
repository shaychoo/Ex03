using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic.BaseEntities;
using Ex03.GarageLogic.Energies;
using Ex03.GarageLogic.EnergySources;
using Ex03.GarageLogic.Exceptions;
using Ex03.GarageLogic.Vehicles;

namespace Ex03.GarageLogic
{
    public class GarageManager
    {
        private readonly Dictionary<string, Vehicle> r_VehiclesDictionaryByLicencePlate = new Dictionary<string,Vehicle>();
        private readonly Dictionary<Vehicle,VehicleInGarageInfo> r_VehiclesInGarageInfo = new Dictionary<Vehicle, VehicleInGarageInfo>();
        //052-9846543
        public void EnterNewCar( )
        {
            r_VehiclesDictionaryByLicencePlate.Add("fkjh", new Car(new ElectricEnergySource()));
        }

        public void RefillFuel(string i_LicencePlate, Enums.eFuelType i_FuelType, int i_Amount)
        {
            EnergyFillingInfo eEnergyFillingInfo = new FuelFillingInfo(i_FuelType, i_Amount);
            fillVehicleEnergySource(i_LicencePlate,eEnergyFillingInfo);
            
        }

        public void RechargeElectricity(string i_LicencePlate, int i_Amount)
        {
            EnergyFillingInfo eEnergyFillingInfo = new ElectricityFillingInfo(i_Amount);
            fillVehicleEnergySource(i_LicencePlate,eEnergyFillingInfo);
        }

        private void fillVehicleEnergySource(string i_LicencePlate, EnergyFillingInfo i_EnergyFillingInfo)
        {
            getVehicleInGarage(i_LicencePlate).FillEnergy(i_EnergyFillingInfo);
        }

        public void InflateWheelsToMaximum(string i_LicencePlate)
        {
            getVehicleInGarage(i_LicencePlate).InflateWheelsToMaximum();
        }

        public void ChangeCarStatuse(string i_LicencePlate ,Enums.eStatusInGarage i_NewStatusInGarage)
        {
            Vehicle theVehicle = getVehicleInGarage(i_LicencePlate);

            r_VehiclesInGarageInfo[theVehicle].Status = i_NewStatusInGarage;
        }

        public List<string> GetVehiclesLicencePlatesByStatussInGarage(Enums.eStatusInGarage i_StatussInGarage)
        {
            List<string> vehiclesLicencePlatesByStatussInGarage = new List<string>();

            foreach (KeyValuePair<Vehicle,VehicleInGarageInfo> vehicleInGarageInfoKeyValuePair in r_VehiclesInGarageInfo)
            {
                if ((i_StatussInGarage & vehicleInGarageInfoKeyValuePair.Value.Status) == vehicleInGarageInfoKeyValuePair.Value.Status)
                {
                    vehiclesLicencePlatesByStatussInGarage.Add(vehicleInGarageInfoKeyValuePair.Key.LicencePlate);
                }
            }

            return vehiclesLicencePlatesByStatussInGarage;
        }

        private Vehicle getVehicleInGarage(string i_LicencePlate)
        {
            if (!r_VehiclesDictionaryByLicencePlate.ContainsKey(i_LicencePlate))
            {
                throw new NotInGarageException("Vehicle is not found in the garage");
            }

            Vehicle theVehicle = r_VehiclesDictionaryByLicencePlate[i_LicencePlate];

            if (r_VehiclesInGarageInfo[theVehicle].Status == Enums.eStatusInGarage.Paid)
            {
                throw new NotInGarageException("Vehicle already left the garage");
            }

            return theVehicle;
        }
    }
}
