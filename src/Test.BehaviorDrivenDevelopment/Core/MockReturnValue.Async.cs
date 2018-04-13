namespace CustomCode.Test.BehaviorDrivenDevelopment
{
    using Extensions;
    using Moq;
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    /// <summary>
    /// Specify a result value for an arranged mock object's method call.
    /// </summary>
    /// <typeparam name="T"> The type under test. </typeparam>
    /// <typeparam name="TMock"> The type of the mock object. </typeparam>
    /// <typeparam name="TResult"> The result value of the mock object's arranged asynchronous method call. </typeparam>
    public struct MockAsyncReturnValue<T, TMock, TResult> : IFluentInterface
        where TMock : class
    {
        #region Dependencies

        /// <summary>
        /// Creates a new instance of the <see cref="MockAsyncReturnValue{T, TMock, TResult}"/> type.
        /// </summary>
        /// <param name="arrangeAsync">
        /// A delegate that can be used to define the type of a mock object as well as an asynchronous method
        /// that should return a specific value.
        /// </param>
        /// <param name="arrangements">
        /// A collection of arrangements that should be applied to instanciated mock objects.
        /// </param>
        public MockAsyncReturnValue(Expression<Func<TMock, Task<TResult>>> arrangeAsync, IDictionary<Type, List<Action<Mock>>> arrangements)
        {
            ArrangeAsync = arrangeAsync;
            Arrangements = arrangements;
        }

        #endregion

        #region Data

        /// <summary>
        /// Gets a delegate that can be used to define the type of a mock object as well as an asynchronous method
        /// that should return a specific value.
        /// </summary>
        private Expression<Func<TMock, Task<TResult>>> ArrangeAsync { get; }

        /// <summary>
        /// Gets a collection of arrangements that should be applied to instanciated mock objects.
        /// </summary>
        private IDictionary<Type, List<Action<Mock>>> Arrangements { get; }

        #endregion

        #region Logic

        /// <summary>
        /// Creates an <see cref="ExecutorWithMocks{T}"/> that can be used to arrange mock objects and/or execute a method
        /// (to be tested) on an instance of type <typeparamref name="T"/>.
        /// </summary>
        /// <param name="mockType"> The type under test. </param>
        /// <param name="arrangement"> The arrangement that shoud be applied to the mock object. </param>
        /// <returns>
        /// An <see cref="ExecutorWithMocks{T}"/> that can be used to arrange mock objects and/or execute a method
        /// (to be tested) on an instance of type <typeparamref name="T"/>.
        /// </returns>
        private ExecutorWithMocks<T> CreateExecutor(Type mockType, Action<Mock> arrangement)
        {
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

        /// <summary>
        /// Specify the return value of the arranged mock object's method call.
        /// </summary>
        /// <param name="result"> The value to be returned. </param>
        /// <param name="onlyIfParametersMatch">
        /// True if the return value should only be returned if the arranged method's input parameters match,
        /// false otherwise.
        /// </param>
        /// <returns>
        /// An <see cref="ExecutorWithMocks{T}"/> that can be used to arrange mock objects and/or execute a method
        /// (to be tested) on an instance of type <typeparamref name="T"/>.
        /// </returns>
        public ExecutorWithMocks<T> Returns(TResult result, bool onlyIfParametersMatch = false)
        {
            var expression = ArrangeAsync;
            if (onlyIfParametersMatch == false)
            {
                var visitor = new IgnoreMockParametersVisitor();
                expression = visitor.VisitAndConvert(ArrangeAsync, nameof(Returns));
            }

            var mockType = typeof(Mock<TMock>);
            Action<Mock> arrangement = (mock) => ((Mock<TMock>)mock).Setup(expression).Returns(Task.FromResult(result));
            return CreateExecutor(mockType, arrangement);
        }

        /// <summary>
        /// Specify an exception that is thrown when the arranged mock object's method is called.
        /// </summary>
        /// <typeparam name="TException"> The type of the exception to be thrown. </typeparam>
        /// <param name="onlyIfParametersMatch">
        /// True if the exception should only be thrown if the arranged method's input parameters match,
        /// false otherwise.
        /// </param>
        /// <returns>
        /// An <see cref="ExecutorWithMocks{T}"/> that can be used to arrange mock objects and/or execute a method
        /// (to be tested) on an instance of type <typeparamref name="T"/>.
        /// </returns>
        public ExecutorWithMocks<T> Throws<TException>(bool onlyIfParametersMatch = false)
            where TException : Exception, new()
        {
            var expression = ArrangeAsync;
            if (onlyIfParametersMatch == false)
            {
                var visitor = new IgnoreMockParametersVisitor();
                expression = visitor.VisitAndConvert(ArrangeAsync, nameof(Returns));
            }

            var mockType = typeof(Mock<TMock>);
            Action<Mock> arrangement = (mock) => ((Mock<TMock>)mock).Setup(expression).Throws<TException>();
            return CreateExecutor(mockType, arrangement);
        }

        /// <summary>
        /// Specify an exception that is thrown when the arranged mock object's method is called.
        /// </summary>
        /// <typeparam name="TException"> The type of the exception to be thrown. </typeparam>
        /// <param name="exceptionFactory"> A delegate that creates the exception to be thrown. </param>
        /// <param name="onlyIfParametersMatch">
        /// True if the exception should only be thrown if the arranged method's input parameters match,
        /// false otherwise.
        /// </param>
        /// <returns>
        /// An <see cref="ExecutorWithMocks{T}"/> that can be used to arrange mock objects and/or execute a method
        /// (to be tested) on an instance of type <typeparamref name="T"/>.
        /// </returns>
        public ExecutorWithMocks<T> Throws<TException>(Func<TException> exceptionFactory, bool onlyIfParametersMatch = false)
            where TException : Exception
        {
            var expression = ArrangeAsync;
            if (onlyIfParametersMatch == false)
            {
                var visitor = new IgnoreMockParametersVisitor();
                expression = visitor.VisitAndConvert(ArrangeAsync, nameof(Returns));
            }

            var mockType = typeof(Mock<TMock>);
            Action<Mock> arrangement = (mock) =>
                {
                    var exception = exceptionFactory();
                    ((Mock<TMock>)mock).Setup(expression).Throws(exception);
                };
            return CreateExecutor(mockType, arrangement);
        }

        #endregion
    }
}