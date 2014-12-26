using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic.Exceptions;

namespace Ex03.GarageLogic
{
    public static class Helpers
    {
        public static void AddingValueInRangeCheck(float i_ValueToAdd,float i_CurrentValue, float i_MinimumValue, float i_MaximumVlaue)
        {
            float maxAllowedAddingValue = i_MaximumVlaue - i_CurrentValue;

            if (i_ValueToAdd < i_MinimumValue)
            {
                throw new ValueOutOfRangeException(i_MinimumValue, maxAllowedAddingValue,
                    "Trying to add less then minimum allowed value");
            }
            if (i_ValueToAdd > maxAllowedAddingValue)
            {
                throw new ValueOutOfRangeException(i_ValueToAdd, maxAllowedAddingValue,
                    "Trying to add more then maximum allowed value");
            }
        }
    }
}
