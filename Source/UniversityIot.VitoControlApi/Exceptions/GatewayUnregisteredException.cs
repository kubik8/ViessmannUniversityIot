using System;
using System.Runtime.Serialization;

namespace UniversityIot.VitoControlApi.Exceptions
{
    [Serializable]
    public class GatewayUnregisteredException : Exception
    {
        public GatewayUnregisteredException() { }
        public GatewayUnregisteredException(string message) : base(message) { }
        public GatewayUnregisteredException(string message, Exception inner) : base(message, inner) { }
        protected GatewayUnregisteredException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}