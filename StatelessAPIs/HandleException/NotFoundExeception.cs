using System;

namespace StatelessAPIs.HandleException
{
    public class NotFoundExeception : Exception
    {
        public NotFoundExeception()
        {
        }

        public NotFoundExeception(string message) : base(message)
        {
        }
    }
}