using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using DependencyInjection;
using Extension;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Mvc;
using Web.ViewFactory;

namespace Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            AutoMapperConfig.RegisterMapping();


            var container = IoC.GetConfiguredContainer();
            RegisterTypes(container);
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }

        private void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<IViewFactory, DefaultViewFactory>();
            container.RegisterImplementationsClosingInterface(typeof(IViewBuilder<>));
            container.RegisterImplementationsClosingInterface(typeof(IViewBuilder<,>));
        }
    }
}
