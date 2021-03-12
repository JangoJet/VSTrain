using System.Collections.Generic;

namespace VSTrain.Core.Features.Courses.Commands.CreateCourse
{
    public class BaseResponse
    {
        public BaseResponse()
        {
            Success = true;
            ValidationErrors = new List<string>();
        }

        public BaseResponse(string message = null)
        {
            this.Message = message;
            Success = true;
            ValidationErrors = new List<string>();         
        }

        public BaseResponse(string message, bool success)
        {
            Message = message;
            Success = success;
            ValidationErrors = new List<string>();
        }

        public bool Success { get; set; }
        public string Message { get; }
        public List<string> ValidationErrors { get; set; }

    }
}