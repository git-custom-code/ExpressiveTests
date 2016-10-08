namespace ExpressiveTests.Mock
{
    using System;
    using Telerik.JustMock.AutoMock;

    /// <summary>
    /// Executes a (void) method on an instance of type <typeparamref name="T"/>
    /// and executes any number assertions on the type's instance.
    /// </summary>
    /// <typeparam name="T"> The type under test. </typeparam>
    public sealed class Validator<T> where T : class
    {
        #region Dependencies

        /// <summary>
        /// Standard ctor.
        /// </summary>
        /// <param name="arrange">
        /// A delegate that is used to create a new instance of the type under test along with the needed mocks.
        /// </param>
        /// <param name="act"> A delegate that executes the (void) method under test. </param>
        public Validator(Action<MockingContainer<T>> arrange, Action<T> act)
        {
            Arrange = arrange;
            Act = act;
        }

        /// <summary>
        /// A delegate that is used to create a new instance of the type under test along with the needed mocks.
        /// </summary>
        private Action<MockingContainer<T>> Arrange { get; }

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
            var mocks = new MockingContainer<T>();
            Arrange(mocks);
            var typeUnderTest = mocks.Instance;
            Act(typeUnderTest);
            assert(typeUnderTest);
            mocks.AssertAll();
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
            var mocks = new MockingContainer<T>();
            Arrange(mocks);
            var typeUnderTest = mocks.Instance;
            try
            {
                Act(typeUnderTest);
            }
            catch (E expectedException)
            {
                assert(expectedException);
            }
            finally
            {
                mocks.AssertAll();
            }
        }

        #endregion
    }
}