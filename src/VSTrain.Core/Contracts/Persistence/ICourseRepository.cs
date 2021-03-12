using System.Threading.Tasks;
using VSTrain.Core.Entities;

namespace VSTrain.Core.Contracts
{
    public interface ICourseRepository : IAsyncRepository<Course>
    {
        Task<bool> CourseNameIsUnique(string name);
    }
}