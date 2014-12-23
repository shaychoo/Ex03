using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic.Exceptions
{
    public class ValueOutOfRangeException : Exception
    {
        private readonly float r_MaxValue;
        private readonly float r_MinValue;
        private readonly string r_Message;

        public ValueOutOfRangeException(float i_MinValue, float i_MaxValue)
            : this(i_MinValue, i_MaxValue, null)
        {

        }
        public ValueOutOfRangeException(float i_MinValue, float i_MaxValue, string i_Message)
            : base(i_Message)
        {
            r_MaxValue = i_MaxValue;
            r_MinValue = i_MinValue;
            r_Message = i_Message;
        }

        public float MaxValue { get { return r_MaxValue; } }

        public float MinValue { get { return r_MinValue; } }

        public override string Message
        {
            get
            {
                string message;
                if (r_Message != null)
                {
                    message = r_Message;
                }
                else
                {
                    message = base.Message;
                }
                return string.Format("{0}, MinValue = {1}, MaxValue = {2}", message, MinValue, MaxValue);
            }
        }
    }
}
