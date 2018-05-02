namespace CustomCode.Test.BehaviorDrivenDevelopment
{
    using System;
    using System.Threading.Tasks;
    using Xunit.Sdk;

    /// <summary>
    /// Executes a method (to be tested) on an instance of type <typeparamref name="T"/> that needs two
    /// additional parameters of type <typeparamref name="TFirst"/> and <typeparamref name="TSecond"/>.
    /// </summary>
    /// <typeparam name="T"> The type under test. </typeparam>
    /// <typeparam name="TFirst"> The type of the first parameter needed for the method under test. </typeparam>
    /// <typeparam name="TSecond"> The type of the second parameter needed for the method under test. </typeparam>
    public struct Executor<T, TFirst, TSecond> : IFluentInterface
        where TFirst : class
        where TSecond : class
    {
        #region Dependencies

        /// <summary>
        /// Creates a new instance of the <see cref="Executor{T, TFirst, TSecond}"/> type.
        /// </summary>
        /// <param name="arrange"> A delegate that creates the type under test. </param>
        /// <param name="arrangeFirstParameter"> A delegate that creates the needed first parameter instance. </param>
        /// <param name="arrangeSecondParameter"> A delegate that creates the needed second parameter instance. </param>
        public Executor(Func<T> arrange, Func<TFirst> arrangeFirstParameter, Func<TSecond> arrangeSecondParameter)
        {
            Arrange = arrange ?? throw new XunitException($"{Environment.NewLine}The {nameof(arrange)} delegate cannot be null");
            ArrangeFirstParameter = arrangeFirstParameter ?? throw new XunitException($"{Environment.NewLine}The {nameof(arrangeFirstParameter)} delegate cannot be null");
            ArrangeSecondParameter = arrangeSecondParameter ?? throw new XunitException($"{Environment.NewLine}The {nameof(arrangeSecondParameter)} delegate cannot be null");
        }

        #endregion

        #region Data

        /// <summary>
        /// Gets a delegate that creates the type under test.
        /// </summary>
        private Func<T> Arrange { get; }

        /// <summary>
        /// Gets a delegate that creates the needed first parameter instance.
        /// </summary>
        private Func<TFirst> ArrangeFirstParameter { get; }

        /// <summary>
        /// Gets a delegate that creates the needed second parameter instance.
        /// </summary>
        private Func<TSecond> ArrangeSecondParameter { get; }

        #endregion

        #region Logic

        /// <summary>
        /// Define the (void) method under test via the <paramref name="act"/> delegate.
        /// </summary>
        /// <param name="act"> A delegate that executes the (void) method under test. </param>
        /// <returns>
        /// A <see cref="ValidatorWithTwoParameters{T, TFirst, TSecond}"/> that can be used
        /// to execute any number of assertions on the type under test.
        /// </returns>
        public ValidatorWithTwoParameters<T, TFirst, TSecond> When(Action<T, TFirst, TSecond> act)
        {
            return new ValidatorWithTwoParameters<T, TFirst, TSecond>(
                Arrange,
                ArrangeFirstParameter,
                ArrangeSecondParameter,
                act);
        }

        /// <summary>
        /// Define the asychronous (void) method under test via the <paramref name="actAsync"/> delegate.
        /// </summary>
        /// <param name="actAsync"> A delegate that executes the asynchronous (void) method under test. </param>
        /// <returns>
        /// A <see cref="ValidatorWithTwoParametersAsync{T, TFirst, TSecond}"/> that can be used
        /// to execute any number of assertions on the type under test.
        /// </returns>
        public ValidatorWithTwoParametersAsync<T, TFirst, TSecond> When(Func<T, TFirst, TSecond, Task> actAsync)
        {
            return new ValidatorWithTwoParametersAsync<T, TFirst, TSecond>(
                Arrange,
                ArrangeFirstParameter,
                ArrangeSecondParameter,
                actAsync);
        }

        /// <summary>
        /// Define the (non-void) method under test via the <paramref name="act"/> delegate.
        /// </summary>
        /// <typeparam name="TResult"> The type of the result of the method under test. </typeparam>
        /// <param name="act"> A delegate that executes the (non-void) method under test. </param>
        /// <returns>
        /// A <see cref="ValidatorWithTwoParameters{T, TFirst, TSecond, TResult}"/>
        /// that can be used to execute any number of assertions on the method result.
        /// </returns>
        public ValidatorWithTwoParameters<T, TFirst, TSecond, TResult> When<TResult>(Func<T, TFirst, TSecond, TResult> act)
        {
            return new ValidatorWithTwoParameters<T, TFirst, TSecond, TResult>(
                Arrange,
                ArrangeFirstParameter,
                ArrangeSecondParameter,
                act);
        }

        /// <summary>
        /// Define the asynchronous (non-void) method under test via the <paramref name="actAsync"/> delegate.
        /// </summary>
        /// <typeparam name="TResult"> The type of the result of the asynchronous method under test. </typeparam>
        /// <param name="actAsync"> A delegate that executes the asynchronous (non-void) method under test. </param>
        /// <returns>
        /// A <see cref="ValidatorWithTwoParametersAsync{T, TFirst, TSecond, TResult}"/> that can be used
        /// to execute any number of assertions on the asynchronous method result.
        /// </returns>
        public ValidatorWithTwoParametersAsync<T, TFirst, TSecond, TResult> When<TResult>(Func<T, TFirst, TSecond, Task<TResult>> actAsync)
        {
            return new ValidatorWithTwoParametersAsync<T, TFirst, TSecond, TResult>(
                Arrange,
                ArrangeFirstParameter,
                ArrangeSecondParameter,
                actAsync);
        }

        #endregion
    }
}