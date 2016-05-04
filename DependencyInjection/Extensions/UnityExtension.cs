using System;
using System.Linq;
using System.Reflection;
using Microsoft.Practices.Unity;

namespace DependencyInjection.Extensions
{
    public static class UnityExtension
    {
        public static void RegisterImplementationsClosingInterface(this IUnityContainer container, Type genericInterface)
        {
            foreach (var type in Assembly.GetExecutingAssembly().GetExportedTypes())
            {
                //   concrete class or not?
                if (!type.IsAbstract && type.IsClass)
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
}