using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionVisitorDemo;

public static class ExpressionExtensions
{
    public static Expression<Func<T,bool>> And<T>(Expression<Func<T, bool>> exp1, Expression<Func<T, bool>> exp2)
    {
        var exp = Expression.And(exp1.Body, Expression.Invoke(exp2,exp1.Parameters));
        return Expression.Lambda<Func<T,bool>>(exp);
    }
}
