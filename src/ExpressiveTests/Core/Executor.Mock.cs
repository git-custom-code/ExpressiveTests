namespace ExpressiveTests.Mock
{
    using System;
    using System.Diagnostics.Contracts;
    using Telerik.JustMock.AutoMock;

    /// <summary>
    /// Executes a method (to be tested) on an instance of type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T"> The type to be tested. </typeparam>
    public sealed class Executor<T> where T : class
    {
        #region Dependencies

        /// <summary>
        /// Standard ctor.
        /// </summary>
        /// <param name="arrange">
        /// A delegate that is used to create a new instance of the type under test along with the needed mocks.
        /// </param>
        public Executor(Action<MockingContainer<T>> arrange)
        {
            Contract.Requires(arrange != null);
            Contract.Requires(typeof(T).IsClass);

            Arrange = arrange;
        }

        /// <summary>
        /// A delegate that is used to create a new instance of the type under test along with the needed mocks.
        /// </summary>
        private Action<MockingContainer<T>> Arrange { get; }

        #endregion

        #region Logic

        /// <summary>
        /// Chain the <paramref name="act"/> delegate to the pipeline, that is used to execute
        /// the (void) method under test.
        /// </summary>
        /// <param name="act"> A delegate that executes the (void) method under test. </param>
        /// <returns>
        /// A <see cref="Mock.Validator{T}"/> that can be used to execute any number of assertions
        /// on the type under test.
        /// </returns>
        public Mock.Validator<T> When(Action<T> act)
        {
            Contract.Requires(act != null);

            return new Mock.Validator<T>(Arrange, act);
        }

        /// <summary>
        /// Chain the <paramref name="act"/> delegate to the pipeline, that is used to execute
        /// the (non-void) method under test.
        /// </summary>
        /// <typeparam name="R"> The type of the result from the method under test. </typeparam>
        /// <param name="act"> A delegate that executes the (non-void) method under test. </param>
        /// <returns>
        /// A <see cref="Mock.Validator{T, R}"/> that can be used to execute any number of assertions
        /// on the type under test as well as on the result of the method under test.
        /// </returns>
        public Mock.Validator<T, R> When<R>(Func<T, R> act)
        {
            return new Mock.Validator<T, R>(Arrange, act);
        }

        #endregion
    }
}