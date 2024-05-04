using LeaveManagementSystem.Application.Contracts.EmailService;
using LeaveManagementSystem.Application.Contracts.ILogging;
using LeaveManagementSystem.Application.Models.Email;
using LeaveManagementSystem.Infrastructure.EmailServices;
using LeaveManagementSystem.Infrastructure.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveManagementSystem.Infrastructure
{
    public static class InfrastructureServicesRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));
            services.AddTransient<IEmailService, EmailService>();
            services.AddScoped(typeof(IAppLogger<>), typeof(AppLogger<>));
            return services;
        }
    }
}
