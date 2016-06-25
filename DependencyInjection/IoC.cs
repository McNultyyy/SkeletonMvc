using System;
using DAL;
using DAL.Repository;
using DependencyInjection.ViewFactory;
using Extension;
using Microsoft.Practices.Unity;

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
            container.RegisterType(typeof(IRepository<>), typeof(GenericRepository<>));

            container.RegisterType<IViewFactory, DefaultViewFactory>();
            container.RegisterImplementationsClosingInterface(typeof(IViewBuilder<>));
            container.RegisterImplementationsClosingInterface(typeof(IViewBuilder<,>));
        }

    }
}