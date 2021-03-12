using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using VSTrain.Core.Contracts;
using VSTrain.Core.Entities;

namespace VSTrain.Core.Features.Courses.Commands.UpdateCourse
{
    public class UpdateCourseCommandHandler : IRequestHandler<UpdateCourseCommand>
    {
        private readonly IMapper mapper;
        private readonly IAsyncRepository<Course> repo;

        public UpdateCourseCommandHandler(IMapper mapper, IAsyncRepository<Course> repo)
        {
            this.mapper = mapper;
            this.repo = repo;
        }
        public async Task<Unit> Handle(UpdateCourseCommand request, CancellationToken cancellationToken)
        {
            var course = await repo.GetByIdAsync(request.Id);
            mapper.Map(request,course);
            //
            return Unit.Value;
        }
    }
}