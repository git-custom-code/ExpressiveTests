namespace CustomCode.Test.BehaviorDrivenDevelopment
{
    using System;
    using System.Threading.Tasks;
    using Xunit.Sdk;

    /// <summary>
    /// Executes a method (to be tested) on an instance of type <typeparamref name="T"/> that needs an
    /// additional first parameter of type <typeparamref name="TFirst"/>.
    /// </summary>
    /// <typeparam name="T"> The type under test. </typeparam>
    /// <typeparam name="TFirst"> The type of the first parameter needed for the method under test. </typeparam>
    public struct Executor<T, TFirst> : IFluentInterface
        where TFirst : class
    {
        #region Dependencies

        /// <summary>
        /// Creates a new instance of the <see cref="Executor{T, TFirst}"/> type.
        /// </summary>
        /// <param name="arrange"> A delegate that creates the type under test. </param>
        /// <param name="arrangeFirstParameter"> A delegate that creates the needed first parameter instance. </param>
        public Executor(Func<T> arrange, Func<TFirst> arrangeFirstParameter)
        {
            Arrange = arrange ?? throw new XunitException($"{Environment.NewLine}The {nameof(arrange)} delegate cannot be null");
            ArrangeFirstParameter = arrangeFirstParameter ?? throw new XunitException($"{Environment.NewLine}The {nameof(arrangeFirstParameter)} delegate cannot be null");
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

        #endregion

        #region Logic

        /// <summary>
        /// Define a delegate that creates two additional parameters of type <typeparamref name="TFirst"/>
        /// and <typeparamref name="TSecond"/> that are needed by the method under test.
        /// </summary>
        /// <typeparam name="TSecond"> The type of the second parameter needed for the method under test. </typeparam>
        /// <param name="arrangeSecondParameter"> A delegate that creates the needed second parameter instance. </param>
        /// <returns>
        /// An <see cref="Executor{T, TFirst, TSecond}"/> that can be used to execute a method (to be tested)
        /// on an instance of type <typeparamref name="T"/> that needs two additional parameters of type
        /// <typeparamref name="TFirst"/> and <typeparamref name="TSecond"/>.
        /// </returns>
        public Executor<T, TFirst, TSecond> Also<TSecond>(Func<TSecond> arrangeSecondParameter)
            where TSecond : class
        {
            return new Executor<T, TFirst, TSecond>(Arrange, ArrangeFirstParameter, arrangeSecondParameter);
        }

        /// <summary>
        /// Define the (void) method under test via the <paramref name="act"/> delegate.
        /// </summary>
        /// <param name="act"> A delegate that executes the (void) method under test. </param>
        /// <returns>
        /// A <see cref="ValidatorWithOneParameter{T, TFirst}"/> that can be used
        /// to execute any number of assertions on the type under test.
        /// </returns>
        public ValidatorWithOneParameter<T, TFirst> When(Action<T, TFirst> act)
        {
            return new ValidatorWithOneParameter<T, TFirst>(Arrange, ArrangeFirstParameter, act);
        }

        /// <summary>
        /// Define the asychronous (void) method under test via the <paramref name="actAsync"/> delegate.
        /// </summary>
        /// <param name="actAsync"> A delegate that executes the asynchronous (void) method under test. </param>
        /// <returns>
        /// A <see cref="ValidatorAsync{T}"/> that can be used to execute any number of assertions
        /// on the type under test.
        /// </returns>
        public ValidatorWithOneParameterAsync<T, TFirst> When(Func<T, TFirst, Task> actAsync)
        {
            return new ValidatorWithOneParameterAsync<T, TFirst>(Arrange, ArrangeFirstParameter, actAsync);
        }

        /// <summary>
        /// Define the (non-void) method under test via the <paramref name="act"/> delegate.
        /// </summary>
        /// <typeparam name="TResult"> The type of the result of the method under test. </typeparam>
        /// <param name="act"> A delegate that executes the (non-void) method under test. </param>
        /// <returns>
        /// A <see cref="ValidatorWithOneParameter{T, TFirst, TResult}"/> that can be used
        /// to execute any number of assertions on the method result.
        /// </returns>
        public ValidatorWithOneParameter<T, TFirst, TResult> When<TResult>(Func<T, TFirst, TResult> act)
        {
            return new ValidatorWithOneParameter<T, TFirst, TResult>(Arrange, ArrangeFirstParameter, act);
        }

        /// <summary>
        /// Define the asynchronous (non-void) method under test via the <paramref name="actAsync"/> delegate.
        /// </summary>
        /// <typeparam name="TResult"> The type of the result of the asynchronous method under test. </typeparam>
        /// <param name="actAsync"> A delegate that executes the asynchronous (non-void) method under test. </param>
        /// <returns>
        /// A <see cref="ValidatorWithOneParameterAsync{T, TFirst, TResult}"/> that can be used to execute
        /// any number of assertions on the asynchronous method result.
        /// </returns>
        public ValidatorWithOneParameterAsync<T, TFirst, TResult> When<TResult>(Func<T, TFirst, Task<TResult>> actAsync)
        {
            return new ValidatorWithOneParameterAsync<T, TFirst, TResult>(Arrange, ArrangeFirstParameter, actAsync);
        }

        #endregion
    }
}