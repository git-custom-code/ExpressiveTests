namespace CustomCode.Test.BehaviorDrivenDevelopment
{
    using System;
    //using Telerik.JustMock.AutoMock;

    /// <summary>
    /// Base class that can be used for unit-, integration- or smoketests to allow
    /// a "given-when-then" style fluent api.
    /// </summary>
    public abstract class TestCase
    {
        #region Logic

        public MockExecutor<T> Given<T>() where T : class
        {
            return new MockExecutor<T>();
        }


        /*
        /// <summary>
        /// Initialize the test pipeline without needing to arrange anything.
        /// </summary>
        /// <returns>
        /// An <see cref="Executor"/> that can be used to execute a static method (to be tested)
        /// or to test the creation of a type.
        /// </returns>
        public Executor Given()
        {
            return new Executor();
        }*/

        /*
        /// <summary>
        /// Chain the <paramref name="arrange"/> delegate to the pipeline, that is used to create
        /// a new instance of the type under test.
        /// </summary>
        /// <param name="arrange">
        /// A delegate that is used to create a new instance of the type under test.
        /// </param>
        /// <returns>
        /// An <see cref="Executor{T}"/> that can be used to execute a method (to be tested) on an
        /// instance of type <typeparamref name="T"/>.
        /// </returns>
        public Executor<T> Given<T>(Func<T> arrange) where T : class
        {
            Contract.Requires(arrange != null);

            return new Executor<T>(arrange);
        }*/

        /*
        /// <summary>
        /// Chain the <paramref name="arrange"/> delegate to the pipeline, that is used to create
        /// a new instance of the type under test along with the needed mocks.
        /// </summary>
        /// <param name="arrange">
        /// A delegate that is used to create a new instance of the type under test along with the needed mocks.
        /// </param>
        /// <returns>
        /// An <see cref="Mock.Executor{T}"/> that can be used to execute a method (to be tested) on an
        /// instance of type <typeparamref name="T"/>.
        /// </returns>
        public Mock.Executor<T> Given<T>(Action<MockingContainer<T>> arrange) where T : class
        {
            Contract.Requires(arrange != null);

            return new Mock.Executor<T>(arrange);
        }*/

        #endregion
    }
}