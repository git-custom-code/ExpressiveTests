namespace CustomCode.Test.BehaviorDrivenDevelopment
{
    /// <summary>
    /// Extension methods for defining assertions on various data types.
    /// </summary>
    public static class ShouldExtensions
    {
        #region Logic

        /// <summary>
        /// Assertions for the <see cref="int"/> data type.
        /// </summary>
        /// <param name="integer"> The integer value to be checked. </param>
        /// <returns> A <see cref="IntValidator"/> for specifying assertions. </returns>
        public static IntValidator Should(this int integer)
        {
            return new IntValidator(integer);
        }

        /// <summary>
        /// Inverse assertions for the <see cref="int"/> data type.
        /// </summary>
        /// <param name="integer"> The integer value to be checked. </param>
        /// <returns> A <see cref="IntInverseValidator"/> for specifying inverse assertions. </returns>
        public static IntInverseValidator ShouldNot(this int integer)
        {
            return new IntInverseValidator(integer);
        }

        /// <summary>
        /// Assertions for nullable data types.
        /// </summary>
        /// <param name="nullable"> The nullable value to be checked. </param>
        /// <returns> A <see cref="NullableValidator{T}"/> for specifying assertions. </returns>
        public static NullableValidator<T> Should<T>(this T? nullable) where T : struct
        {
            return new NullableValidator<T>(nullable);
        }

        /// <summary>
        /// Inverse assertions for nullable data types.
        /// </summary>
        /// <param name="@referenceType"> The nullable value to be checked. </param>
        /// <returns> A <see cref="NullableInverseValidator{T}"/> for specifying inverse assertions. </returns>
        public static NullableInverseValidator<T> ShouldNot<T>(this T? nullable) where T : struct
        {
            return new NullableInverseValidator<T>(nullable);
        }

        /// <summary>
        /// Assertions for reference data types.
        /// </summary>
        /// <param name="@referenceType"> The reference type value to be checked. </param>
        /// <returns> A <see cref="ReferenceTypeValidator{T}"/> for specifying assertions. </returns>
        public static ReferenceTypeValidator<T> Should<T>(this T referenceType) where T : class
        {
            return new ReferenceTypeValidator<T>(referenceType);
        }

        /// <summary>
        /// Inverse assertions for reference data types.
        /// </summary>
        /// <param name="@referenceType"> The reference type value to be checked. </param>
        /// <returns> A <see cref="ReferenceTypeInverseValidator{T}"/> for specifying inverse assertions. </returns>
        public static ReferenceTypeInverseValidator<T> ShouldNot<T>(this T referenceType) where T : class
        {
            return new ReferenceTypeInverseValidator<T>(referenceType);
        }

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