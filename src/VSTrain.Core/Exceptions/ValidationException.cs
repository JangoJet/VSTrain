using System;
using System.Collections.Generic;
using FluentValidation.Results;

namespace VSTrain.Core.Exceptions
{
    public class ValidationException : ApplicationException
    {
        public List<string> ValidationErrors { get; set; }
       public ValidationException(ValidationResult results)
       {
           ValidationErrors = new List<string>();
           foreach(var error in results.Errors)
           {
               ValidationErrors.Add(error.ErrorMessage);
           }
       }         
    }
}