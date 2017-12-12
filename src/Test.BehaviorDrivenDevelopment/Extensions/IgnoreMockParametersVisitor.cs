namespace CustomCode.Test.BehaviorDrivenDevelopment.Extensions
{
    using Moq;
    using System.Linq.Expressions;
    using System.Reflection;

    /// <summary>
    /// A linq <see cref="ExpressionVisitor"/> that can be used in combination with moq and a 
    /// <see cref="MockReturnValue{T, TMock, TResult}"/> to ignore any parameter values that
    /// are defined by the developer.
    /// </summary>
    public sealed class IgnoreMockParametersVisitor : ExpressionVisitor
    {
        #region Logic

        /// <summary>
        /// This override resolve an edge case when you have an optional params array parameter but
        /// don't specify any value inside of the mock arrangement.
        /// </summary>
        /// <param name="node"> The <see cref="Expression"/> to visit. </param>
        /// <returns> The modified expression. </returns>
        protected override Expression VisitNewArray(NewArrayExpression node)
        {
            var method = typeof(It)
                .GetMethod(nameof(It.IsAny))
                .MakeGenericMethod(node.Type);

            return Expression.Call(method);
        }

        /// <summary>
        /// Replace any constant parameter values (used inside of a mock arrangment) with moq's <see cref="It.IsAny{TValue}"/>
        /// instead, thereby ignoring the specified constant value.
        /// </summary>
        /// <param name="node"> The <see cref="Expression"/> to visit. </param>
        /// <returns> The modified expression. </returns>
        protected override Expression VisitConstant(ConstantExpression node)
        {
            var method = typeof(It)
                .GetMethod(nameof(It.IsAny))
                .MakeGenericMethod(node.Type);

            return Expression.Call(method);
        }

        #endregion
    }
}