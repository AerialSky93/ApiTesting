

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using System.Linq.Expressions;

namespace Sample.Web.Api.Models
{
    public static class PaginateClass
    {
        static readonly MethodInfo startsWith = typeof(string).GetMethod("StartsWith", new[] { typeof(string), typeof(System.StringComparison) });

        public static IEnumerable<T> Paginate<T>(this IEnumerable<T> input, PageModel pageModel) where T : class
        {
            string columnName = pageModel.ColumnSort;
            var type = typeof(T);
            var propertyInfo = type.GetProperty(columnName);
            //T p =>
            var parameter = Expression.Parameter(type, "p");
            //T p => p.ColumnName
            var name = Expression.Property(parameter, propertyInfo);
            // filterModel.Term ?? String.Empty
            var term = Expression.Constant(pageModel.Term ?? String.Empty);
            //StringComparison.InvariantCultureIgnoreCase
            var comparison = Expression.Constant(StringComparison.InvariantCultureIgnoreCase);
            //T p => p.ColumnName.StartsWith(filterModel.Term ?? String.Empty, StringComparison.InvariantCultureIgnoreCase)
            var methodCall = Expression.Call(name, startsWith, term, comparison);

            var lambda = Expression.Lambda<Func<T, bool>>(methodCall, parameter);

            var parameterExpression = Expression.Parameter(type, "x");
            var propertyAccess = Expression.Property(parameterExpression, propertyInfo);
            var orderExpression = Expression.Lambda<Func<T, string>>(propertyAccess, parameterExpression);


            if (pageModel.Page == 0 || pageModel.Page == 0)
            {
                return input;
            }
            else
            { 
                return input.Where(lambda.Compile()).OrderBy(orderExpression.Compile())
                .Skip((pageModel.Page - 1) * pageModel.Limit)
                .Take(pageModel.Limit);
            }
        }
    }
}