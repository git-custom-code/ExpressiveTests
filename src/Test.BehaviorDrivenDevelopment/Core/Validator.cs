namespace CustomCode.Test.BehaviorDrivenDevelopment
{
    using System;
    using Xunit.Sdk;

    /// <summary>
    /// Define any number of assertions on an instance of a created type (when testing the constructor call).
    /// </summary>
    public sealed class Validator<T> : IFluentInterface where T : class
    {
        #region Dependencies

        /// <summary>
        /// Creates a new instance of the <see cref="Validator{T}"/> type.
        /// </summary>
        /// <param name="act"> A delegate that executes the constructor under test. </param>

        public Validator(Func<T> act)
        {
            Act = act ?? throw new ArgumentNullException(nameof(act), "Act delegate cannot be null.");
        }

        #endregion

        #region Data

        /// <summary>
        /// Gets a delegate that executes the constructor under test.
        /// </summary>
        private Func<T> Act { get; }

        #endregion

        #region Logic

        /// <summary>
        /// Define any number of assertions on the instance under test after it was
        /// successfully created.
        /// </summary>
        /// <param name="assert">
        /// A delegate that is used to execute any number of assertions on the instance under test.
        /// </param>
        public void Then(Action<T> assert)
        {
            try
            {
                // given

                // when
                var typeUnderTest = Act();

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
        /// Define any number of assertions on the thrown and expected exception of the constructor under test
        /// after it was executed.
        /// </summary>
        /// <typeparam name="TException"> The type of the exception that is thrown. </typeparam>
        /// <param name="assert">
        /// A delegate that is used to execute any number of assertions on the thrown exception.
        /// </param>
        public void ThenThrow<TException>(Action<TException> assert = null)
            where TException : Exception
        {
            try
            {
                // given
                
                // when
                try
                {
                    Act();

                    var rn = Environment.NewLine;
                    var message = $"{rn}Expected exception of type {typeof(TException).Name}{rn}but no exception was thrown";
                    throw new XunitException(message);
                }
                catch(XunitException)
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