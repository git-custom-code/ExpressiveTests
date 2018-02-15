namespace CustomCode.Test.BehaviorDrivenDevelopment
{
    using System;

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

        /// <summary>
        /// Assertions for the nullable <see cref="bool"/> data type.
        /// </summary>
        /// <param name="boolean"> The nullable boolean value to be checked. </param>
        /// <returns> A <see cref="NullableBoolValidator"/> for specifying assertions. </returns>
        public static NullableBoolValidator Should(this bool? boolean)
        {
            return new NullableBoolValidator(boolean);
        }

        /// <summary>
        /// Inverse assertions for the nullable <see cref="bool"/> data type.
        /// </summary>
        /// <param name="boolean"> nullable The boolean value to be checked. </param>
        /// <returns> A <see cref="NullableBoolInverseValidator"/> for specifying inverse assertions. </returns>
        public static NullableBoolInverseValidator ShouldNot(this bool? boolean)
        {
            return new NullableBoolInverseValidator(boolean);
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

        /// <summary>
        /// Assertions for the nullable <see cref="byte"/> data type.
        /// </summary>
        /// <param name="byte"> The nullable byte value to be checked. </param>
        /// <returns> A <see cref="NullableByteValidator"/> for specifying assertions. </returns>
        public static NullableByteValidator Should(this byte? @byte)
        {
            return new NullableByteValidator(@byte);
        }

        /// <summary>
        /// Inverse assertions for the nullable <see cref="byte"/> data type.
        /// </summary>
        /// <param name="byte"> The nullable byte value to be checked. </param>
        /// <returns> A <see cref="NullableByteInverseValidator"/> for specifying inverse assertions. </returns>
        public static NullableByteInverseValidator ShouldNot(this byte? @byte)
        {
            return new NullableByteInverseValidator(@byte);
        }

        #endregion

        #region decimal

        /// <summary>
        /// Assertions for the <see cref="decimal"/> data type.
        /// </summary>
        /// <param name="decimal"> The decimal value to be checked. </param>
        /// <returns> A <see cref="DecimalValidator"/> for specifying assertions. </returns>
        public static DecimalValidator Should(this decimal @decimal)
        {
            return new DecimalValidator(@decimal);
        }

        /// <summary>
        /// Inverse assertions for the <see cref="decimal"/> data type.
        /// </summary>
        /// <param name="decimal"> The decimal value to be checked. </param>
        /// <returns> A <see cref="DecimalInverseValidator"/> for specifying inverse assertions. </returns>
        public static DecimalInverseValidator ShouldNot(this decimal @decimal)
        {
            return new DecimalInverseValidator(@decimal);
        }

        #endregion

        #region double

        /// <summary>
        /// Assertions for the <see cref="double"/> data type.
        /// </summary>
        /// <param name="double"> The double value to be checked. </param>
        /// <returns> A <see cref="DoubleValidator"/> for specifying assertions. </returns>
        public static DoubleValidator Should(this double @double)
        {
            return new DoubleValidator(@double);
        }

        /// <summary>
        /// Inverse assertions for the <see cref="double"/> data type.
        /// </summary>
        /// <param name="double"> The double value to be checked. </param>
        /// <returns> A <see cref="DoubleInverseValidator"/> for specifying inverse assertions. </returns>
        public static DoubleInverseValidator ShouldNot(this double @double)
        {
            return new DoubleInverseValidator(@double);
        }

        #endregion

        #region float

        /// <summary>
        /// Assertions for the <see cref="float"/> data type.
        /// </summary>
        /// <param name="float"> The float value to be checked. </param>
        /// <returns> A <see cref="FloatValidator"/> for specifying assertions. </returns>
        public static FloatValidator Should(this float @float)
        {
            return new FloatValidator(@float);
        }

        /// <summary>
        /// Inverse assertions for the <see cref="float"/> data type.
        /// </summary>
        /// <param name="float"> The float value to be checked. </param>
        /// <returns> A <see cref="FloatInverseValidator"/> for specifying inverse assertions. </returns>
        public static FloatInverseValidator ShouldNot(this float @float)
        {
            return new FloatInverseValidator(@float);
        }

        /// <summary>
        /// Assertions for the nullable <see cref="float"/> data type.
        /// </summary>
        /// <param name="float"> The nullable float value to be checked. </param>
        /// <returns> A <see cref="NullableFloatValidator"/> for specifying assertions. </returns>
        public static NullableFloatValidator Should(this float? @float)
        {
            return new NullableFloatValidator(@float);
        }

        /// <summary>
        /// Inverse assertions for the nullable <see cref="float"/> data type.
        /// </summary>
        /// <param name="float"> The nullable float value to be checked. </param>
        /// <returns> A <see cref="NullableFloatInverseValidator"/> for specifying inverse assertions. </returns>
        public static NullableFloatInverseValidator ShouldNot(this float? @float)
        {
            return new NullableFloatInverseValidator(@float);
        }

        #endregion

        #region guid

        /// <summary>
        /// Assertions for the <see cref="Guid"/> data type.
        /// </summary>
        /// <param name="guid"> The guid to be checked. </param>
        /// <returns> A <see cref="GuidValidator"/> for specifying assertions. </returns>
        public static GuidValidator Should(this Guid guid)
        {
            return new GuidValidator(guid);
        }

        /// <summary>
        /// Inverse assertions for the <see cref="Guid"/> data type.
        /// </summary>
        /// <param name="guid"> The guid to be checked. </param>
        /// <returns> A <see cref="GuidInverseValidator"/> for specifying inverse assertions. </returns>
        public static GuidInverseValidator ShouldNot(this Guid guid)
        {
            return new GuidInverseValidator(guid);
        }

        /// <summary>
        /// Assertions for the nullable <see cref="Guid"/> data type.
        /// </summary>
        /// <param name="guid"> The nullable guid to be checked. </param>
        /// <returns> A <see cref="NullableGuidValidator"/> for specifying assertions. </returns>
        public static NullableGuidValidator Should(this Guid? guid)
        {
            return new NullableGuidValidator(guid);
        }

        /// <summary>
        /// Inverse assertions for the nullable <see cref="Guid"/> data type.
        /// </summary>
        /// <param name="guid"> The nullable guid to be checked. </param>
        /// <returns> A <see cref="NullableGuidInverseValidator"/> for specifying inverse assertions. </returns>
        public static NullableGuidInverseValidator ShouldNot(this Guid? guid)
        {
            return new NullableGuidInverseValidator(guid);
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

        /// <summary>
        /// Assertions for the nullable <see cref="int"/> data type.
        /// </summary>
        /// <param name="integer"> The nullable integer value to be checked. </param>
        /// <returns> A <see cref="NullableIntValidator"/> for specifying assertions. </returns>
        public static NullableIntValidator Should(this int? integer)
        {
            return new NullableIntValidator(integer);
        }

        /// <summary>
        /// Inverse assertions for the nullable <see cref="int"/> data type.
        /// </summary>
        /// <param name="integer"> The nullable integer value to be checked. </param>
        /// <returns> A <see cref="NullableIntInverseValidator"/> for specifying inverse assertions. </returns>
        public static NullableIntInverseValidator ShouldNot(this int? integer)
        {
            return new NullableIntInverseValidator(integer);
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

        /// <summary>
        /// Assertions for the nullable <see cref="long"/> data type.
        /// </summary>
        /// <param name="long"> The nullable long value to be checked. </param>
        /// <returns> A <see cref="NullableLongValidator"/> for specifying assertions. </returns>
        public static NullableLongValidator Should(this long? @long)
        {
            return new NullableLongValidator(@long);
        }

        /// <summary>
        /// Inverse assertions for the nullable <see cref="long"/> data type.
        /// </summary>
        /// <param name="long"> The nullable long value to be checked. </param>
        /// <returns> A <see cref="NullableLongInverseValidator"/> for specifying inverse assertions. </returns>
        public static NullableLongInverseValidator ShouldNot(this long? @long)
        {
            return new NullableLongInverseValidator(@long);
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
        /// <param name="referenceType"> The reference type value to be checked. </param>
        /// <returns> A <see cref="ReferenceTypeValidator{T}"/> for specifying assertions. </returns>
        public static ReferenceTypeValidator<T> Should<T>(this T referenceType) where T : class
        {
            return new ReferenceTypeValidator<T>(referenceType);
        }

        /// <summary>
        /// Inverse assertions for reference data types.
        /// </summary>
        /// <param name="referenceType"> The reference type value to be checked. </param>
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

        /// <summary>
        /// Assertions for the nullable <see cref="sbyte"/> data type.
        /// </summary>
        /// <param name="byte"> The nullable signed byte value to be checked. </param>
        /// <returns> A <see cref="NullableSbyteValidator"/> for specifying assertions. </returns>
        public static NullableSbyteValidator Should(this sbyte? @byte)
        {
            return new NullableSbyteValidator(@byte);
        }

        /// <summary>
        /// Inverse assertions for the nullable <see cref="sbyte"/> data type.
        /// </summary>
        /// <param name="byte"> The nullable signed byte value to be checked. </param>
        /// <returns> A <see cref="NullableSbyteInverseValidator"/> for specifying inverse assertions. </returns>
        public static NullableSbyteInverseValidator ShouldNot(this sbyte? @byte)
        {
            return new NullableSbyteInverseValidator(@byte);
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

        /// <summary>
        /// Assertions for the nullable <see cref="short"/> data type.
        /// </summary>
        /// <param name="short"> The nullable short value to be checked. </param>
        /// <returns> A <see cref="NullableShortValidator"/> for specifying assertions. </returns>
        public static NullableShortValidator Should(this short? @short)
        {
            return new NullableShortValidator(@short);
        }

        /// <summary>
        /// Inverse assertions for the nullable <see cref="short"/> data type.
        /// </summary>
        /// <param name="short"> The nullable short value to be checked. </param>
        /// <returns> A <see cref="NullableShortInverseValidator"/> for specifying inverse assertions. </returns>
        public static NullableShortInverseValidator ShouldNot(this short? @short)
        {
            return new NullableShortInverseValidator(@short);
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

        /// <summary>
        /// Assertions for the nullable <see cref="uint"/> data type.
        /// </summary>
        /// <param name="int"> The nullable unsigned integer value to be checked. </param>
        /// <returns> A <see cref="NullableUintValidator"/> for specifying assertions. </returns>
        public static NullableUintValidator Should(this uint? @int)
        {
            return new NullableUintValidator(@int);
        }

        /// <summary>
        /// Inverse assertions for the nullable <see cref="uint"/> data type.
        /// </summary>
        /// <param name="int"> The nullable unsigned integer value to be checked. </param>
        /// <returns> A <see cref="NullableUintInverseValidator"/> for specifying inverse assertions. </returns>
        public static NullableUintInverseValidator ShouldNot(this uint? @int)
        {
            return new NullableUintInverseValidator(@int);
        }

        #endregion

        #region ulong

        /// <summary>
        /// Assertions for the <see cref="ulong"/> data type.
        /// </summary>
        /// <param name="long"> The unsigned long value to be checked. </param>
        /// <returns> A <see cref="UlongValidator"/> for specifying assertions. </returns>
        public static UlongValidator Should(this ulong @long)
        {
            return new UlongValidator(@long);
        }

        /// <summary>
        /// Inverse assertions for the <see cref="ulong"/> data type.
        /// </summary>
        /// <param name="long"> The unsigned long value to be checked. </param>
        /// <returns> A <see cref="UlongInverseValidator"/> for specifying inverse assertions. </returns>
        public static UlongInverseValidator ShouldNot(this ulong @long)
        {
            return new UlongInverseValidator(@long);
        }

        /// <summary>
        /// Assertions for the nullable <see cref="ulong"/> data type.
        /// </summary>
        /// <param name="long"> The nullable unsigned long value to be checked. </param>
        /// <returns> A <see cref="NullableUlongValidator"/> for specifying assertions. </returns>
        public static NullableUlongValidator Should(this ulong? @long)
        {
            return new NullableUlongValidator(@long);
        }

        /// <summary>
        /// Inverse assertions for the nullable <see cref="ulong"/> data type.
        /// </summary>
        /// <param name="long"> The nullable unsigned long value to be checked. </param>
        /// <returns> A <see cref="NullableUlongInverseValidator"/> for specifying inverse assertions. </returns>
        public static NullableUlongInverseValidator ShouldNot(this ulong? @long)
        {
            return new NullableUlongInverseValidator(@long);
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

        /// <summary>
        /// Assertions for the nullable <see cref="ushort"/> data type.
        /// </summary>
        /// <param name="short"> The nullable unsigned short value to be checked. </param>
        /// <returns> A <see cref="NullableUshortValidator"/> for specifying assertions. </returns>
        public static NullableUshortValidator Should(this ushort? @short)
        {
            return new NullableUshortValidator(@short);
        }

        /// <summary>
        /// Inverse assertions for the nullable <see cref="ushort"/> data type.
        /// </summary>
        /// <param name="short"> The nullable unsigned short value to be checked. </param>
        /// <returns> A <see cref="NullableUshortInverseValidator"/> for specifying inverse assertions. </returns>
        public static NullableUshortInverseValidator ShouldNot(this ushort? @short)
        {
            return new NullableUshortInverseValidator(@short);
        }

        #endregion

        #endregion
    }
}