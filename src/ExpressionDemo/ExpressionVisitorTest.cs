﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ExpressionDemo
{
    public static class ExpressionVisitorTest
    {
        public static void Test()
        {
            Expression<Func<Person, bool>> expression = p => p.ID > 0 && p.Age > 20;
            SQLExpressionVisitor visitor = new SQLExpressionVisitor();
            visitor.Visit(expression);

            Console.WriteLine("select * from Person where " + visitor.ToSql());
        }
    }
}
