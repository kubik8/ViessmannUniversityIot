using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityIot.VitoControlApi.Exceptions
{

    [Serializable]
    public class GatewayAlreadyRegisteredException : Exception
    {
        public GatewayAlreadyRegisteredException() { }
        public GatewayAlreadyRegisteredException(string message) : base(message) { }
        public GatewayAlreadyRegisteredException(string message, Exception inner) : base(message, inner) { }
        protected GatewayAlreadyRegisteredException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}