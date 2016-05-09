using System;

namespace UnitTest.Extensions
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
            if (underlyingType != null)
            {
                return longName ?
                    $"Nullable<{underlyingType.Name}>" :
                    $"{underlyingType.Name}?";
            }
            return type.Name;
        }
    }
}