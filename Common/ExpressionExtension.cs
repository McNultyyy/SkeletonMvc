using System;
using System.Linq.Expressions;

namespace Common
{
    public static class ExpressionExtension
    {
        public static string GetPropertyName<TSource, TProperty>(this TSource source, Expression<Func<TSource, TProperty>> expr)
        {
            var memberExpr = (MemberExpression)expr.Body;
            return memberExpr.Member.Name;
        }

    }
}