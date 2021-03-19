using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VSTrain.Core.Contracts.Infrastructure;
using VSTrain.Core.Entities;

namespace VSTrain.Infrastructure.Extensions
{
    public static class InfrastructureRegistration
    {
        public static IServiceCollection  AddInfrastructureRegistration(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<EmailSettings>(configuration.GetSection("EmailSettiings"));
        services.AddTransient<IEmailService, EmailService>();
        return services;
        
    }
    }
}