using System;
using DependencyInjection;
using Microsoft.Practices.Unity;

namespace Web.ViewFactory
{
    public class DefaultViewFactory : IViewFactory
    {
        public TView CreateView<TView>()
        {
            var builder = IoC.GetConfiguredContainer().Resolve<IViewBuilder<TView>>();

            if (builder != null)
                return builder.Build();
            return Activator.CreateInstance<TView>();
        }

        public TView CreateView<TInput, TView>(TInput input)
        {
            var builder = IoC.GetConfiguredContainer().Resolve<IViewBuilder<TInput, TView>>();

            if (builder != null)
                return builder.Build(input);
            return (TView)Activator.CreateInstance(typeof(TView), input);
        }
    }
}