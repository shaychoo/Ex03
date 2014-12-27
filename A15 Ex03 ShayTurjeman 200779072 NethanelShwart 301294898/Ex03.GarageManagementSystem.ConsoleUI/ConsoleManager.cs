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
                string ownerName = getOwnerName();
                string phoneNumber = ""; //getOwnerPhoneNumber();
                VehicleCreation.eVehicleType vehicleType = getVehicleType();
                VehicleCreation.eEnergySourceType energySourceType = getEneragySourceType();
                float currentEnergyAmount = getCurrentEnergyAmount();
                string modelName = "KIA";
                string licensePlate = "1h-458-67";
                object[] specificCarParams = new object[2];
                specificCarParams[(int)VehicleCreation.eCarSpecificParams.CarColor] = Enums.eCarColor.Red;
                specificCarParams[(int)VehicleCreation.eCarSpecificParams.NumberOfDoors] = Enums.eNumberOfDoors.Four;

                r_GarageManager.EnterVehicleToGarage(ownerName, phoneNumber, vehicleType, energySourceType,
                    currentEnergyAmount, modelName, licensePlate,
                    specificCarParams);
            }
            catch (Exception iException)
            {
                writeErrorMessage(iException.Message);
            }
        }

        private float getCurrentEnergyAmount()
        {
            throw new NotImplementedException();
        }

        private VehicleCreation.eEnergySourceType getEneragySourceType()
        {
            int selectedEneragySourceType;
            bool inputIsValid = true;

            do
            {
                Console.WriteLine(@"
Select energy source type:
1. Fuel
2. Electricity");
                inputIsValid = int.TryParse(Console.ReadLine(), out selectedEneragySourceType)
                               && selectedEneragySourceType > 0
                               && selectedEneragySourceType < 2;
                if (!inputIsValid)
                {
                    writeInputIsNotValidErrorMessage();
                }
            } while (!inputIsValid);

            return (VehicleCreation.eEnergySourceType)selectedEneragySourceType;
        }

        private VehicleCreation.eVehicleType getVehicleType()
        {
            int selectedVehicleType;
            bool inputIsValid = true;

            do
            {
                Console.WriteLine(@"
Select vehicle type:
1. Car
2. Motorcycle
3. Truck");
                inputIsValid = int.TryParse(Console.ReadLine(), out selectedVehicleType)
                               && selectedVehicleType > 0
                               && selectedVehicleType < 3;
                if (!inputIsValid)
                {
                    writeInputIsNotValidErrorMessage();
                }
            } while (!inputIsValid);

            return (VehicleCreation.eVehicleType)selectedVehicleType;
        }



        private string getOwnerName()
        {
            Console.WriteLine("Enter vehicle owner name:");
            return Console.ReadLine();
        }

        private string getOwnerPhoneNumber()
        {
            string phoneNumber = string.Empty;
            bool inputIsValid = true;
            do
            {
                Console.WriteLine("Enter phone number (In format XXX-XXXXXXX)");
                try
                {
                    phoneNumber = Console.ReadLine();
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
