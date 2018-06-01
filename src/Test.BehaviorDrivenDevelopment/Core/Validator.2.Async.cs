namespace CustomCode.Test.BehaviorDrivenDevelopment
{
    using System;
    using System.Threading.Tasks;
    using Xunit.Sdk;

    /// <summary>
    /// Define any number of assertions on an asynchronous method result of type <typeparamref name="TResult"/>.
    /// </summary>
    /// <typeparam name="T"> The type under test. </typeparam>
    /// <typeparam name="TFirst"> The type of the first parameter needed for the asynchronous method under test. </typeparam>
    /// <typeparam name="TResult"> The type of the result of the asynchronous method under test. </typeparam>
    public struct ValidatorWithOneParameterAsync<T, TFirst, TResult> : IFluentInterface
        where TFirst: class
    {
        #region Dependencies

        /// <summary>
        /// Create a new instance of the <see cref="ValidatorWithOneParameterAsync{T, TFirst, TResult}"/> type.
        /// </summary>
        /// <param name="arrange"> A delegate that creates the type under test. </param>
        /// <param name="arrangeFirstParameter"> A delegate that creates the needed first parameter instance. </param>
        /// <param name="actAsync"> A delegate that executes the asynchronous (non-void) method under test. </param>
        public ValidatorWithOneParameterAsync(
            Func<T> arrange,
            Func<TFirst> arrangeFirstParameter,
            Func<T, TFirst, Task<TResult>> actAsync)
        {
            Arrange = arrange ?? throw new XunitException($"The {nameof(arrange)} delegate cannot be null.");
            ArrangeFirstParameter = arrangeFirstParameter ?? throw new XunitException($"The {nameof(arrangeFirstParameter)} delegate cannot be null.");
            ActAsync = actAsync ?? throw new XunitException($"The {nameof(actAsync)} delegate cannot be null.");
        }

        #endregion

        #region Data

        /// <summary>
        /// Gets a delegate that executes the asynchronous (non-void) method under test.
        /// </summary>
        private Func<T, TFirst, Task<TResult>> ActAsync { get; }

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
        /// Define any number of assertions on the result of the asynchronous method under test after it was
        /// successfully executed.
        /// </summary>
        /// <param name="assert">
        /// A delegate that is used to execute any number of assertions on the result of the asynchronous method under test.
        /// </param>
        public void Then(Action<TResult> assert)
        {
            var validator = this;
            async Task ThenAsync()
            {
                try
                {
                    // given
                    var typeUnderTest = validator.Arrange();
                    var firstParameter = validator.ArrangeFirstParameter();

                    // when
                    var result = await validator.ActAsync(typeUnderTest, firstParameter);

                    // then
                    assert(result);
                }
                catch (Exception e)
                {
                    // TODO
                    throw e;
                }
            }

            Task.WaitAll(Task.Run(ThenAsync));
        }

        /// <summary>
        /// Define any number of assertions on the thrown and expected exception of the asynchronous method under test
        /// after it was executed.
        /// </summary>
        /// <typeparam name="TException"> The type of the exception that is thrown. </typeparam>
        /// <param name="assert">
        /// A delegate that is used to execute any number of assertions on the thrown exception of the asynchronous method under test.
        /// </param>
        public void ThenThrow<TException>(Action<TException> assert = null)
            where TException : Exception
        {
            var validator = this;
            async Task ThenThrowAsync()
            {
                try
                {
                    // given
                    var typeUnderTest = validator.Arrange();
                    var firstParameter = validator.ArrangeFirstParameter();

                    // when
                    try
                    {
                        await validator.ActAsync(typeUnderTest, firstParameter);

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

            Task.WaitAll(Task.Run(ThenThrowAsync));
        }

        #endregion
    }
}