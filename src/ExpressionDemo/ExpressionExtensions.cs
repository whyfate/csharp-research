using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionDemo;

public static class ExpressionExtensions
{
    public static Expression<Func<T, bool>> AndAlso<T>(Expression<Func<T, bool>> exp1, Expression<Func<T, bool>> exp2)
    {
        var exp = Expression.AndAlso(exp1.Body, Expression.Invoke(exp2, exp1.Parameters));
        return Expression.Lambda<Func<T, bool>>(exp);
    }

    public static Func<T, bool> AndAlso<T>(Func<T, bool> f1, Func<T, bool> f2)
    {
        return x => f1(x) && f2(x);
    }
}
