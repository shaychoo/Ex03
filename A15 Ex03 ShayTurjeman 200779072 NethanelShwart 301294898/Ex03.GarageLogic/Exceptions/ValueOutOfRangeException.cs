﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic.Exceptions
{
    public class ValueOutOfRangeException : Exception
    {
        private readonly float r_MaxValue;
        private readonly float r_MinValue;

        public ValueOutOfRangeException(float i_MinValue, float i_MaxValue, string i_Message)
            : base(i_Message)
        {
            r_MaxValue = i_MaxValue;
            r_MinValue = i_MinValue;
        }

        public float MaxValue { get { return r_MaxValue; } }

        public float MinValue { get { return r_MinValue; } }
    }
}
