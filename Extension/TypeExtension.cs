using System;
using System.CodeDom;
using System.Linq;
using Microsoft.CSharp;
using Moq;

namespace Extension
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

        public static object DynamicMock(this Type type)
        {
            var mock = typeof(Mock<>)
                .MakeGenericType(type)
                .GetConstructor(Type.EmptyTypes)
                .Invoke(new object[] { });
            return mock.GetType()
                .GetProperties()
                .Single(x => x.Name == "Object" && x.PropertyType == type)
                .GetValue(mock, new object[] { });
        }
    }
}