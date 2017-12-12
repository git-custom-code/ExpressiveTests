namespace CustomCode.Test.BehaviorDrivenDevelopment
{
    using Extensions;
    using Moq;
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    /// <summary>
    /// Specify a result value for an arranged mock object's method call.
    /// </summary>
    /// <typeparam name="T"> The type under test. </typeparam>
    /// <typeparam name="TMock"> The type of the mock object. </typeparam>
    /// <typeparam name="TResult"> The result value of the mock object's arranged method call. </typeparam>
    public sealed class MockReturnValue<T, TMock, TResult> : IFluentInterface
        where T : class
        where TMock : class
    {
        #region Dependencies

        /// <summary>
        /// Creates a new instance of the <see cref="MockReturnValue{T, TMock, TResult}"/> type.
        /// </summary>
        /// <param name="arrange">
        /// A delegate that can be used to define the type of a mock object as well as a method that should return a
        /// specific value.
        /// </param>
        /// <param name="arrangements">
        /// A collection of arrangements that should be applied to instanciated mock objects.
        /// </param>
        public MockReturnValue(Expression<Func<TMock, TResult>> arrange, IDictionary<Type, List<Action<Mock>>> arrangements)
        {
            Arrange = arrange;
            Arrangements = arrangements;
        }

        #endregion

        #region Data

        /// <summary>
        /// Gets a delegate that can be used to define the type of a mock object as well as a method that should return
        /// a specific value.
        /// </summary>
        private Expression<Func<TMock, TResult>> Arrange { get; }

        /// <summary>
        /// Gets a collection of arrangements that should be applied to instanciated mock objects.
        /// </summary>
        private IDictionary<Type, List<Action<Mock>>> Arrangements { get; }

        #endregion

        #region Logic

        /// <summary>
        /// Specify the return value of the arranged mock object's method call.
        /// </summary>
        /// <param name="result"> The value to be returned. </param>
        /// <param name="returnIfParametersMatch">
        /// True if the return value should only be returned if the arranged method's input parameters match,
        /// false otherwise.
        /// </param>
        /// <returns>
        /// An <see cref="ExecutorWithMocks{T}"/> that can be used to arrange mock objects and/or execute a method
        /// (to be tested) on an instance of type <typeparamref name="T"/>.
        /// </returns>
        public ExecutorWithMocks<T> Returns(TResult result, bool returnOnlyIfParametersMatch = false)
        {
            var mockType = typeof(Mock<TMock>);
            var expression = Arrange;
            if (returnOnlyIfParametersMatch == false)
            {
                var visitor = new IgnoreMockParametersVisitor();
                expression = visitor.VisitAndConvert(Arrange, nameof(Returns));
            }
            Action<Mock> arrangement = (mock) => ((Mock<TMock>)mock).Setup(expression).Returns(result);

            if (Arrangements.TryGetValue(mockType, out List<Action<Mock>> arrangements))
            {
                arrangements.Add(arrangement);
            }
            else
            {
                Arrangements.Add(mockType, new List<Action<Mock>>(1) { arrangement });
            }

            return new ExecutorWithMocks<T>(Arrangements);
        }

        #endregion
    }
}