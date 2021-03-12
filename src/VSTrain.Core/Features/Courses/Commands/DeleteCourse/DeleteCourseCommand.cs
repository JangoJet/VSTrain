using MediatR;

namespace VSTrain.Core.Features.Courses.Commands.DeleteCourse
{
    public class DeleteCourseCommand : IRequest
    {
        public int Id { get; set; }
    }
}