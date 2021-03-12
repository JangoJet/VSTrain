using MediatR;

namespace VSTrain.Core.Features
{
    public class GetCourseQuery : IRequest<CourseVM>
    {
        public int Id { get; set; }
    }
}