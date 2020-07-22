using StatelessAPIs.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace StatelessAPIs.Services.Common
{
    public static class QueryableUtils
    {
        public static Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> GetOrderByFunction<TEntity>(
            List<Sortable> sortables)
        {
            Type typeQueryable = typeof(IQueryable<TEntity>);
            ParameterExpression argQueryable = Expression.Parameter(typeQueryable, "p");
            Type entityType = typeof(TEntity);
            ParameterExpression arg = Expression.Parameter(entityType, "x");
            Expression resultExp = argQueryable;
            bool first = true;

            sortables ??= new List<Sortable>();
            foreach (Sortable sortable in sortables)
            {
                PropertyInfo pi = entityType.GetProperty(sortable.FieldName,
                    BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
                if (pi == null) continue;
                Expression propertyExpr = Expression.Property(arg, pi);
                Type propertyType = pi.PropertyType;
                LambdaExpression lambdaExp = Expression.Lambda(propertyExpr, arg);

                string methodName;
                if (first)
                {
                    first = false;
                    methodName = sortable.IsDescending ? "OrderByDescending" : "OrderBy";
                }
                else
                {
                    methodName = sortable.IsDescending ? "ThenByDescending" : "ThenBy";
                }

                resultExp = Expression.Call(typeof(Queryable), methodName, new[] { entityType, propertyType }, resultExp,
                    Expression.Quote(lambdaExp));
            }

            // Case empty columns: simply append a .OrderBy(x => true)
            if (first)
            {
                LambdaExpression lambdaExp = Expression.Lambda(Expression.Constant(true), arg);
                resultExp = Expression.Call(typeof(Queryable), "OrderBy", new[] { entityType, typeof(bool) }, resultExp,
                    Expression.Quote(lambdaExp));
            }

            LambdaExpression orderedLambda = Expression.Lambda(resultExp, argQueryable);
            return (Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>)orderedLambda.Compile();
        }
    }
}
