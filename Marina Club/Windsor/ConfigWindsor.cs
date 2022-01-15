
using Application.Services.classes;
using Application.Services.interfaces;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Marina_Club.Controllers;
using System;

namespace Marina_Club.Windsor
{
    public  class ConfigWindsor 
    {
        //public  void Install(IWindsorContainer container, IConfigurationStore store)
        //{
        //    container.Register(Classes.FromThisAssembly().ImplementedBy<IdentityService>().LifestyleScoped());
        //}
    }
}
