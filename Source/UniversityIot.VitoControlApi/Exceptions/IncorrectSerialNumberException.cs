using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityIot.VitoControlApi.Exceptions
{
    [Serializable]
    public class IncorrectSerialNumberException : Exception
    {
        public IncorrectSerialNumberException() { }
        public IncorrectSerialNumberException(string message) : base(message) { }
        public IncorrectSerialNumberException(string message, Exception inner) : base(message, inner) { }
        protected IncorrectSerialNumberException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}