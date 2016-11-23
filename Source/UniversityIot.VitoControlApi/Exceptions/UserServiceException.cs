using System;

namespace UniversityIot.VitoControlApi.Exceptions
{

    public class UserServiceException : Exception
    {
        public UserServiceException() : base() { }

        public UserServiceException(string message) : base(message) { }
    }
}