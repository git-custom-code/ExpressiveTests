namespace ExpressiveTests
{
    using System;
    using System.Diagnostics.Contracts;

    /// <summary>
    /// Executes a static method or a delegate that creates a type.
    /// </summary>
    public sealed class Executor
    {
        #region Logic

        /// <summary>
        /// Chain the <paramref name="act"/> delegate to the pipeline, that is used to execute
        /// a static method (to be tested) or that creates a type (if testing constructor logic).
        /// </summary>
        /// <param name="act">
        /// A delegate that executes a static method (to be tested) or that creates a type
        /// (if testing constructor logic).
        /// </param>
        /// <returns>
        /// A <see cref="Act.Validator{T}"/> that can be used to execute any number of assertions
        /// on the result of the <paramref name="act"/> delegate.
        /// </returns>
        public Act.Validator<T> When<T>(Func<T> act)
        {
            Contract.Requires(act != null);

            return new Act.Validator<T>(act);
        }

        #endregion
    }
}