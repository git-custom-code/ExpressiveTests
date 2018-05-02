namespace CustomCode.Test.BehaviorDrivenDevelopment
{
    using System;
    using System.Threading.Tasks;
    using Xunit.Sdk;

    /// <summary>
    /// Define any number of assertions on an instance of type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T"> The type under test. </typeparam>
    /// <typeparam name="TFirst"> The type of the first parameter needed for the asynchronous method under test. </typeparam>
    public struct ValidatorWithOneParameterAsync<T, TFirst> : IFluentInterface
        where TFirst : class
    {
        #region Dependencies

        /// <summary>
        /// Creates a new instance of the <see cref="ValidatorWithOneParameterAsync{T, TFirst}"/> type.
        /// </summary>
        /// <param name="arrange"> A delegate that creates the type under test. </param>
        /// <param name="arrangeFirstParameter"> A delegate that creates the needed first parameter instance. </param>
        /// <param name="actAsync"> A delegate that executes the asynchronous (void) method under test. </param>
        public ValidatorWithOneParameterAsync(
            Func<T> arrange,
            Func<TFirst> arrangeFirstParameter,
            Func<T, TFirst, Task> actAsync)
        {
            Arrange = arrange ?? throw new XunitException($"The {nameof(arrange)} delegate cannot be null.");
            ArrangeFirstParameter = arrangeFirstParameter ?? throw new XunitException($"The {nameof(arrangeFirstParameter)} delegate cannot be null.");
            ActAsync = actAsync ?? throw new XunitException($"The {nameof(actAsync)} delegate cannot be null.");
        }

        #endregion

        #region Data

        /// <summary>
        /// Gets a delegate that executes the asynchronous (void) method under test.
        /// </summary>
        private Func<T, TFirst, Task> ActAsync { get; }

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
        /// Define any number of assertions on the type under test after the asynchronous method under test was
        /// successfully executed.
        /// </summary>
        /// <param name="assert">
        /// A delegate that is used to execute any number of assertions on the type under test.
        /// </param>
        public async void Then(Action<T> assert)
        {
            try
            {
                // given
                var typeUnderTest = Arrange();
                var firstParameter = ArrangeFirstParameter();

                // when
                await ActAsync(typeUnderTest, firstParameter);

                // then
                assert(typeUnderTest);
            }
            catch (Exception e)
            {
                // TODO
                throw e;
            }
        }

        /// <summary>
        /// Define any number of assertions on the thrown and expected exception of the  asynchronous method under test
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
                var firstParameter = ArrangeFirstParameter();

                // when
                try
                {
                    await ActAsync(typeUnderTest, firstParameter);

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