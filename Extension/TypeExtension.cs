using System;
using System.CodeDom;
using Microsoft.CSharp;

namespace Extension
{
    public static class TypeExtension
    {
        public static Type GetNullableType(this Type type)
        {
            type = Nullable.GetUnderlyingType(type);
            if (type.IsValueType)
                return typeof(Nullable<>).MakeGenericType(type);
            return type;
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
            {
                return longName ?
                    $"Nullable<{typeName}>" :
                    $"{typeName}?";
            }
            return typeName;
        }
    }
}