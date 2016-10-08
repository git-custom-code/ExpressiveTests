namespace ExpressiveTests.Mock
{
    using System;
    using Telerik.JustMock.AutoMock;

    /// <summary>
    /// Executes a (non-void) method on an instance of type <typeparamref name="T"/>
    /// and executes any number assertions on the method's result.
    /// </summary>
    /// <typeparam name="T"> The type under test. </typeparam>
    /// <typeparam name="R"> The type of the result from the method under test. </typeparam>
    public sealed class Validator<T, R> where T : class
    {
        #region Dependencies

        /// <summary>
        /// Standard ctor.
        /// </summary>
        /// <param name="arrange">
        /// A delegate that is used to create a new instance of the type under test along with the needed mocks.
        /// </param>
        /// <param name="act"> A delegate that executes the (non-void) method under test. </param>
        public Validator(Action<MockingContainer<T>> arrange, Func<T, R> act)
        {
            Arrange = arrange;
            Act = act;
        }

        /// <summary>
        /// A delegate that is used to create a new instance of the type under test along with the needed mocks.
        /// </summary>
        private Action<MockingContainer<T>> Arrange { get; }

        /// <summary>
        /// A delegate that executes the (non-void) method under test.
        /// </summary>
        private Func<T, R> Act { get; }

        #endregion

        #region Logic

        /// <summary>
        /// Chain the <paramref name="assert"/> delegate to the pipeline, that is used to execute
        /// any number of assertions on the type under test.
        /// </summary>
        /// <param name="assert">
        /// A delegate that is used to execute any number of assertions on the type under test.
        /// </param>
        public void Then(Action<R> assert)
        {
            var mocks = new MockingContainer<T>();
            Arrange(mocks);
            var typeUnderTest = mocks.Instance;
            var result = Act(typeUnderTest);
            assert(result);
            mocks.AssertAll();
        }

        /// <summary>
        /// Chain the <paramref name="assert"/> delegate to the pipeline, that is used to execute
        /// any number of assertions on the type under test.
        /// </summary>
        /// <param name="assert">
        /// A delegate that is used to execute any number of assertions on the type under test as well
        /// as on the result of the method under test.
        /// </param>
        public void Then(Action<T, R> assert)
        {
            var mocks = new MockingContainer<T>();
            Arrange(mocks);
            var typeUnderTest = mocks.Instance;
            var result = Act(typeUnderTest);
            assert(typeUnderTest, result);
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