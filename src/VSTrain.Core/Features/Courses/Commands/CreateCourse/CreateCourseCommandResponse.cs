namespace VSTrain.Core.Features.Courses.Commands.CreateCourse
{
    public class CreateCourseCommandResponse : BaseResponse
    {
        public CreateCourseCommandResponse() : base()
        {
            
        }
        public CourseVM Course { get; set; }

    }
}