namespace CustomCode.Test.BehaviorDrivenDevelopment
{
    using Composition;
    using LightInject;
    using System;

    /// <summary>
    /// Define any number of assertions on a method result of type <typeparamref name="TResult"/>.
    /// </summary>
    /// <typeparam name="T"> The type under test. </typeparam>
    /// <typeparam name="TResult"> The type of the result of the method under test. </typeparam>
    public sealed class ValidatorWithMocks<T, TResult> : IFluentInterface where T : class
    {
        #region Dependencies

        /// <summary>
        /// Create a new instance of type <see cref="ValidatorWithMocks{T, TResult}"/>.
        /// </summary>
        /// <param name="act"> A delegate that executes the (non-void) method under test. </param>
        public ValidatorWithMocks(Func<T, TResult> act)
        {
            Act = act ?? throw new ArgumentNullException(nameof(act), "Act delegate cannot be null.");
        }

        /// <summary>
        /// Gets a delegate that executes the (non-void) method under test.
        /// </summary>
        private Func<T, TResult> Act { get; }

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
                var instanciatedMocks = container.RegisterWithMocks(typeof(T));
                var typeUnderTest = container.GetInstance<T>();

                // when
                var result = Act(typeUnderTest);

                // then
                assert(result);
                foreach(var mock in instanciatedMocks)
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

        #endregion
    }
}