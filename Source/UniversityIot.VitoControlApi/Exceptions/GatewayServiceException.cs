using System;
using System.Runtime.Serialization;

namespace UniversityIot.VitoControlApi.Exceptions
{
    [Serializable]
    public class GatewayServiceException : Exception
    {
        public GatewayServiceException() : base() { }

        public GatewayServiceException(string message) : base(message) { }
    }
}