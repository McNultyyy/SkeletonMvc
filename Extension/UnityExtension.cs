using System;
using System.Linq;
using System.Reflection;
using Microsoft.Practices.Unity;

namespace Extension
{
    public static class UnityExtension
    {
        public static void RegisterImplementationsClosingInterface(
            this IUnityContainer container,
            Type genericInterface,
            Assembly assembly = null)
        {
            var assemblyTypes = assembly?.GetTypes() ?? AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetLoadableTypes());

            var types = assemblyTypes.Where(x => !x.IsAbstract && x.IsClass);

            foreach (var type in types)
            {
                // has the interface or not?
                var iface = type.GetInterfaces().FirstOrDefault(i =>
                    i.IsGenericType &&
                    i.GetGenericTypeDefinition() == genericInterface
                );

                if (iface != null)
                    container.RegisterType(iface, type);
            }
        }
    }
}