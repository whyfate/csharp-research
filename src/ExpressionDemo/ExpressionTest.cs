using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionDemo;

public static class ExpressionTest
{
    public static void Test()
    {
        TestVariable();
        TestOperator();
        TestCondition();
        TestLoop();
    }

    static void TestVariable()
    {
        // 定义
        // 创建一个变量
        var v = Expression.Variable(typeof(int), "v");
        // 创建一个参数
        var p = Expression.Parameter(typeof(int), "p");
        // 创建一个常量
        var c = Expression.Constant(1);

        // 赋值
        var a = Expression.Assign(v, c);

        // 输出
        // 输出常量
        var c1 = Expression.Constant(1);
        var m1 = Expression.Call(null, typeof(Console).GetMethod("WriteLine", new Type[] { typeof(int) }), c1);
        var lambda = Expression.Lambda<Action>(m1);
        lambda.Compile().Invoke();

        // 输出变量
        var p2 = Expression.Parameter(typeof(int), "p");
        var m2 = Expression.Call(null, typeof(Console).GetMethod("WriteLine", new Type[] { typeof(int) }), p2);
        var lambda2 = Expression.Lambda<Action<int>>(m2, p2);
        lambda2.Compile().Invoke(2);

        // 输出组合
        var p3 = Expression.Parameter(typeof(int), "p");
        var a3 = Expression.Assign(p3, Expression.Constant(3));
        var m3 = Expression.Call(null, typeof(Console).GetMethod("WriteLine", new Type[] { typeof(int) }), p3);
        var blockEx = Expression.Block(new ParameterExpression[] { p3 }, a3, m3);
        Expression.Lambda<Action>(blockEx).Compile()();
    }

    static void TestOperator()
    {
        // +-*/%
        ParameterExpression a = Expression.Parameter(typeof(int), "a");
        ParameterExpression b = Expression.Parameter(typeof(int), "b");
        var add = Expression.Add(a, b);
        var sub = Expression.Subtract(a, b);
        var mul = Expression.Multiply(a, b);
        var div = Expression.Divide(a, b);

        // ++ --
        var addSelf = Expression.PostIncrementAssign(a);
        var subSelf = Expression.PostDecrementAssign(a);

        // ==、!=、>、<、>=、<=
        BinaryExpression setA = Expression.Assign(a, Expression.Constant(21));
        BinaryExpression setB = Expression.Assign(b, Expression.Constant(20));
        var eq = Expression.Equal(a, b);
        var notEQ = Expression.NotEqual(a, b);
        MethodCallExpression call11 = Expression.Call(null,
            typeof(Console).GetMethod("WriteLine", new Type[] { typeof(bool) }),
            eq);

        // &&、||、!
        Expression.AndAlso(eq, notEQ);
        Expression.OrElse(eq, notEQ);
        Expression.Not(notEQ);

        Expression<Func<Person, bool>> ex1 = p => p.Age > 20;
        Expression<Func<Person, bool>> ex2 = p => p.ID > 20;
        var parameter = Expression.Parameter(typeof(Person));
        var andAlso = Expression.AndAlso(Expression.Invoke(ex1, parameter), Expression.Invoke(ex2, parameter));
        var ex = Expression.Lambda<Func<Person, bool>>(andAlso, parameter);

        //&、|、^、~、<<、>>
        Expression.And(eq, notEQ);
        Expression.Or(eq, notEQ);
    }

    static void TestCondition()
    {
        // if else ??
        ParameterExpression a = Expression.Variable(typeof(int), "a");
        ParameterExpression b = Expression.Variable(typeof(int), "b");
        MethodCallExpression call = Expression.Call(
            null,
            typeof(Console).GetMethod("WriteLine", new Type[] { typeof(string) }),
            Expression.Constant("a == b 为 true，表达式树被执行"));
        MethodCallExpression call2 = Expression.Call(
                null,
                typeof(Console).GetMethod("WriteLine", new Type[] { typeof(string) }),
                Expression.Constant("a == b 为 false，此表达式树被执行"));

        ConditionalExpression _if = Expression.IfThen(Expression.Equal(a, b), call);

        ConditionalExpression _ifThenElse = Expression.IfThenElse(Expression.Equal(a, b), call, call2);

        Expression<Action<int, int>> lambda = Expression.Lambda<Action<int, int>>(_if, a, b);
        lambda.Compile()(10, 10);

        Expression<Action<int, int>> lambda2 = Expression.Lambda<Action<int, int>>(_ifThenElse, a, b);
        lambda2.Compile()(10, 11);
    }

    static void TestLoop()
    {
        LabelTarget _break = Expression.Label();

        BlockExpression _block = Expression.Block(
           new ParameterExpression[] { },
           Expression.Call(null, typeof(Console).GetMethod("WriteLine", new Type[] { typeof(string) }), Expression.Constant("我被执行一次就结束循环了")), Expression.Break(_break));
        LoopExpression _loop = Expression.Loop(_block, _break);

        Expression<Action> lambda = Expression.Lambda<Action>(_loop);
        lambda.Compile()();
    }
}
