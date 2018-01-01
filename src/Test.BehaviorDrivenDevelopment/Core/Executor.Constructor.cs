namespace CustomCode.Test.BehaviorDrivenDevelopment
{
    using System;

    /// <summary>
    /// Executes a constructor (to be tested) of a type.
    /// </summary>
    public struct Executor : IFluentInterface
    {
        #region Logic

        /// <summary>
        /// Define the constructor under test via the <paramref name="act"/> delegate.
        /// </summary>
        /// <param name="act"> A delegate that executes the constructor under test. </param>
        /// <returns>
        /// A <see cref="ValidatorForConstructor{T}"/> that can be used to execute any number of assertions
        /// on the type under test.
        /// </returns>
        public ValidatorForConstructor<T> When<T>(Func<T> act) where T : class
        {
            return new ValidatorForConstructor<T>(act);
        }

        #endregion
    }
}