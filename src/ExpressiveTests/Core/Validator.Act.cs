namespace ExpressiveTests.Act
{
    using System;
    using System.Diagnostics.Contracts;

    /// <summary>
    /// Executes a static method (to be tested) or creates a type (if testing constructor logic).
    /// </summary>
    /// <typeparam name="T"> The result's type that can be used to execute assertions on. </typeparam>
    public sealed class Validator<T>
    {
        #region Dependencies

        /// <summary>
        /// Standard ctor.
        /// </summary>
        /// <param name="act">
        /// A delegate that executes a static method (to be tested) or that creates a type
        /// (if testing constructor logic).
        /// </param>
        public Validator(Func<T> act)
        {
            Contract.Requires(act != null);

            Act = act;
        }

        /// <summary>
        /// A delegate that executes a static method (to be tested) or that creates a type
        /// (if testing constructor logic).
        /// </summary>
        private Func<T> Act { get; }

        #endregion

        #region Logic

        /// <summary>
        /// Chain the <paramref name="assert"/> delegate to the pipeline, that is used to execute
        /// any number of assertions on the result of the method under test.
        /// </summary>
        /// <param name="assert">
        /// A delegate that is used to execute any number of assertions on the result of the
        /// method under test.
        /// </param>
        public void Then(Action<T> assert)
        {
            var result = Act();
            assert(result);
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
            try
            {
                Act();
            }
            catch (E expectedException)
            {
                assert(expectedException);
            }
        }

        #endregion
    }
}