using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using VSTrain.Core.Contracts;
using VSTrain.Core.Entities;

namespace VSTrain.Core.Features
{
    public class GetCoursesListQueryHandler : IRequestHandler<GetCoursesListQuery, List<CourseVM>>
    {
        private readonly IMapper mapper;
        private readonly IAsyncRepository<Course> repo;

        public GetCoursesListQueryHandler(IMapper mapper, IAsyncRepository<Course> repo)
        {
            this.mapper = mapper;
            this.repo = repo;
        }
        public async Task<List<CourseVM>> Handle(GetCoursesListQuery request, CancellationToken cancellationToken)
        {
            var courses = await repo.GetAllAsync();
            return mapper.Map<List<CourseVM>>(courses);
        }
    }
}