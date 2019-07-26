using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Reflection;

namespace GraphQLDemo.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void RegisterTypesInAssembly(this IServiceCollection services, Func<TypeInfo, bool> predicate, Assembly[] assemblies, ServiceLifetime lifetime)
        {
            var typesFromAssemblies = assemblies.SelectMany(a => a.DefinedTypes.Where(predicate)).Where(t => !t.IsInterface);
            foreach (var type in typesFromAssemblies)
            {
                var interfaces = type.GetInterfaces();
                foreach (var @interface in interfaces)
                {
                    services.Add(new ServiceDescriptor(@interface, type, lifetime));
                }
            }
        }
    }
}
