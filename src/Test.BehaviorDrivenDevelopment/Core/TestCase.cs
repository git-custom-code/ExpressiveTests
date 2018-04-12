namespace CustomCode.Test.BehaviorDrivenDevelopment
{
    using System;

    /// <summary>
    /// Base class that can be used for unit-, integration- or smoketests to allow
    /// a "given-when-then" style fluent api.
    /// </summary>
    public abstract class TestCase
    {
        #region Logic

        /// <summary>
        /// Use this overload if you want to write a test for a type constructor and therefore don't need
        /// to arrange anything.
        /// </summary>
        /// <returns>
        /// An <see cref="Executor"/> that can be used to create a new instance of a type under test
        /// (for testing type constructors).
        /// </returns>
        public Executor Given()
        {
            return new Executor();
        }

        /// <summary>
        /// Creates a new instance of type <typeparamref name="T"/> (to be tested).
        /// </summary>
        /// <typeparam name="T"> The type under test. </typeparam>
        /// <param name="arrange"> A delegate that creates the type under test. </param>
        /// <returns>
        /// An <see cref="Executor{T}"/> that can be used to execute a method (to be tested)
        /// on an instance of type <typeparamref name="T"/>.
        /// </returns>
        public Executor<T> Given<T>(Func<T> arrange)
        {
            return new Executor<T>(arrange);
        }

        /// <summary>
        /// Creates a new instance of type <typeparamref name="T"/> (to be tested) whose dependencies are replaced
        /// with mock objects (using <see cref="Moq.Mock"/> and <see cref="LightInject.ServiceContainer"/>).
        /// </summary>
        /// <typeparam name="T"> The type under test. </typeparam>
        /// <returns>
        /// An <see cref="ExecutorWithMocks{T}"/> that can be used to arrange mock objects and/or execute a method
        /// (to be tested) on an instance of type <typeparamref name="T"/>.
        /// </returns>
        public ExecutorWithMocks<T> Given<T>()
        {
            return new ExecutorWithMocks<T>(null);
        }

        #endregion
    }
}