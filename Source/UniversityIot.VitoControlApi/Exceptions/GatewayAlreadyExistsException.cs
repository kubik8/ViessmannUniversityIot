using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityIot.VitoControlApi.Exceptions
{
    [Serializable]
    public class GatewayAlreadyExistsException : Exception
    {
        public GatewayAlreadyExistsException() { }
        public GatewayAlreadyExistsException(string message) : base(message) { }
        public GatewayAlreadyExistsException(string message, Exception inner) : base(message, inner) { }
        protected GatewayAlreadyExistsException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}