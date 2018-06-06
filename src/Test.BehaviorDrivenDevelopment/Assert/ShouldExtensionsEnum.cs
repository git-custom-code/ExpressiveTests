namespace CustomCode.Test.BehaviorDrivenDevelopment
{
    using System;

    /// <summary>
    /// Extension methods for defining assertions on enum types.
    /// </summary>
    /// <remarks>
    /// Note that those will require c# 7.3 language version in order to work.
    /// </remarks>
    public static class ShouldExtensionsEnum
    {
        #region Logic

        /// <summary>
        /// Assertions for <see cref="Enum"/> data types.
        /// </summary>
        /// <param name="enum"> The enumeration value to be checked. </param>
        /// <returns> A <see cref="EnumValidator{T}"/> for specifying assertions. </returns>
        /// <remarks>
        /// Note that those will require c# 7.3 language version in order to work.
        /// </remarks>
        public static EnumValidator<T> Should<T>(this T @enum)
            where T : Enum
        {
            return new EnumValidator<T>(@enum);
        }

        /// <summary>
        /// Inverse assertions for <see cref="Enum"/> data types.
        /// </summary>
        /// <param name="enum"> The enumeration value to be checked. </param>
        /// <returns> A <see cref="EnumInverseValidator{T}"/> for specifying inverse assertions. </returns>
        /// <remarks>
        /// Note that those will require c# 7.3 language version in order to work.
        /// </remarks>
        public static EnumInverseValidator<T> ShouldNot<T>(this T @enum)
            where T : Enum
        {
            return new EnumInverseValidator<T>(@enum);
        }

        #endregion
    }
}