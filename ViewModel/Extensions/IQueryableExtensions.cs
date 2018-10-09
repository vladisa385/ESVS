using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace ViewModel.Extensions
{
    // ReSharper disable once InconsistentNaming
    public static class IQueryableExtensions
    {
        public static IOrderedQueryable<T> OrderBy<T>(this IQueryable<T> source, string ordering, bool desc = false)
        {
            return DynamicOrder(source, ordering, desc ? "OrderByDescending" : "OrderBy");
        }

        public static IOrderedQueryable<T> OrderByDescending<T>(this IQueryable<T> source, string ordering)
        {
            return OrderBy(source, ordering, true);
        }

        public static IOrderedQueryable<T> ThenBy<T>(this IQueryable<T> source, string ordering, bool desc = false)
        {
            return DynamicOrder(source, ordering, desc ? "ThenByDescending" : "ThenBy");
        }

        public static IOrderedQueryable<T> ThenByDescending<T>(this IOrderedQueryable<T> source, string ordering)
        {
            return ThenBy(source, ordering, true);
        }

        private static IOrderedQueryable<T> DynamicOrder<T>(IQueryable<T> source, string ordering, string method)
        {
            var type = typeof(T);
            var property = type.GetProperty(ordering, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);

            if (property == null)
            {
                throw new MissingMemberException($"Property {type.Name}.{ordering} is missing");
            }

            var parameter = Expression.Parameter(type, "p");
            var propertyAccess = Expression.MakeMemberAccess(parameter, property);
            var orderByExp = Expression.Lambda(propertyAccess, parameter);
            MethodCallExpression resultExp = Expression.Call(typeof(Queryable),
                method,
                new Type[] { type, property.PropertyType },
                source.Expression, Expression.Quote(orderByExp));
            return (IOrderedQueryable<T>)source.Provider.CreateQuery<T>(resultExp);
        }
    }
}
