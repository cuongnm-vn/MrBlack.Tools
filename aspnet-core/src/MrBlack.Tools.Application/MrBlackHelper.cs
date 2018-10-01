using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace MrBlack.Tools
{
    internal class MrBlackHelper
    {
    }

    public static class LinqExtension
    {
        public static IQueryable<T> DynamicOrder<T>(this IQueryable<T> source, string ordering, bool ascending = true)
        {
            Type type = typeof(T);
            ParameterExpression parameter = Expression.Parameter(type, "p");
            PropertyInfo property;
            Expression propertyAccess;
            if (ordering.Contains('.'))
            {
                string[] childProperties = ordering.Split('.');
                property = type.GetProperty(childProperties[0]);
                propertyAccess = Expression.MakeMemberAccess(parameter, property);
                for (int i = 1; i < childProperties.Length; i++)
                {
                    property = property.PropertyType.GetProperty(childProperties[i]);
                    propertyAccess = Expression.MakeMemberAccess(propertyAccess, property);
                }
            }
            else
            {
                property = typeof(T).GetProperty(ordering, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
                propertyAccess = Expression.MakeMemberAccess(parameter, property);
            }

            LambdaExpression orderByExp = Expression.Lambda(propertyAccess, parameter);
            MethodCallExpression resultExp = Expression.Call(typeof(Queryable),
                ascending ? "OrderBy" : "OrderByDescending",
                new[] {type, property.PropertyType}, source.Expression,
                Expression.Quote(orderByExp));
            return source.Provider.CreateQuery<T>(resultExp);
        }

    }

    public static class QueryableExtensions
    {
        public static IQueryable<T> DyamicFilter<T>(this IQueryable<T> queryable, IEnumerable<KeyValuePair<string, string>> filters) where T : class
        {
            if (filters == null)
            {
                return queryable;
            }

            foreach (KeyValuePair<string, string> filter in filters)
            {
                var properties = typeof(T).GetProperties().Select(x => new{x.Name, Type =  x.PropertyType.FullName}).SingleOrDefault(x => string.Equals(x.Name, filter.Key, StringComparison.CurrentCultureIgnoreCase));

                if (properties == null)
                {
                    continue;
                }

                queryable = properties.Type == "System.String" ? queryable.Like(filter.Key, filter.Value) : queryable.Equal(filter.Key, filter.Value, properties.Type);

            }
            return queryable;
        }

        public static IQueryable<T> Like<T>(this IQueryable<T> source, string propertyName, string keyword)
        {
            Type type                        = typeof(T);
            ParameterExpression parameter    = Expression.Parameter(type, "param");
            MemberExpression memberAccess    = Expression.MakeMemberAccess(parameter, type.GetProperty(propertyName));
            MethodInfo contains              = memberAccess.Type.GetMethod("Contains", new[] { typeof(string) });
            MethodCallExpression methodExp   = Expression.Call(memberAccess, contains, Expression.Constant(keyword));
            Expression<Func<T, bool>> lambda = Expression.Lambda<Func<T, bool>>(methodExp, parameter);

            return source.Where(lambda);
        }

        public static IQueryable<T> Equal<T>(this IQueryable<T> source, string propertyName, string keyword, string type)
        {
            ParameterExpression parameterExpression     = Expression.Parameter(typeof(T));
            MemberExpression propertyExpression         = Expression.Property(parameterExpression, propertyName);
            ConstantExpression constantExpression       = Expression.Constant(Convert.ChangeType(keyword, Type.GetType(type)));
            BinaryExpression equalExpression            = Expression.Equal(propertyExpression, constantExpression);
            MethodCallExpression methodCallExpression   = Expression.Call(typeof(Queryable), "Where", new[] { typeof(T) }, source.Expression, Expression.Lambda<Func<T, bool>>(equalExpression, new[] { parameterExpression }));
            return source.Provider.CreateQuery(methodCallExpression) as IQueryable<T>;
        }
    }
}
