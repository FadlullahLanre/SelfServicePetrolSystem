using Autofac.Integration.WebApi;
using Autofac;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using SelfServicePump.Data;
using SelfServicePump.Controllers;
using SelfServicePump.Services.Services;
using SelfServicePump.Services.Interfaces;
using AutoMapper.Configuration;
using System.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNet.Identity.EntityFramework;
using SelfServicePump.Data.Autentication;
using SelfServicePump.Services.Extensions;

namespace SelfServicePump.App_Start
{
    public class AutofacConfig
    {


        public AutofacConfig(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public static void Register()
        {
            var bldr = new ContainerBuilder();
            var config = GlobalConfiguration.Configuration;
            bldr.RegisterApiControllers(Assembly.GetExecutingAssembly());
            bldr.RegisterType<AuthenticateController>().InstancePerRequest();
            bldr.RegisterType<UserController>().InstancePerRequest();
            RegisterServices(bldr);
            bldr.RegisterWebApiFilterProvider(config);
            bldr.RegisterWebApiModelBinderProvider();
            var container = bldr.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        public void ConfigureServices(IServiceCollection services)
        {
          
            

        }



        private static void RegisterServices(ContainerBuilder bldr)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutomapperProfile());
            });

           
            bldr.RegisterInstance(config.CreateMapper())
            .As<IMapper>().SingleInstance();

            bldr.RegisterType<PumpDbContext>()
              .InstancePerRequest();

            bldr.RegisterType<UserService>()
            .As<IUserService>()
            .InstancePerRequest();



        }

    }
}
