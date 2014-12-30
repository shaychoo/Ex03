using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic;

namespace Ex03.GarageManagementSystem.ConsoleUI
{
    public class ConsoleManager
    {
        private readonly GarageManager r_GarageManager = new GarageManager();

        public ConsoleManager()
        {
            Console.WriteLine("Welcome to Garage Manager!");
            showMainMenu();
        }

        private void showMainMenu()
        {
            string selectedAction = string.Empty;
            do
            {
                try
                {
                    Console.WriteLine(@"
Press 1 to enter new car to the garage
Press 2 to see the vehicles in garage list by states
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
                     
                }

                catch (Exception e)
                {
                    writeErrorMessage(e.Message);
                }
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
                    case eMainAction.VehiclesListByStatus:
                        vehiclesLicensePlatesListByStatus();
                        break;
                    case eMainAction.ChangeVehicleState:
                        changeVehicleState();
                        break;
                    case eMainAction.InflateWheels:
                        inflateWheels();
                        break;
                    case eMainAction.Refuel:
                        refuel();
                        break;
                    case eMainAction.Recharge:
                        recharge();
                        break;
                    case eMainAction.ShowDetails:
                        showDetails();
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

        private void recharge()
        {
            float amountToRecharge = getFloatUserInput("Select amount to recharge:");
            string licensePlate = getInGarageLicensePlate();

            r_GarageManager.RechargeElectricity(licensePlate, amountToRecharge);
            writeSuccessMessage("Vehicle is recharged!");
        }

        private void refuel()
        {
            try
            {
                Enums.eFuelType fuelType = getEnumValueFromUserByType<Enums.eFuelType>("Select fuel type:");
                float amountToRefill = getFloatUserInput("Select amount to refuel:");
                string licensePlate = getInGarageLicensePlate();

                r_GarageManager.RefillFuel(licensePlate, fuelType, amountToRefill);
                writeSuccessMessage("Vehicle is refueled!");
            }
            catch (ArgumentException i_ArgumentException)
            {
                writeExceptionMessage("One or more of the arguments are wrong.",i_ArgumentException);
            }
        }

        private void writeExceptionMessage(string p, ArgumentException i_ArgumentException)
        {
            throw new NotImplementedException();
        }

        private void inflateWheels()
        {
            string licensePlate = getInGarageLicensePlate();

            r_GarageManager.InflateWheelsToMaximum(licensePlate);

            writeSuccessMessage("The wheels are inflated!");
        }

        private void writeSuccessMessage(string i_Message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(string.Format("{0}{1}{0}", Environment.NewLine, i_Message));
            Console.ResetColor();
        }

        private void changeVehicleState()
        {
            string licensePlate = getInGarageLicensePlate();
            Enums.eStatusInGarage newStateInGarage =
                getEnumValueFromUserByType<Enums.eStatusInGarage>("Select new state for vehicle:");

            r_GarageManager.ChangeCarStatuse(licensePlate, newStateInGarage);

            writeSuccessMessage("State has changed!");
        }

        private string getInGarageLicensePlate()
        {
            string licensePlate;
            bool inputIsValid = true;

            do
            {
                licensePlate = getVehicleLicensePlate("Select license plate:");
                inputIsValid = r_GarageManager.IsLicensePlateInGarage(licensePlate);

                if (!inputIsValid)
                {
                    writeInputIsNotValidErrorMessage();
                }
            } while (!inputIsValid);
            return licensePlate;
        }

        private void vehiclesLicensePlatesListByStatus()
        {
            string messageToUser = "Select status in garage to show (you can select more then one divided by comma):";
            Enums.eStatusInGarage neededStatuss = getNeededVehicleStatussStatus(messageToUser);
            List<string> licensePlates = r_GarageManager.GetVehiclesLicensePlatesByStatussInGarage(neededStatuss);

            if (licensePlates.Count == 0)
            {
                writeErrorMessage("There are no license plate to show.");
            }
            else
            {
                StringBuilder licensePlatesBuilder = new StringBuilder();
                foreach (string licensePlate in licensePlates)
                {
                    licensePlatesBuilder.AppendLine(licensePlate);
                }
                writeSuccessMessage(licensePlatesBuilder.ToString());
            }
        }

        private Enums.eStatusInGarage getNeededVehicleStatussStatus(string messageToUser)
        {
            string optionsToSelect;
            Array statussInGarage = getEnumValuesArray<Enums.eStatusInGarage>(out optionsToSelect);
            bool inputIsValid = true;
            List<int> neededStatuss = new List<int>();

            do
            {
                string userInput = getSimpleStringFromUser(string.Format(@"
{0}
{1}
", messageToUser, optionsToSelect));
                string[] allSelections = userInput.Replace(" ", string.Empty).Split(',');
                foreach (string selectedStatus in allSelections)
                {
                    int value;
                    inputIsValid = int.TryParse(selectedStatus, out value)
                                   && value > 0
                                   && value < statussInGarage.Length + 1;
                    if (!inputIsValid)
                    {
                        writeInputIsNotValidErrorMessage();
                        neededStatuss.Clear();
                        break;
                    }
                    neededStatuss.Add(value);
                }
            } while (!inputIsValid);

            Enums.eStatusInGarage neededState = (Enums.eStatusInGarage)statussInGarage.GetValue(neededStatuss[0] - 1);
            for (int i = 1 ; i < neededStatuss.Count ; i++)
            {
                neededState = neededState | (Enums.eStatusInGarage)statussInGarage.GetValue(neededStatuss[i] - 1);
            }

            return neededState;
        }

        private void showDetails()
        {
            List<string> vehiclesDetails = r_GarageManager.GetVehiclesDetails();
            string messageToWrite;

            if (vehiclesDetails.Count == 0)
            {
                messageToWrite = "There are no vehicles in the garage";
            }
            else
            {
                StringBuilder vehiclesDetailsStringBuilder = new StringBuilder();
                string dividingLine = "*************************************************************";
                foreach (string vehicleDetails in vehiclesDetails)
                {
                    vehiclesDetailsStringBuilder.Append(string.Format(@"
{0}
{1}
", dividingLine, vehicleDetails));
                }
                vehiclesDetailsStringBuilder.Append(dividingLine);
                messageToWrite = vehiclesDetailsStringBuilder.ToString();
            }

            Console.WriteLine(messageToWrite);
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
                VehicleCreation.eVehicleType vehicleType =
                    getEnumValueFromUserByType<VehicleCreation.eVehicleType>(messageToUser);

                messageToUser = "Select energy source type:";
                VehicleCreation.eEnergySourceType energySourceType =
                    getEnumValueFromUserByType<VehicleCreation.eEnergySourceType>(messageToUser);

                messageToUser = string.Format("Enter {0} current energy amount:", energySourceType);
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
                    currentEnergyAmount, vehicleModelName, wheelsManufacturerName, licensePlate, currentAirPressure,
                    specificVehicleParams);

                writeSuccessMessage(string.Format("New {0} entered with license plate: {1}!", vehicleType, licensePlate));
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
        /// </summary>
        /// <typeparam name="T"> T is suppose to be Enum</typeparam>
        /// <returns></returns>
        private T getEnumValueFromUserByType<T>(string i_MessageToUser)
        {
            int selectedValue;
            string userInput;
            bool inputIsValid = true;
            string optionsToSelect;
            Array valuesArray = getEnumValuesArray<T>(out optionsToSelect);

            do
            {
                userInput = getSimpleStringFromUser(string.Format(@"
{0}
{1}", i_MessageToUser, optionsToSelect));
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

        private static Array getEnumValuesArray<T>(out string optionsToSelect)
        {
            Array valuesArray = Enum.GetValues(typeof(T));
            StringBuilder optionsToSelectBuilder = new StringBuilder();

            for (int i = 0 ; i < valuesArray.Length ; i++)
            {
                optionsToSelectBuilder.Append(string.Format("{0}. {1}{2}", i + 1, valuesArray.GetValue(i),
                    Environment.NewLine));
            }

            optionsToSelect = optionsToSelectBuilder.ToString();
            return valuesArray;
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
            VehiclesListByStatus = 2,
            ChangeVehicleState = 3,
            InflateWheels = 4,
            Refuel = 5,
            Recharge = 6,
            ShowDetails = 7,
        }
    }
}