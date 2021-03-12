using System;
using MediatR;

namespace VSTrain.Core.Features.Courses.Commands.UpdateCourse
{
    public class UpdateCourseCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTimeOffset date {get; set;}
    }
}