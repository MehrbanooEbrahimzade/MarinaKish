using Application.Services.classes;
using Application.Services.interfaces;
using Castle.MicroKernel.Lifestyle;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.Windsor.MsDependencyInjection;
using Infrastructure.Repository.Classes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;


namespace CastleWindsor
{
    public static class Installer 
    {
        public static IWindsorContainer Container { get; private set; }
        public static void Install(IServiceCollection services)
        {
            Container = new WindsorContainer();
            Container.Register(Classes.FromAssembly(Assembly.GetEntryAssembly()).BasedOn<ControllerBase>().LifestyleCustom<MsScopedLifestyleManager>());


            RegisterServices();
            RegisterRepositories();
        }


        private static void RegisterServices()
        {
            Container.Register(Classes.FromAssemblyContaining<UserService>()
                .IncludeNonPublicTypes()
                .Pick()
                .WithServiceAllInterfaces()
                .LifestyleCustom<MsScopedLifestyleManager>());
        }
        private static void RegisterRepositories()
        {
            Container.Register(Classes.FromAssemblyContaining<TicketRepository>()
                .IncludeNonPublicTypes()
                .Pick()
                .WithServiceAllInterfaces()
                .LifestyleCustom<MsScopedLifestyleManager>());
        }

    }
}
