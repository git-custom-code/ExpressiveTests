namespace CustomCode.Test.BehaviorDrivenDevelopment
{
    using System;
    using System.Threading.Tasks;
    using Xunit.Sdk;

    /// <summary>
    /// Executes a method (to be tested) on an instance of type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T"> The type under test. </typeparam>
    public struct Executor<T> : IFluentInterface
    {
        #region Dependencies

        /// <summary>
        /// Creates a new instance of the <see cref="Executor{T}"/> type.
        /// </summary>
        /// <param name="arrange"> A delegate that creates the type under test. </param>
        public Executor(Func<T> arrange)
        {
            Arrange = arrange ?? throw new XunitException($"{Environment.NewLine}The {nameof(arrange)} delegate cannot be null");
        }

        #endregion

        #region Data

        /// <summary>
        /// Gets a delegate that creates the type under test.
        /// </summary>
        private Func<T> Arrange { get; }

        #endregion

        #region Logic

        /// <summary>
        /// Define the (void) method under test via the <paramref name="act"/> delegate.
        /// </summary>
        /// <param name="act"> A delegate that executes the (void) method under test. </param>
        /// <returns>
        /// A <see cref="Validator{T}"/> that can be used to execute any number of assertions
        /// on the type under test.
        /// </returns>
        public Validator<T> When(Action<T> act)
        {
            return new Validator<T>(Arrange, act);
        }

        /// <summary>
        /// Define the asychronous (void) method under test via the <paramref name="actAsync"/> delegate.
        /// </summary>
        /// <param name="actAsync"> A delegate that executes the asynchronous (void) method under test. </param>
        /// <returns>
        /// A <see cref="ValidatorAsync{T}"/> that can be used to execute any number of assertions
        /// on the type under test.
        /// </returns>
        public ValidatorAsync<T> When(Func<T, Task> actAsync)
        {
            return new ValidatorAsync<T>(Arrange, actAsync);
        }

        /// <summary>
        /// Define the (non-void) method under test via the <paramref name="act"/> delegate.
        /// </summary>
        /// <typeparam name="TResult"> The type of the result of the method under test. </typeparam>
        /// <param name="act"> A delegate that executes the (non-void) method under test. </param>
        /// <returns>
        /// A <see cref="Validator{T, TResult}"/> that can be used to execute any number of
        /// assertions on the method result.
        /// </returns>
        public Validator<T, TResult> When<TResult>(Func<T, TResult> act)
        {
            return new Validator<T, TResult>(Arrange, act);
        }

        /// <summary>
        /// Define the asynchronous (non-void) method under test via the <paramref name="actAsync"/> delegate.
        /// </summary>
        /// <typeparam name="TResult"> The type of the result of the asynchronous method under test. </typeparam>
        /// <param name="actAsync"> A delegate that executes the asynchronous (non-void) method under test. </param>
        /// <returns>
        /// A <see cref="ValidatorAsync{T, TResult}"/> that can be used to execute any number of
        /// assertions on the asynchronous method result.
        /// </returns>
        public ValidatorAsync<T, TResult> When<TResult>(Func<T, Task<TResult>> actAsync)
        {
            return new ValidatorAsync<T, TResult>(Arrange, actAsync);
        }

        #endregion
    }
}