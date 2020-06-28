using System;

namespace StatelessAPIs.HandleException
{
    public class BadRequestException : Exception
    {
        
        public BadRequestException(string message) : base(message)
        {
        }
    }
}