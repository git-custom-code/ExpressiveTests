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
    /// Define any number of assertions on an instance of type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T"> The type under test. </typeparam>
    public struct ValidatorAsyncWithMocks<T> : IFluentInterface
    {
        #region Dependencies

        /// <summary>
        /// Create a new instance of the <see cref="ValidatorAsyncWithMocks{T}"/> type.
        /// </summary>
        /// <param name="actAsync"> A delegate that executes the asynchronous (void) method under test. </param>
        /// <param name="arrangements">
        /// A collection of arrangements that should be applied to instanciated mock objects.
        /// </param>
        public ValidatorAsyncWithMocks(Func<T, Task> actAsync, IDictionary<Type, List<Action<Mock>>> arrangements)
        {
            ActAsync = actAsync ?? throw new ArgumentNullException(nameof(actAsync), "Act delegate cannot be null.");
            Arrangements = arrangements ?? new Dictionary<Type, List<Action<Mock>>>();
        }

        #endregion

        #region Data

        /// <summary>
        /// Gets a delegate that executes the asynchronous (void) method under test.
        /// </summary>
        private Func<T, Task> ActAsync { get; }

        /// <summary>
        /// Gets a collection of arrangements that should be applied to instanciated mock objects.
        /// </summary>
        private IDictionary<Type, List<Action<Mock>>> Arrangements { get; }

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
                var container = new ServiceContainer();
                var instanciatedMocks = container.RegisterWithMocks(typeof(T), Arrangements);
                var typeUnderTest = container.GetInstance<T>();

                // when
                await ActAsync(typeUnderTest);

                // then
                assert(typeUnderTest);
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

        /// <summary>
        /// Define any number of assertions on the thrown and expected exception of the asynchronous method under test
        /// after it was executed.
        /// </summary>
        /// <typeparam name="TException"> The type of the exception that is thrown. </typeparam>
        /// <param name="assert">
        /// A delegate that is used to execute any number of assertions on the thrown exception of the asynchronous method under test.
        /// </param>
        public async void ThenThrow<TException>(Action<TException> assert = null)
            where TException : Exception
        {
            try
            {
                // given
                var container = new ServiceContainer();
                var instanciatedMocks = container.RegisterWithMocks(typeof(T), Arrangements);
                var typeUnderTest = container.GetInstance<T>();

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

        #endregion
    }
}