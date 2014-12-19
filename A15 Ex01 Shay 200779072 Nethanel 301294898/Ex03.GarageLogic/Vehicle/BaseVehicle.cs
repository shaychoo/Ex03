using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic.Entities;

namespace Ex03.GarageLogic.Vehicle
{
    public abstract class BaseVehicle
    {
        public string ModelName { get; set; }

        public string LicencePlate { get; set; }

        public float RemainingEnergyPercentage { get; set; }

        public List<Wheel> Wheels { get; set; }
    }
}
