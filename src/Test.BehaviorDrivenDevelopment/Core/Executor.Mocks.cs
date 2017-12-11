namespace CustomCode.Test.BehaviorDrivenDevelopment
{
    using LightInject;
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    
    /// <summary>
    /// Executes a method (to be tested) on an instance of type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T"> The type under test. </typeparam>
    public sealed class ExecutorWithMocks<T> : IFluentInterface where T : class
    {
        #region Dependencies

        public ExecutorWithMocks()
        { }

        public ExecutorWithMocks(IEnumerable<ServiceRegistration> mockArrangements, ServiceRegistration arrange)
        {
            MockArrangments.AddRange(mockArrangements);
            MockArrangments.Add(arrange);
        }

        #endregion

        #region Data

        private List<ServiceRegistration> MockArrangments { get; } = new List<ServiceRegistration>();

        #endregion

        #region Logic

        /// <summary>
        /// Define the (void) method under test via the <paramref name="act"/> delegate.
        /// </summary>
        /// <param name="act"> A delegate that executes the (void) method under test. </param>
        /// <returns>
        /// A <see cref="ValidatorWithMocks{T}"/> that can be used to execute any number of assertions
        /// on the type under test.
        /// </returns>
        public ValidatorWithMocks<T> When(Action<T> act)
        {
            return new ValidatorWithMocks<T>(act);
        }

        /// <summary>
        /// Define the (non-void) method under test via the <paramref name="act"/> delegate.
        /// </summary>
        /// <typeparam name="TResult"> The type of the result of the method under test. </typeparam>
        /// <param name="act"> A delegate that executes the (void) method under test. </param>
        /// <returns>
        /// A <see cref="ValidatorWithMocks{T, TResult}"/> that can be used to execute any number of
        /// assertions on the method result.
        /// </returns>
        public ValidatorWithMocks<T, TResult> When<TResult>(Func<T, TResult> act)
        {
            return new ValidatorWithMocks<T, TResult>(act);
        }

        /*
        public MockExecutor<T> With<TMock>(Expression<Action<TMock>> arrange) where TMock : class
        {
            var @base = arrange as Expression;
            var mock = new Mock<TMock>();
            var setup = mock.Setup(@base as Expression<Action<TMock>>);

            return null;
        }*/

        public MockArrangement<T, TMock, TResult> With<TMock, TResult>(Expression<Func<TMock, TResult>> arrange) where TMock : class
        {
            //var methodCall = arrange.Body as MethodCallExpression;
            //var instance = methodCall.Object as ParameterExpression;
            //var method = methodCall.Method;
            //var instanceType = instance.Type;

            //var mock = new Mock<TMock>();
            //var setup = mock.Setup(arrange);

            return new MockArrangement<T, TMock, TResult>(arrange);
            //return new MockExecutor<T>(MockArrangments, arrange);
        }

        #endregion
    }
}