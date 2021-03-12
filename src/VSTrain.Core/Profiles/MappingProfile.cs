using AutoMapper;
using VSTrain.Core.Entities;
using VSTrain.Core.Features;
using VSTrain.Core.Features.Courses.Commands.CreateCourse;

namespace  VSTrain.Core.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Course, CourseVM>().ReverseMap();
            CreateMap<Course, CreateCourseCommand>();
        }

    }
}