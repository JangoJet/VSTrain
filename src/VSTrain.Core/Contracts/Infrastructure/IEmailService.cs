using System.Threading.Tasks;
using VSTrain.Core.Entities;

namespace VSTrain.Core.Contracts.Infrastructure
{
    public interface IEmailService
    {
        Task<bool> SendEmail(Email msg);
    }
}