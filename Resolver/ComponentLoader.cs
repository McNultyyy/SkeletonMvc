﻿using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.Linq;
using System.Reflection;
using System.Text;
using Microsoft.Practices.Unity;

namespace Resolver
{
    public static class ComponentLoader
    {
        public static void LoadContainer(IUnityContainer container, string path, string pattern)
        {
            var dirCat = new DirectoryCatalog(path, pattern);
            var importDef = BuildImportDefinition();
            try
            {
                using (var aggregateCatalog = new AggregateCatalog())
                {
                    aggregateCatalog.Catalogs.Add(dirCat);

                    using (var compositionContainer = new CompositionContainer(aggregateCatalog))
                    {
                        IEnumerable<Export> exports = compositionContainer.GetExports(importDef);

                        IEnumerable<IResolverComponent> modules =
                            exports.Select(export => export.Value as IResolverComponent).Where(m => m != null);

                        var registerComponent = new RegisterComponent(container);
                        foreach (IResolverComponent module in modules)
                        {
                            module.SetUp(registerComponent);
                        }
                    }
                }
            }
            catch (ReflectionTypeLoadException typeLoadException)
            {
                var builder = new StringBuilder();
                foreach (var loaderException in typeLoadException.LoaderExceptions)
                {
                    builder.AppendFormat("{0}\n", loaderException.Message);
                }

                throw new TypeLoadException(builder.ToString(), typeLoadException);
            }
        }

        private static ImportDefinition BuildImportDefinition()
        {
            return new ImportDefinition(def => true, typeof(IResolverComponent).FullName, ImportCardinality.ZeroOrMore, false, false);
        }
    }

    internal class RegisterComponent : IRegisterComponent
    {
        private readonly IUnityContainer _container;

        public RegisterComponent(IUnityContainer container)
        {
            _container = container;
        }

        public void RegisterType(Type from, Type to, bool withInterception = false)
        {
            if (withInterception)
            {
                //register with interception
            }
            else _container.RegisterType(from, to);
        }

        public void RegisterType<TFrom, TTo>(bool withInterception = false) where TTo : TFrom
        {
            if (withInterception)
            {
                //register with interception
            }
            else _container.RegisterType<TFrom, TTo>();
        }

        public void RegisterTypeWithControlledLifeTime(Type @from, Type to, bool withInterception = false)
        {
            _container.RegisterType(from, to, new ContainerControlledLifetimeManager());
        }

        public void RegisterTypeWithControlledLifeTime<TFrom, TTo>(bool withInterception = false) where TTo : TFrom
        {
            _container.RegisterType<TFrom, TTo>(new ContainerControlledLifetimeManager());
        }
    }

}