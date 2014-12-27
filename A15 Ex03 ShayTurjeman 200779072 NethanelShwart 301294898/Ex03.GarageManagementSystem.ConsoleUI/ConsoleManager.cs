using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Ex03.GarageLogic;

namespace Ex03.GarageManagementSystem.ConsoleUI
{
    public class ConsoleManager
    {
        private readonly GarageManager r_GarageManager = new GarageManager();

        public ConsoleManager()
        {
            Console.WriteLine("Welcome to Garage Manager!");
            try
            {



                string owner = "Yossi";
                string phoneNumber = "050-1234567";
                VehicleCreation.eVehicleType vehicleType = VehicleCreation.eVehicleType.Car;
                VehicleCreation.eEnergySourceType energySourceType = VehicleCreation.eEnergySourceType.Fuel;
                float currentEnergyAmount = 40.0f;
                string vehicleModelName = "KIA";
                string wheelsManufacturerName = "Michelin";
                string licensePlate = "12-345-67";
                float currentAirPressure = 20.0f;

                object[] specificCarParams = new object[2];
                specificCarParams[(int)VehicleCreation.eCarSpecificParams.CarColor] = Enums.eCarColor.Red;
                specificCarParams[(int)VehicleCreation.eCarSpecificParams.NumberOfDoors] = Enums.eNumberOfDoors.Four;

                r_GarageManager.EnterVehicleToGarage(owner, phoneNumber, vehicleType, energySourceType,
                    currentEnergyAmount,
                    vehicleModelName, wheelsManufacturerName, licensePlate, currentAirPressure, specificCarParams);
            }
            catch (Exception e) 
            {

                writeErrorMessage(e.Message);
            }
            showMainMenu();
        }

        private void showMainMenu()
        {
            string selectedAction = string.Empty;
            do
            {
                Console.WriteLine(@"
Press 1 to enter new car to the garage
Press 2 to see the vehicles in garage list
Press 3 to change vehicle state in garage
Press 4 to inflate vehicle wheels
Press 5 to add fuel to a vehicle
Press 6 to charge to a vehicle
Press 7 to see vehicle full details
Press q to exit
");
                selectedAction = Console.ReadLine();
                if (selectedAction.ToLower() == "q")
                {
                    break;
                }
                handleMenuChoice(selectedAction);
            } while (true);
        }

        private void handleMenuChoice(string i_SelectedAction)
        {
            int iSelectedAction;
            bool inputIsValid = int.TryParse(i_SelectedAction, out iSelectedAction);

            if (inputIsValid)
            {
                eMainAction seletcedAction = (eMainAction)iSelectedAction;
                switch (seletcedAction)
                {
                    case eMainAction.NewVehicle:
                        enterNewVehicleToGarage();
                        break;
                    case eMainAction.VehiclesList:
                        break;
                    case eMainAction.ChangeVehicleState:
                        break;
                    case eMainAction.InflateWheels:
                        break;
                    case eMainAction.Refuel:
                        break;
                    case eMainAction.Recharge:
                        break;
                    case eMainAction.ShowDetails:
                        Console.WriteLine(r_GarageManager.GetVehiclesDetails());
                        break;
                    default:
                        inputIsValid = false;
                        break;
                }
            }

            if (!inputIsValid)
            {
                writeInputIsNotValidErrorMessage();
            }
        }

        private void enterNewVehicleToGarage()
        {
            try
            {
                string messageToUser, ownerName, phoneNumber, vehicleModelName, wheelsManufacturerName, licensePlate;
                float currentEnergyAmount, currentAirPressure;

                messageToUser = "Enter owner name:";
                ownerName = getSimpleStringFromUser(messageToUser);

                messageToUser = "Enter phone number (In format XXX-XXXXXXX):";
                phoneNumber = getOwnerPhoneNumber(messageToUser);
                
                messageToUser = "Select vehicle type:";
                VehicleCreation.eVehicleType vehicleType = getEnumValueFromUserByType<VehicleCreation.eVehicleType>(messageToUser);
                
                messageToUser = "Select energy source type:";
                VehicleCreation.eEnergySourceType energySourceType = getEnumValueFromUserByType<VehicleCreation.eEnergySourceType>(messageToUser);
                
                messageToUser = string.Format("Enter {0} current energy amount:", energySourceType.ToString());
                currentEnergyAmount = getFloatUserInput(messageToUser);
                
                messageToUser = "Enter vehicle model name:";
                vehicleModelName = getSimpleStringFromUser(messageToUser);

                messageToUser = "Enter wheels manufacturer name:";
                wheelsManufacturerName = getSimpleStringFromUser(messageToUser); 

                messageToUser = "Enter license plate (In format XX-XXX-XX):";
                licensePlate = getVehicleLicensePlate(messageToUser);

                messageToUser = "Enter current air pressure:";
                currentAirPressure = getFloatUserInput(messageToUser);
                
                object[] specificVehicleParams = getSpecificVehicleParams(vehicleType);
                
                r_GarageManager.EnterVehicleToGarage(ownerName, phoneNumber, vehicleType, energySourceType,
                    currentEnergyAmount, vehicleModelName, wheelsManufacturerName, licensePlate,currentAirPressure,
                    specificVehicleParams);
            }
            catch (Exception i_Exception)
            {
                writeErrorMessage(i_Exception.Message);
            }
        }

        private object[] getSpecificVehicleParams(VehicleCreation.eVehicleType i_VehicleType)
        {
            object[] specificVehicleParams = null;
            string messasgeToUser;

            switch (i_VehicleType)
            {
                case VehicleCreation.eVehicleType.Car:
                    specificVehicleParams =
                        new object[Enum.GetValues(typeof(VehicleCreation.eCarSpecificParams)).Length];
                    messasgeToUser = "Select car color:";
                    specificVehicleParams[(int)VehicleCreation.eCarSpecificParams.CarColor] =
                        getEnumValueFromUserByType<Enums.eCarColor>(messasgeToUser);
                    messasgeToUser = "Select car number of doors:";
                    specificVehicleParams[(int)VehicleCreation.eCarSpecificParams.NumberOfDoors] =
                        getEnumValueFromUserByType<Enums.eNumberOfDoors>(messasgeToUser);

                    break;
                case VehicleCreation.eVehicleType.Motorcycle:
                    specificVehicleParams =
                        new object[Enum.GetValues(typeof(VehicleCreation.eMotorcycelSpecificParams)).Length];
                    messasgeToUser = "Select motorcycle license type:";
                    specificVehicleParams[(int)VehicleCreation.eMotorcycelSpecificParams.LicenseType] =
                        getEnumValueFromUserByType<Enums.eLicenseType>(messasgeToUser);

                    messasgeToUser = "Select motorcycle engine volume:";
                    specificVehicleParams[(int)VehicleCreation.eMotorcycelSpecificParams.EngineVolume] =
                        getIntUserInput(messasgeToUser);
                    break;
                case VehicleCreation.eVehicleType.Truck:
                    break;
            }
            return specificVehicleParams;
        }

        private int getIntUserInput(string i_MessageToUser)
        {
            int userInput;
            bool inputIsValid = true;
            do
            {
                inputIsValid = int.TryParse(getSimpleStringFromUser(i_MessageToUser), out userInput);
            } while (!inputIsValid);
            return userInput;
        }

        private string getVehicleLicensePlate(string i_MessageToUser)
        {
            string licensePlate = string.Empty;
            bool inputIsValid = true;
            do
            {
                try
                {
                    licensePlate = getSimpleStringFromUser(i_MessageToUser);
                    Helpers.CheckLicensePlateFormat(licensePlate);
                    inputIsValid = true;
                }
                catch (FormatException i_FormatException)
                {
                    writeErrorMessage(i_FormatException.Message);
                    inputIsValid = false;
                }
            } while (!inputIsValid);
            return licensePlate;
        }

        private float getFloatUserInput(string i_MessageToUser)
        {
            float userInput;
            bool inputIsValid = true;
            do
            {
                inputIsValid = float.TryParse(getSimpleStringFromUser(i_MessageToUser), out userInput);
            } while (!inputIsValid);
            return userInput;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"> T is suppose to be Enum</typeparam>
        /// <returns></returns>
        private T getEnumValueFromUserByType<T>(string i_MessageToUser)
        {
            int selectedValue;
            string userInput;
            bool inputIsValid = true;
            Array valuesArray = Enum.GetValues(typeof(T));
            StringBuilder optionsToSelect = new StringBuilder();

            for (int i = 0 ; i < valuesArray.Length ; i++)
            {
                optionsToSelect.Append(string.Format("{0}. {1}{2}", i + 1, valuesArray.GetValue(i), Environment.NewLine));
            }

            do
            {
                userInput = getSimpleStringFromUser(string.Format(@"
{0}
{1}",i_MessageToUser, optionsToSelect));
                inputIsValid = int.TryParse(userInput, out selectedValue)
                           && selectedValue > 0
                           && selectedValue < valuesArray.Length + 1;
                if (!inputIsValid)
                {
                    writeInputIsNotValidErrorMessage();
                }
            } while (!inputIsValid);

            return (T)valuesArray.GetValue(selectedValue - 1);
        }

        private string getSimpleStringFromUser(string i_MessageToUser)
        {
            Console.WriteLine(i_MessageToUser);
            return Console.ReadLine();
        }

        private string getOwnerPhoneNumber(string i_MessageToUser)
        {
            string phoneNumber = string.Empty;
            bool inputIsValid = true;
            do
            {
                try
                {
                    phoneNumber = getSimpleStringFromUser(i_MessageToUser);
                    Helpers.CheckPhoneFormat(phoneNumber);
                    inputIsValid = true;
                }
                catch (FormatException i_FormatException)
                {
                    writeErrorMessage(i_FormatException.Message);
                    inputIsValid = false;
                }
            } while (!inputIsValid);
            return phoneNumber;
        }

        private void writeInputIsNotValidErrorMessage()
        {
            writeErrorMessage("Input is invalid");
        }

        private void writeErrorMessage(string i_ErrorMessage)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(i_ErrorMessage);
            Console.ResetColor();
        }

        private enum eMainAction
        {
            NewVehicle = 1,
            VehiclesList = 2,
            ChangeVehicleState = 3,
            InflateWheels = 4,
            Refuel = 5,
            Recharge = 6,
            ShowDetails = 7,
        }
    }
}
