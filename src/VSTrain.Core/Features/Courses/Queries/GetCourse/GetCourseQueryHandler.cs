using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using VSTrain.Core.Contracts;

namespace VSTrain.Core.Features
{
    public class GetCourseQueryHandler : IRequestHandler<GetCourseQuery, CourseVM>
    {
        private readonly IMapper mapper;
        private readonly IAsyncRepository<CourseVM> repo;

        public GetCourseQueryHandler(IMapper mapper, IAsyncRepository<CourseVM> repo)
        {
            this.mapper = mapper;
            this.repo = repo;
        }
        public async Task<CourseVM> Handle(GetCourseQuery request, CancellationToken cancellationToken)
        {
            var course = await repo.GetByIdAsync(request.Id);
           return mapper.Map<CourseVM>(course);
        }
    }
}