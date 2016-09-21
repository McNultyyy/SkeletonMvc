using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CSharp;

namespace Common
{
    public static class TypeExtension
    {
        public static Type GetNullableType(this Type type)
        {
            type = Nullable.GetUnderlyingType(type);
            return type.IsValueType ?
                typeof(Nullable<>).MakeGenericType(type) :
                type;
        }

        public static string FormattedName(this Type type, bool longName = false)
        {
            var underlyingType = Nullable.GetUnderlyingType(type);

            string typeName;
            using (var provider = new CSharpCodeProvider())
            {
                var typeRef = new CodeTypeReference(underlyingType ?? type);
                typeName = provider.GetTypeOutput(typeRef);
            }

            if (underlyingType != null)
                return longName
                    ? $"Nullable<{typeName}>"
                    : $"{typeName}?";
            return typeName;
        }


        public static object DefaultValue(this Type type)
        {
            if (type.IsValueType)
                return Activator.CreateInstance(type);
            return null;
        }

        public static TSource DefaultValue<TSource>(this Type type) where TSource : class
        {
            return DefaultValue(type) as TSource;
        }

        public static object NewObject(this Type type)
        {
            if (type == typeof(string)) return string.Empty;

            var emptyConstructor = type
                .GetConstructor(new Type[] { });
            var result = emptyConstructor?.Invoke(new object[] { });

            return result;
        }

        public static Type GetEnumerableType(this Type type)
        {
            var result = type.GetInterfaces()
                .Where(t =>
                    t.IsGenericType &&
                    t.GetGenericTypeDefinition() == typeof(IEnumerable<>)
                )
                .Select(t => t.GetGenericArguments()[0])
                .FirstOrDefault();
            return result;
        }
    }
}