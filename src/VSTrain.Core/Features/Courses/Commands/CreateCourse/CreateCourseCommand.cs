using System;
using MediatR;

namespace VSTrain.Core.Features.Courses.Commands.CreateCourse
{
    public class CreateCourseCommand : IRequest<CreateCourseCommandResponse>
    {
        public string Name { get; set; }
        public DateTimeOffset date {get; set;}

        public override string ToString()
        {
            return $"Course Name: {Name}; Date: {date}";
        }
    }
}