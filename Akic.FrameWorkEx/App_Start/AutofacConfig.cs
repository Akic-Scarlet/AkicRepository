using Autofac;
using Autofac.Integration.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace Akic.FrameWorkEx
{
    public class AutofacConfig
    {
        public static void Register()
        {
            ContainerBuilder builder = new ContainerBuilder();
            Assembly controllerAss = Assembly.Load("Akic.FrameWorkEx");
            builder.RegisterControllers(controllerAss);
            //
            Assembly repositoryAss = Assembly.Load("Akic.Repository");
            Type[] rtypes = repositoryAss.GetTypes();
            builder.RegisterTypes(rtypes)
                .AsImplementedInterfaces();
 

            //
            Assembly servicesAss = Assembly.Load("Akic.Service");
            Type[] stypes = servicesAss.GetTypes();
            builder.RegisterTypes(stypes)
                .AsImplementedInterfaces();

 

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}