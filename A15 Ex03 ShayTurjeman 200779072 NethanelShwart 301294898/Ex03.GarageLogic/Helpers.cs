using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic.BaseEntities;
using Ex03.GarageLogic.Exceptions;

namespace Ex03.GarageLogic
{
    public static class Helpers
    {
        public static void IsPossibleAddingValueInRangeCheck(float i_ValueToAdd, float i_CurrentValue,
            float i_MinimumValue, float i_MaximumVlaue, string i_ValueName)
        {
            float maxAllowedAddingValue = i_MaximumVlaue - i_CurrentValue;

            if (i_ValueToAdd < i_MinimumValue)
            {
                throw new ValueOutOfRangeException(i_MinimumValue, maxAllowedAddingValue,
                    string.Format("{0} value is less then minimum allowed value", i_ValueName));
            }
            if (Math.Round(i_ValueToAdd,1) > Math.Round(maxAllowedAddingValue,1))
            {
                throw new ValueOutOfRangeException(i_ValueToAdd, maxAllowedAddingValue,
                    string.Format("{0} value is more then maximum allowed value", i_ValueName));
            }
        }

        /// <summary>
        /// Throws ArgumentException when given object is not in needed type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="i_Argument"></param>
        /// <exception cref="ArgumentException"></exception>
        public static T StrongArgumentNeededTypeCheckAndCast<T>(object i_Argument)
        {
            if (!(i_Argument is T))
            {
                string errorMessage = string.Format("Given argument is from type {0} and not in needed type {1}.",
                    i_Argument.GetType().Name, typeof(T).Name);

                throw new ArgumentException(errorMessage);
            }

            return (T)i_Argument;
        }

        /// <summary>
        /// expected formats (after spaces removing):
        /// XXX-XXXXXXX (3 digits - 7 digits) = 11 chars
        /// </summary>
        /// <param name="i_OwnerPhone"></param>
        public static void CheckPhoneFormat(string i_OwnerPhone)
        {
            int expectedLength = 11;
            string argumentName = "Phone number";
            checkStringIsInWantedLength(ref i_OwnerPhone, expectedLength, argumentName);

            bool isInCorrectFormat = true;

            for (int i = 0; i < i_OwnerPhone.Length; i++)
            {
                if (i != 3)
                {
                    isInCorrectFormat = char.IsDigit(i_OwnerPhone[i]);
                }
                else
                {
                    isInCorrectFormat = i_OwnerPhone[i] == '-';
                }
                if (!isInCorrectFormat)
                {
                    break;
                }
            }

            if (!isInCorrectFormat)
            {
                throw new FormatException("The phone number is not in the correct format");
            }
        }

        /// <summary>
        /// expected formats (after spaces removing):
        /// XX-XXX-XX (2 digits/letters - 3 digits/letters - 2 digits/letters) = 9 chars
        /// </summary>
        /// <param name="i_LicensePlate"></param>
        public static void CheckLicensePlateFormat(string i_LicensePlate)
        {
            int expectedLength = 9;
            string argumentName = "License plate";
            checkStringIsInWantedLength(ref i_LicensePlate, expectedLength, argumentName);

            bool isInCorrectFormat = true;

            for (int i = 0; i < i_LicensePlate.Length; i++)
            {
                if (i != 2 && i != 6)
                {
                    isInCorrectFormat = char.IsDigit(i_LicensePlate[i]) || char.IsLetter(i_LicensePlate[i]);
                }
                else
                {
                    isInCorrectFormat = i_LicensePlate[i] == '-';
                }
                if (!isInCorrectFormat)
                {
                    break;
                }
            }

            if (!isInCorrectFormat)
            {
                throw new FormatException("The license plate is not in the correct format");
            }
        }

        private static void checkStringIsInWantedLength(ref string i_String, int i_Length, string i_StringName)
        {
            i_String = i_String.Replace(" ", string.Empty);

            if (i_String.Length != i_Length)
            {
                throw new FormatException(string.Format("The {0} is in the wrong length", i_StringName));
            }
        }
    }
}