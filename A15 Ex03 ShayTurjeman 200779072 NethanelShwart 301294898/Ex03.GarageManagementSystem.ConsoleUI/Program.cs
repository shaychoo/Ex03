using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic;
using Ex03.GarageLogic.Exceptions;

namespace Ex03.GarageManagementSystem.ConsoleUI
{
    class Program
    {
        public static void Main()
        {
            try
            {
                Enums.eStatusInGarage eSsdstatusInGarage =  Enums.eStatusInGarage.InRepair | Enums.eStatusInGarage.Paid;

                if ((eSsdstatusInGarage & Enums.eStatusInGarage.InRepair) == Enums.eStatusInGarage.InRepair)
                {
                    
                }
               
                foo();
            }
            catch (ValueOutOfRangeException e)
            {

                Console.WriteLine("exception was throne, exception message : /n"+e.MaxValue);
            }
            Console.ReadLine();
        }

        private static void foo()
        {
            throw new NotImplementedException();
        }
    }
}
