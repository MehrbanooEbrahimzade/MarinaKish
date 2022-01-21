using Application.Services.classes;
using Application.Services.interfaces;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
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
            Container.Register(Classes.FromAssembly(Assembly.GetEntryAssembly()).BasedOn<ControllerBase>().LifestyleScoped());

            RegisterServices();
            RegisterRepositories();
        }


        private static void RegisterServices()
        {
            Container.Register(Classes.FromAssemblyContaining<UserService>()
                .IncludeNonPublicTypes()
                .Pick()
                .WithServiceAllInterfaces()
                .LifestyleScoped());
        }
        private static void RegisterRepositories()
        {
            Container.Register(Classes.FromAssemblyContaining<TicketRepository>()
                .IncludeNonPublicTypes()
                .Pick()
                .WithServiceAllInterfaces()
                .LifestyleScoped());
        }
       
    }
}
