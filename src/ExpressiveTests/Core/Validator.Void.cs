namespace ExpressiveTests
{
    using System;
    using System.Diagnostics.Contracts;

    /// <summary>
    /// Executes a (void) method on an instance of type <typeparamref name="T"/>
    /// and executes any number assertions on the type's instance.
    /// </summary>
    /// <typeparam name="T"> The type under test. </typeparam>
    public sealed class Validator<T>
    {
        #region Dependencies

        /// <summary>
        /// Standard ctor.
        /// </summary>
        /// <param name="arrange"> A delegate that creates a new instance of the type under test. </param>
        /// <param name="act"> A delegate that executes the (void) method under test. </param>
        public Validator(Func<T> arrange, Action<T> act)
        {
            Contract.Requires(arrange != null);
            Contract.Requires(act != null);

            Arrange = arrange;
            Act = act;
        }

        /// <summary>
        /// A delegate that creates a new instance of the type under test.
        /// </summary>
        private Func<T> Arrange { get; }

        /// <summary>
        /// A delegate that executes the (void) method under test.
        /// </summary>
        private Action<T> Act { get; }

        #endregion

        #region Logic

        /// <summary>
        /// Chain the <paramref name="assert"/> delegate to the pipeline, that is used to execute
        /// any number of assertions on the type under test.
        /// </summary>
        /// <param name="assert">
        /// A delegate that is used to execute any number of assertions on the type under test.
        /// </param>
        public void Then(Action<T> assert)
        {
            var typeUnderTest = Arrange();
            Act(typeUnderTest);
            assert(typeUnderTest);
        }

        /// <summary>
        /// Chain the <paramref name="assert"/> delegate to the pipeline, that is invoked when
        /// an expected exception of type <typeparamref name="E"/> was raised during the
        /// pipeline's act step.
        /// </summary>
        /// <typeparam name="E"> The type of the expected exception. </typeparam>
        /// <param name="assert">
        /// A delegate that is invoked when an expected exception of type <typeparamref name="E"/>
        /// was raised during the pipeline's act step.
        /// </param>
        public void ThenThrow<E>(Action<E> assert) where E : Exception
        {
            var typeUnderTest = Arrange();
            try
            {
                Act(typeUnderTest);
            }
            catch (E expectedException)
            {
                assert(expectedException);
            }
        }

        #endregion
    }
}