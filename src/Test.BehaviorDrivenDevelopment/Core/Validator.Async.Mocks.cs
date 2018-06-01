namespace CustomCode.Test.BehaviorDrivenDevelopment
{
    using Extensions;
    using LightInject;
    using Moq;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Xunit.Sdk;

    /// <summary>
    /// Define any number of assertions on a method result of type <typeparamref name="TResult"/>.
    /// </summary>
    /// <typeparam name="T"> The type under test. </typeparam>
    /// <typeparam name="TResult"> The type of the result of the asynchronous method under test. </typeparam>
    public struct ValidatorAsyncWithMocks<T, TResult> : IFluentInterface
    {
        #region Dependencies

        /// <summary>
        /// Create a new instance of the <see cref="ValidatorAsyncWithMocks{T, TResult}"/> type.
        /// </summary>
        /// <param name="actAsync"> A delegate that executes the asynchronous (non-void) method under test. </param>
        /// <param name="arrangements">
        /// A collection of arrangements that should be applied to instanciated mock objects.
        /// </param>
        public ValidatorAsyncWithMocks(Func<T, Task<TResult>> actAsync, IDictionary<Type, List<Action<Mock>>> arrangements)
        {
            ActAsync = actAsync ?? throw new ArgumentNullException(nameof(actAsync), "Act delegate cannot be null.");
            Arrangements = arrangements ?? new Dictionary<Type, List<Action<Mock>>>();
        }

        #endregion

        #region Data

        /// <summary>
        /// Gets a delegate that executes the asynchronous (non-void) method under test.
        /// </summary>
        private Func<T, Task<TResult>> ActAsync { get; }

        /// <summary>
        /// Gets a collection of arrangements that should be applied to instanciated mock objects.
        /// </summary>
        private IDictionary<Type, List<Action<Mock>>> Arrangements { get; }

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
                    var container = new ServiceContainer();
                    var instanciatedMocks = container.RegisterWithMocks(typeof(T), validator.Arrangements);
                    var typeUnderTest = container.GetInstance<T>();

                    // when
                    var result = await validator.ActAsync(typeUnderTest);

                    // then
                    assert(result);
                    foreach (var mock in instanciatedMocks)
                    {
                        mock.VerifyAll();
                    }
                }
                catch (Exception e)
                {
                    throw e;
                    // TODO
                }
            }

            Task.WaitAll(Task.Run(ThenAsync));
        }

        /// <summary>
        /// Define any number of assertions on the thrown and expected exception of the asnychronous method under test
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
                    var container = new ServiceContainer();
                    var instanciatedMocks = container.RegisterWithMocks(typeof(T), validator.Arrangements);
                    var typeUnderTest = container.GetInstance<T>();

                    // when
                    try
                    {
                        await validator.ActAsync(typeUnderTest);

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
                    finally
                    {
                        foreach (var mock in instanciatedMocks)
                        {
                            mock.VerifyAll();
                        }
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