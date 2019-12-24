using System.Linq.Expressions;

namespace Reflection.Expressions
{
	public class ChangeExpressionToMultiply : ExpressionVisitor
	{
		protected override Expression VisitBinary(BinaryExpression node)
		{
			if(node.NodeType == ExpressionType.Divide)
			{
				return Expression.Multiply(node.Left, node.Right);
			}
			return base.Visit(node);
		}

		public Expression Change(Expression expression) => Visit(expression);
	}
}
