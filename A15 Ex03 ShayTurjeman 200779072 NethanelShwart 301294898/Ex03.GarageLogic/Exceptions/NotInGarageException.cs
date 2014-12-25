using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic.Exceptions
{
    public class NotInGarageException : Exception
    {
        public NotInGarageException(string i_Message) : base(i_Message)
        {
        }
    }
}
