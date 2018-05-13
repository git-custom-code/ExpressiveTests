namespace CustomCode.Test.BehaviorDrivenDevelopment.Enum
{
    using System;

    /// <summary>
    /// Extension methods for defining assertions on enumeration data types.
    /// </summary>
    /// <remarks>
    /// Note that those will require c# 7.3 language version in order to compile, otherwise
    /// your project will show "could nor resolve ambigious call ..." errors because of the collision
    /// with the <see cref="ReferenceTypeValidator{T}"/> extension methods that can not be resolved
    /// by previous language version compilers.
    /// Therefore those extension methods are move to a seperate namespace so the developer can decide
    /// to opt in or out.
    /// </remarks>
    public static class ShouldExtensions
    {
        #region Logic

        /// <summary>
        /// Assertions for <see cref="Enum"/> data types.
        /// </summary>
        /// <param name="enum"> The enumeration value to be checked. </param>
        /// <returns> A <see cref="EnumValidator{T}"/> for specifying assertions. </returns>
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
        public static EnumInverseValidator<T> ShouldNot<T>(this T @enum)
            where T : Enum
        {
            return new EnumInverseValidator<T>(@enum);
        }

        #endregion
    }
}