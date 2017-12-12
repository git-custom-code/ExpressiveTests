namespace CustomCode.Test.BehaviorDrivenDevelopment
{
    using Moq;
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

        /// <summary>
        /// Creates a new instance of the <see cref="ExecutorWithMocks{T}"/> type.
        /// </summary>
        public ExecutorWithMocks()
        {
            Arrangements = new Dictionary<Type, List<Action<Mock>>>();
        }

        /// <summary>
        /// Creates a new instance of the <see cref="ExecutorWithMocks{T}"/> type.
        /// </summary>
        /// <param name="arrangements">
        /// A collection of arrangements that should be applied to instanciated mock objects.
        /// </param>
        public ExecutorWithMocks(IDictionary<Type, List<Action<Mock>>> arrangements)
        {
            Arrangements = arrangements;
        }

        #endregion

        #region Data

        /// <summary>
        /// Gets a collection of arrangements that should be applied to instanciated mock objects.
        /// </summary>
        private IDictionary<Type, List<Action<Mock>>> Arrangements { get; }

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
            return new ValidatorWithMocks<T>(act, Arrangements);
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
            return new ValidatorWithMocks<T, TResult>(act, Arrangements);
        }

        /// <summary>
        /// Define an arrangment for a method that should be called on the specified mock object.
        /// </summary>
        /// <typeparam name="TMock"> The type of the mock object. </typeparam>
        /// <typeparam name="TResult">
        /// The result of the method of the mock object that should return a specific value.
        /// </typeparam>
        /// <param name="arrange">
        /// A delegate that can be used to define the type of a mock object as well as a method that should return a
        /// specific value.
        /// </param>
        /// <returns>
        /// A <see cref="MockReturnValue{T, TMock, TResult}"/> that can be used to specify the return value of the
        /// arranged mock object's method.
        /// </returns>
        public MockReturnValue<T, TMock, TResult> With<TMock, TResult>(Expression<Func<TMock, TResult>> arrange)
            where TMock : class
        {
            return new MockReturnValue<T, TMock, TResult>(arrange, Arrangements);
        }

        #endregion
    }
}