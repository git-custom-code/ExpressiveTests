namespace CustomCode.Test.BehaviorDrivenDevelopment
{
    /// <summary>
    /// Extension methods for defining assertions on various data types.
    /// </summary>
    public static class ShouldExtensions
    {
        #region Logic

        #region bool

        /// <summary>
        /// Assertions for the <see cref="bool"/> data type.
        /// </summary>
        /// <param name="boolean"> The boolean value to be checked. </param>
        /// <returns> A <see cref="BoolValidator"/> for specifying assertions. </returns>
        public static BoolValidator Should(this bool boolean)
        {
            return new BoolValidator(boolean);
        }

        /// <summary>
        /// Inverse assertions for the <see cref="bool"/> data type.
        /// </summary>
        /// <param name="boolean"> The boolean value to be checked. </param>
        /// <returns> A <see cref="BoolInverseValidator"/> for specifying inverse assertions. </returns>
        public static BoolInverseValidator ShouldNot(this bool boolean)
        {
            return new BoolInverseValidator(boolean);
        }

        #endregion

        #region byte

        /// <summary>
        /// Assertions for the <see cref="byte"/> data type.
        /// </summary>
        /// <param name="byte"> The byte value to be checked. </param>
        /// <returns> A <see cref="ByteValidator"/> for specifying assertions. </returns>
        public static ByteValidator Should(this byte @byte)
        {
            return new ByteValidator(@byte);
        }

        /// <summary>
        /// Inverse assertions for the <see cref="byte"/> data type.
        /// </summary>
        /// <param name="byte"> The byte value to be checked. </param>
        /// <returns> A <see cref="ByteInverseValidator"/> for specifying inverse assertions. </returns>
        public static ByteInverseValidator ShouldNot(this byte @byte)
        {
            return new ByteInverseValidator(@byte);
        }

        #endregion

        #region int

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

        #endregion

        #region long

        /// <summary>
        /// Assertions for the <see cref="long"/> data type.
        /// </summary>
        /// <param name="long"> The long value to be checked. </param>
        /// <returns> A <see cref="LongValidator"/> for specifying assertions. </returns>
        public static LongValidator Should(this long @long)
        {
            return new LongValidator(@long);
        }

        /// <summary>
        /// Inverse assertions for the <see cref="long"/> data type.
        /// </summary>
        /// <param name="long"> The long value to be checked. </param>
        /// <returns> A <see cref="LongInverseValidator"/> for specifying inverse assertions. </returns>
        public static LongInverseValidator ShouldNot(this long @long)
        {
            return new LongInverseValidator(@long);
        }

        #endregion

        #region nullable

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
        /// <param name="nullable"> The nullable value to be checked. </param>
        /// <returns> A <see cref="NullableInverseValidator{T}"/> for specifying inverse assertions. </returns>
        public static NullableInverseValidator<T> ShouldNot<T>(this T? nullable) where T : struct
        {
            return new NullableInverseValidator<T>(nullable);
        }

        #endregion

        #region reference type

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

        #endregion

        #region sbyte

        /// <summary>
        /// Assertions for the <see cref="sbyte"/> data type.
        /// </summary>
        /// <param name="byte"> The signed byte value to be checked. </param>
        /// <returns> A <see cref="SbyteValidator"/> for specifying assertions. </returns>
        public static SbyteValidator Should(this sbyte @byte)
        {
            return new SbyteValidator(@byte);
        }

        /// <summary>
        /// Inverse assertions for the <see cref="sbyte"/> data type.
        /// </summary>
        /// <param name="byte"> The signed byte value to be checked. </param>
        /// <returns> A <see cref="SbyteInverseValidator"/> for specifying inverse assertions. </returns>
        public static SbyteInverseValidator ShouldNot(this sbyte @byte)
        {
            return new SbyteInverseValidator(@byte);
        }

        #endregion

        #region short

        /// <summary>
        /// Assertions for the <see cref="short"/> data type.
        /// </summary>
        /// <param name="short"> The short value to be checked. </param>
        /// <returns> A <see cref="ShortValidator"/> for specifying assertions. </returns>
        public static ShortValidator Should(this short @short)
        {
            return new ShortValidator(@short);
        }

        /// <summary>
        /// Inverse assertions for the <see cref="short"/> data type.
        /// </summary>
        /// <param name="short"> The short value to be checked. </param>
        /// <returns> A <see cref="ShortInverseValidator"/> for specifying inverse assertions. </returns>
        public static ShortInverseValidator ShouldNot(this short @short)
        {
            return new ShortInverseValidator(@short);
        }

        #endregion

        #region string

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

        #region uint

        /// <summary>
        /// Assertions for the <see cref="uint"/> data type.
        /// </summary>
        /// <param name="int"> The unsigned integer value to be checked. </param>
        /// <returns> A <see cref="UintValidator"/> for specifying assertions. </returns>
        public static UintValidator Should(this uint @int)
        {
            return new UintValidator(@int);
        }

        /// <summary>
        /// Inverse assertions for the <see cref="uint"/> data type.
        /// </summary>
        /// <param name="int"> The unsigned integer value to be checked. </param>
        /// <returns> A <see cref="UintInverseValidator"/> for specifying inverse assertions. </returns>
        public static UintInverseValidator ShouldNot(this uint @int)
        {
            return new UintInverseValidator(@int);
        }

        #endregion

        #region ushort

        /// <summary>
        /// Assertions for the <see cref="ushort"/> data type.
        /// </summary>
        /// <param name="short"> The unsigned short value to be checked. </param>
        /// <returns> A <see cref="UshortValidator"/> for specifying assertions. </returns>
        public static UshortValidator Should(this ushort @short)
        {
            return new UshortValidator(@short);
        }

        /// <summary>
        /// Inverse assertions for the <see cref="ushort"/> data type.
        /// </summary>
        /// <param name="short"> The unsigned short value to be checked. </param>
        /// <returns> A <see cref="UshortInverseValidator"/> for specifying inverse assertions. </returns>
        public static UshortInverseValidator ShouldNot(this ushort @short)
        {
            return new UshortInverseValidator(@short);
        }

        #endregion

        #endregion
    }
}