namespace CustomCode.Test.BehaviorDrivenDevelopment.Tests
{
    using Xunit;

    /// <summary>
    /// Test cases for the <see cref="ShouldExtensions"/> type.
    /// </summary>
    [UnitTest]
    [Category("Assert")]
    public sealed class ShouldExtensionsTest
    {
        #region bool

        [Fact(DisplayName = "bool.Should()")]
        [Category("Should")]
        public void UseShouldExtensionWithBooleans()
        {
            // Given
            var boolean = true;

            // When
            var validator = boolean.Should();

            // Then
            Assert.IsType<BoolValidator>(validator);
        }

        [Fact(DisplayName = "bool.ShouldNot()")]
        [Category("ShouldNot")]
        public void UseShouldNotExtensionWithBooleans()
        {
            // Given
            var boolean = true;

            // When
            var validator = boolean.ShouldNot();

            // Then
            Assert.IsType<BoolInverseValidator>(validator);
        }

        #endregion

        #region byte

        [Fact(DisplayName = "byte.Should()")]
        [Category("Should")]
        public void UseShouldExtensionWithBytes()
        {
            // Given
            byte @byte = 42;

            // When
            var validator = @byte.Should();

            // Then
            Assert.IsType<ByteValidator>(validator);
        }

        [Fact(DisplayName = "byte.ShouldNot()")]
        [Category("ShouldNot")]
        public void UseShouldNotExtensionWithBytes()
        {
            // Given
            byte @byte = 42;

            // When
            var validator = @byte.ShouldNot();

            // Then
            Assert.IsType<ByteInverseValidator>(validator);
        }

        #endregion

        #region int

        [Fact(DisplayName = "int.Should()")]
        [Category("Should")]
        public void UseShouldExtensionWithIntegers()
        {
            // Given
            var integer = 42;

            // When
            var validator = integer.Should();

            // Then
            Assert.IsType<IntValidator>(validator);
        }

        [Fact(DisplayName = "int.ShouldNot()")]
        [Category("ShouldNot")]
        public void UseShouldNotExtensionWithIntegers()
        {
            // Given
            var integer = 42;

            // When
            var validator = integer.ShouldNot();

            // Then
            Assert.IsType<IntInverseValidator>(validator);
        }

        #endregion

        #region long

        [Fact(DisplayName = "long.Should()")]
        [Category("Should")]
        public void UseShouldExtensionWithLongs()
        {
            // Given
            long @long = 42;

            // When
            var validator = @long.Should();

            // Then
            Assert.IsType<LongValidator>(validator);
        }

        [Fact(DisplayName = "long.ShouldNot()")]
        [Category("ShouldNot")]
        public void UseShouldNotExtensionWithLongs()
        {
            // Given
            long @long = 42;

            // When
            var validator = @long.ShouldNot();

            // Then
            Assert.IsType<LongInverseValidator>(validator);
        }

        #endregion

        #region nullable

        [Fact(DisplayName = "Nullable.Should()")]
        [Category("Should")]
        public void UseShouldExtensionWithNullables()
        {
            // Given
            int? @int = null;

            // When
            var intValidator = @int.Should();

            // Then
            Assert.IsType<NullableValidator<int>>(intValidator);
        }

        [Fact(DisplayName = "Nullable.ShouldNot()")]
        [Category("ShouldNot")]
        public void UseShouldNotExtensionWithNullables()
        {
            // Given
            int? @int = null;

            // When
            var intValidator = @int.ShouldNot();

            // Then
            Assert.IsType<NullableInverseValidator<int>>(intValidator);
        }

        #endregion

        #region reference types

        [Fact(DisplayName = "ReferenceType.Should()")]
        [Category("Should")]
        public void UseShouldExtensionWithReferenceTypes()
        {
            // Given
            var @object = new object();
            var @string = "string";

            // When
            var objectValidator = @object.Should();
            var stringValidator = @string.Should<string>();

            // Then
            Assert.IsType<ReferenceTypeValidator<object>>(objectValidator);
            Assert.IsType<ReferenceTypeValidator<string>>(stringValidator);
        }

        [Fact(DisplayName = "ReferenceType.ShouldNot()")]
        [Category("ShouldNot")]
        public void UseShouldNotExtensionWithReferenceTypes()
        {
            // Given
            var @object = new object();
            var @string = "string";

            // When
            var objectValidator = @object.ShouldNot();
            var stringValidator = @string.ShouldNot<string>();

            // Then
            Assert.IsType<ReferenceTypeInverseValidator<object>>(objectValidator);
            Assert.IsType<ReferenceTypeInverseValidator<string>>(stringValidator);
        }

        #endregion

        #region sbyte

        [Fact(DisplayName = "sbyte.Should()")]
        [Category("Should")]
        public void UseShouldExtensionWithSBytes()
        {
            // Given
            sbyte @byte = 42;

            // When
            var validator = @byte.Should();

            // Then
            Assert.IsType<SbyteValidator>(validator);
        }

        [Fact(DisplayName = "sbyte.ShouldNot()")]
        [Category("ShouldNot")]
        public void UseShouldNotExtensionWithSBytes()
        {
            // Given
            sbyte @byte = 42;

            // When
            var validator = @byte.ShouldNot();

            // Then
            Assert.IsType<SbyteInverseValidator>(validator);
        }

        #endregion

        #region short

        [Fact(DisplayName = "short.Should()")]
        [Category("Should")]
        public void UseShouldExtensionWithShorts()
        {
            // Given
            short @short = 42;

            // When
            var validator = @short.Should();

            // Then
            Assert.IsType<ShortValidator>(validator);
        }

        [Fact(DisplayName = "short.ShouldNot()")]
        [Category("ShouldNot")]
        public void UseShouldNotExtensionWithShorts()
        {
            // Given
            short @short = 42;

            // When
            var validator = @short.ShouldNot();

            // Then
            Assert.IsType<ShortInverseValidator>(validator);
        }

        #endregion

        #region string

        [Fact(DisplayName = "string.Should()")]
        [Category("Should")]
        public void UseShouldExtensionWithStrings()
        {
            // Given
            var @string = "string";

            // When
            var validator = @string.Should();

            // Then
            Assert.IsType<StringValidator>(validator);
        }

        [Fact(DisplayName = "string.ShouldNot()")]
        [Category("ShouldNot")]
        public void UseShouldNotExtensionWithStrings()
        {
            // Given
            var @string = "string";

            // When
            var validator = @string.ShouldNot();

            // Then
            Assert.IsType<StringInverseValidator>(validator);
        }

        #endregion

        #region uint

        [Fact(DisplayName = "uint.Should()")]
        [Category("Should")]
        public void UseShouldExtensionWithUInts()
        {
            // Given
            uint @int = 42;

            // When
            var validator = @int.Should();

            // Then
            Assert.IsType<UintValidator>(validator);
        }

        [Fact(DisplayName = "uint.ShouldNot()")]
        [Category("ShouldNot")]
        public void UseShouldNotExtensionWithUInts()
        {
            // Given
            uint @int = 42;

            // When
            var validator = @int.ShouldNot();

            // Then
            Assert.IsType<UintInverseValidator>(validator);
        }

        #endregion

        #region ushort

        [Fact(DisplayName = "ushort.Should()")]
        [Category("Should")]
        public void UseShouldExtensionWithUShorts()
        {
            // Given
            ushort @short = 42;

            // When
            var validator = @short.Should();

            // Then
            Assert.IsType<UshortValidator>(validator);
        }

        [Fact(DisplayName = "ushort.ShouldNot()")]
        [Category("ShouldNot")]
        public void UseShouldNotExtensionWithUShorts()
        {
            // Given
            ushort @short = 42;

            // When
            var validator = @short.ShouldNot();

            // Then
            Assert.IsType<UshortInverseValidator>(validator);
        }

        #endregion
    }
}