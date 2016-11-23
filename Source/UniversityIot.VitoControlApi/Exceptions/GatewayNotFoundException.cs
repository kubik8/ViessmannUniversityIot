using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityIot.VitoControlApi.Exceptions
{

    [Serializable]
    public class GatewayNotFoundException : Exception
    {
        public GatewayNotFoundException() { }
        public GatewayNotFoundException(string message) : base(message) { }
        public GatewayNotFoundException(string message, Exception inner) : base(message, inner) { }
        protected GatewayNotFoundException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}