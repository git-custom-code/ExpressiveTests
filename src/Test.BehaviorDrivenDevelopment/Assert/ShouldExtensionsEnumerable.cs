namespace CustomCode.Test.BehaviorDrivenDevelopment
{
    using System.Collections.Generic;

    /// <summary>
    /// Extension methods for defining assertions on <see cref="IEnumerable{T}"/> types.
    /// </summary>
    public static class ShouldExtensionsEnumerable
    {
        #region Logic

        /// <summary>
        /// Assertions for <see cref="IEnumerable{T}"/> data types.
        /// </summary>
        /// <param name="enumerable"> The enumerable value to be checked. </param>
        /// <returns> An <see cref="EnumerableValidator{T}"/> for specifying assertions. </returns>
        public static EnumerableValidator<T> Should<T>(this IEnumerable<T> enumerable)
        {
            return new EnumerableValidator<T>(enumerable);
        }

        /// <summary>
        /// Inverse assertions for <see cref="IEnumerable{T}"/> data types.
        /// </summary>
        /// <param name="enumerable"> The enumerable value to be checked. </param>
        /// <returns> An <see cref="EnumerableInverseValidator{T}"/> for specifying assertions. </returns>
        public static EnumerableInverseValidator<T> ShouldNot<T>(this IEnumerable<T> enumerable)
        {
            return new EnumerableInverseValidator<T>(enumerable);
        }

        #endregion
    }
}