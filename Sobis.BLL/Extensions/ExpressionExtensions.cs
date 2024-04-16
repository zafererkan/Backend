using LinqKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Sobis.BLL.Extensions
{
    public static class ExpressionExtensions
    {
        public static IQueryable<TEntity> ApplyFilter<TEntity, TProperty>(
    this IQueryable<TEntity> query,
    Expression<Func<TEntity, TProperty>> expr, TProperty value, string AndOr = "and")
        {
            Expression<Func<TEntity, bool>> predicate = param => true;

            var filterExpression = Expression.Equal(expr, Expression.Constant(value));
            var lambda = Expression.Lambda<Func<TEntity, bool>>(filterExpression);

            if (AndOr == "or")
            {
                predicate = predicate.Or(lambda);
            }
            else
                predicate = predicate.And(lambda);

            return query.Where(predicate);
        }

        public static Expression<Func<T, bool>> CreateEqualExpression<T>(string propertyName, object value)
        {
            var param = Expression.Parameter(typeof(T), "p");
            var member = Expression.Property(param, propertyName);
            var constant = Expression.Constant(value);
            var body = Expression.Equal(member, constant);
            return Expression.Lambda<Func<T, bool>>(body, param);
        }
        public static Expression<Func<T, bool>> CreateEqualExpression<T>(IDictionary<string, object> filters)
        {
            var param = Expression.Parameter(typeof(T), "p");
            Expression body = null;
            foreach (var pair in filters)
            {
                var member = Expression.Property(param, pair.Key);
                var constant = Expression.Constant(pair.Value);
                var expression = Expression.Equal(member, constant);
                body = body == null ? expression : Expression.AndAlso(body, expression);
            }
            return Expression.Lambda<Func<T, bool>>(body, param);
        }
    }
}
