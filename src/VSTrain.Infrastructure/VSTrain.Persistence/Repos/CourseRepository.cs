using System.Linq;
using System.Threading.Tasks;
using VSTrain.Core.Contracts;
using VSTrain.Core.Entities;

namespace VSTrain.Persistence.Repos
{
    public class CourseRepository : BaseRepository<Course>, ICourseRepository
    {
        private readonly VSTrainDbContext context;

        public CourseRepository(VSTrainDbContext context) : base(context)
        {
            this.context = context;
        }

        public Task<bool> CourseNameIsUnique(string name)
        {
            bool result =  context.Courses.Any(c =>c.Name==name);
            return Task.FromResult(result);
        }
    }   

}