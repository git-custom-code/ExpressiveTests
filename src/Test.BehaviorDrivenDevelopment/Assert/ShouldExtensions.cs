namespace CustomCode.Test.BehaviorDrivenDevelopment
{
    /// <summary>
    /// Extension methods for defining assertions on various data types.
    /// </summary>
    public static class ShouldExtensions
    {
        #region Logic

        /// <summary>
        /// Assertions for the <see cref="string"/> data type.
        /// </summary>
        /// <param name="string"> The string value to be checked. </param>
        /// <returns> A <see cref="StringValidator"/> for specifying assertions. </returns>
        public static StringValidator Should(this string @string)
        {
            return new StringValidator(@string);
        }

        /// <summary>
        /// Inverse assertions for the <see cref="string"/> data type.
        /// </summary>
        /// <param name="string"> The string value to be checked. </param>
        /// <returns> A <see cref="StringInverseValidator"/> for specifying inverse assertions. </returns>
        public static StringInverseValidator ShouldNot(this string @string)
        {
            return new StringInverseValidator(@string);
        }

        #endregion
    }
}