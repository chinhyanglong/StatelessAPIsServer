using System;

namespace StatelessAPIs.HandleException
{
    public class IllegalArgumentException : Exception
    {
        public IllegalArgumentException(string message) : base(message)
        {
        }
    }
}