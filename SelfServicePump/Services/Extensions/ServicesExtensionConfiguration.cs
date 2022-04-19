using Microsoft.Extensions.DependencyInjection;
using SelfServicePump.Services.Interfaces;
using SelfServicePump.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SelfServicePump.Services.Extensions
{
    public static class ServicesExtensionConfiguration
    {
        public static void AddServicesExtensions(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
           
           
        }
    }
}