using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ExpressionDemo
{
    public class SQLExpressionVisitor : ExpressionVisitor
    {
        private Queue<string> sqlBuilder = new Queue<string>();
       
        protected override Expression VisitBinary(BinaryExpression node)
        {
            sqlBuilder.Enqueue("(");

            this.Visit(node.Left);

            if(node.NodeType == ExpressionType.GreaterThan){
                sqlBuilder.Enqueue(">");
            }
            else if(node.NodeType == ExpressionType.And || node.NodeType == ExpressionType.AndAlso){
                sqlBuilder.Enqueue("&&");
            }

            this.Visit(node.Right);

            sqlBuilder.Enqueue(")");

            return node;
        }

        protected override Expression VisitMember(MemberExpression node)
        {
            sqlBuilder.Enqueue(node.Member.Name);

            return base.VisitMember(node);
        }

        protected override Expression VisitConstant(ConstantExpression node)
        {
            sqlBuilder.Enqueue(node.Value.ToString());

            return base.VisitConstant(node);
        }
        public string ToSql(){
            var sql = new StringBuilder();
            while (sqlBuilder.Count>0)
            {
                var str = sqlBuilder.Dequeue();

                sql.Append(str);
            }
            return sql.ToString();
        }
    }
}
