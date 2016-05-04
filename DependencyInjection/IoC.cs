using System;
using System.ComponentModel;
using DependencyInjection.Extensions;
using DependencyInjection.ViewFactory;
using Microsoft.Practices.Unity;
using Repository;

namespace DependencyInjection
{

    public static class IoC
    {
        private static readonly Lazy<IUnityContainer> Container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();

            RegisterServices(container);

            return container;
        });

        /// <summary>
        /// Gets the configured Unity container.
        /// </summary>
        public static IUnityContainer GetConfiguredContainer()
        {
            return Container.Value;
        }

        private static void RegisterServices(IUnityContainer container)
        {
            container.RegisterType<IContext, SkeletonMvcContext>();
            container.RegisterType(typeof(IRepository<>), typeof(Repository<>));

            container.RegisterImplementationsClosingInterface(typeof(IViewBuilder<>));
            container.RegisterImplementationsClosingInterface(typeof(IViewBuilder<,>));
        }

    }
}