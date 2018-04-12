namespace CustomCode.Test.BehaviorDrivenDevelopment
{
    using System;
    using System.Threading.Tasks;
    using Xunit.Sdk;

    /// <summary>
    /// Define any number of assertions on a method result of type <typeparamref name="TResult"/>.
    /// </summary>
    /// <typeparam name="T"> The type under test. </typeparam>
    /// <typeparam name="TResult"> The type of the result of the asynchronous method under test. </typeparam>
    public struct ValidatorAsync<T, TResult> : IFluentInterface
    {
        #region Dependencies

        /// <summary>
        /// Create a new instance of the <see cref="ValidatorAsync{T, TResult}"/> type.
        /// </summary>
        /// <param name="arrange"> A delegate that creates the type under test. </param>
        /// <param name="actAsync"> A delegate that executes the asynchronous (non-void) method under test. </param>
        public ValidatorAsync(Func<T> arrange, Func<T, Task<TResult>> actAsync)
        {
            Arrange = arrange ?? throw new XunitException($"The {nameof(arrange)} delegate cannot be null.");
            ActAsync = actAsync ?? throw new XunitException($"The {nameof(actAsync)} delegate cannot be null.");
        }

        #endregion

        #region Data

        /// <summary>
        /// Gets a delegate that executes the asynchronous (non-void) method under test.
        /// </summary>
        private Func<T, Task<TResult>> ActAsync { get; }

        /// <summary>
        /// Gets a delegate that creates the type under test.
        /// </summary>
        private Func<T> Arrange { get; }

        #endregion

        #region Logic

        /// <summary>
        /// Define any number of assertions on the result of the method under test after it was
        /// successfully executed.
        /// </summary>
        /// <param name="assert">
        /// A delegate that is used to execute any number of assertions on the result of the method under test.
        /// </param>
        public async void Then(Action<TResult> assert)
        {
            try
            {
                // given
                var typeUnderTest = Arrange();

                // when
                var result = await ActAsync(typeUnderTest);

                // then
                assert(result);
            }
            catch (Exception e)
            {
                // TODO
                throw e;
            }
        }

        /// <summary>
        /// Define any number of assertions on the thrown and expected exception of the method under test
        /// after it was executed.
        /// </summary>
        /// <typeparam name="TException"> The type of the exception that is thrown. </typeparam>
        /// <param name="assert">
        /// A delegate that is used to execute any number of assertions on the thrown exception of the method under test.
        /// </param>
        public async void ThenThrow<TException>(Action<TException> assert = null)
            where TException : Exception
        {
            try
            {
                // given
                var typeUnderTest = Arrange();

                // when
                try
                {
                    await ActAsync(typeUnderTest);

                    var rn = Environment.NewLine;
                    var message = $"{rn}Expected exception of type {typeof(TException).Name}{rn}but no exception was thrown";
                    throw new XunitException(message);
                }
                catch (XunitException)
                {
                    throw;
                }
                catch (TException exception)
                {
                    // then
                    assert?.Invoke(exception);
                }
                catch (Exception exception)
                {
                    var rn = Environment.NewLine;
                    var message = $"{rn}Expected exception of type {typeof(TException).Name}{rn}but instead caught {exception.GetType().Name}";
                    throw new XunitException(message);
                }
            }
            catch (XunitException)
            {
                throw;
            }
            catch (Exception e)
            {
                // TODO
                throw e;
            }
        }

        #endregion
    }
}