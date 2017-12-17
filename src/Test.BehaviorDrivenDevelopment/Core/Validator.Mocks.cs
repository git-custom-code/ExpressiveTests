namespace CustomCode.Test.BehaviorDrivenDevelopment
{
    using Extensions;
    using LightInject;
    using Moq;
    using System;
    using System.Collections.Generic;
    using Xunit.Sdk;

    /// <summary>
    /// Define any number of assertions on a method result of type <typeparamref name="TResult"/>.
    /// </summary>
    /// <typeparam name="T"> The type under test. </typeparam>
    /// <typeparam name="TResult"> The type of the result of the method under test. </typeparam>
    public sealed class ValidatorWithMocks<T, TResult> : IFluentInterface where T : class
    {
        #region Dependencies

        /// <summary>
        /// Create a new instance of the <see cref="ValidatorWithMocks{T, TResult}"/> type.
        /// </summary>
        /// <param name="act"> A delegate that executes the (non-void) method under test. </param>
        /// <param name="arrangements">
        /// A collection of arrangements that should be applied to instanciated mock objects.
        /// </param>
        public ValidatorWithMocks(Func<T, TResult> act, IDictionary<Type, List<Action<Mock>>> arrangements)
        {
            Act = act ?? throw new ArgumentNullException(nameof(act), "Act delegate cannot be null.");
            Arrangements = arrangements ?? new Dictionary<Type, List<Action<Mock>>>();
        }

        #endregion

        #region Data

        /// <summary>
        /// Gets a delegate that executes the (non-void) method under test.
        /// </summary>
        private Func<T, TResult> Act { get; }

        /// <summary>
        /// Gets a collection of arrangements that should be applied to instanciated mock objects.
        /// </summary>
        private IDictionary<Type, List<Action<Mock>>> Arrangements { get; }

        #endregion

        #region Logic

        /// <summary>
        /// Define any number of assertions on the result of the method under test after it was
        /// successfully executed.
        /// </summary>
        /// <param name="assert">
        /// A delegate that is used to execute any number of assertions on the result of the method under test.
        /// </param>
        public void Then(Action<TResult> assert)
        {
            try
            {
                // given
                var container = new ServiceContainer();
                var instanciatedMocks = container.RegisterWithMocks(typeof(T), Arrangements);
                var typeUnderTest = container.GetInstance<T>();

                // when
                var result = Act(typeUnderTest);

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

        /// <summary>
        /// Define any number of assertions on the thrown and expected exception of the method under test
        /// after it was executed.
        /// </summary>
        /// <typeparam name="TException"> The type of the exception that is thrown. </typeparam>
        /// <param name="assert">
        /// A delegate that is used to execute any number of assertions on the thrown exception of the method under test.
        /// </param>
        public void ThenThrow<TException>(Action<TException> assert = null)
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
                    Act(typeUnderTest);

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