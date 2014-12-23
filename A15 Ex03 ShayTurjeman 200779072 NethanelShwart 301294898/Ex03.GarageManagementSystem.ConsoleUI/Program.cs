using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageManagementSystem.ConsoleUI
{
    class Program
    {
        public static void Main()
        {
            try
            {
                throw new Exception(null);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }
    }
}
