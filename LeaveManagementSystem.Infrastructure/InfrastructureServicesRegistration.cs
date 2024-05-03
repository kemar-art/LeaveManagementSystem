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
        public static IServiceCollection ConfigurationInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            return services;
        }
    }
}
