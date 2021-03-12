using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using VSTrain.Core.Contracts;
using VSTrain.Core.Entities;

namespace VSTrain.Core.Features.Courses.Commands.DeleteCourse
{
    public class DeleteCourseCommandHandler : IRequestHandler<DeleteCourseCommand>
    {
        private readonly IMapper mapper;
        private readonly IAsyncRepository<Course> repo;

        public DeleteCourseCommandHandler(IMapper mapper, IAsyncRepository<Course> repo)
        {
            this.mapper = mapper;
            this.repo = repo;
        }
        public async Task<Unit> Handle(DeleteCourseCommand request, CancellationToken cancellationToken)
        {
            var course = await repo.GetByIdAsync(request.Id);
            await repo.DeleteAsync(course);
            return Unit.Value;
        }
    }
}