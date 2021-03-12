using System;

namespace VSTrain.Core.Exceptions
{
    public class NullRequestException : ApplicationException
    {
        public NullRequestException(string name, object key) : base($"{name} ({key} was not found")
        {
            
        }
    }
}