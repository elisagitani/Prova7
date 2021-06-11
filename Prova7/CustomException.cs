using System;
using System.Collections.Generic;
using System.Text;

namespace Prova7
{
    class CustomException : Exception
    {
        public CustomException()
        {

        }
        public CustomException(string message)
            :base(message)
        {

        }

        public CustomException(string message, Exception innerException)
            :base(message,innerException)
        {

        }
    }
}
