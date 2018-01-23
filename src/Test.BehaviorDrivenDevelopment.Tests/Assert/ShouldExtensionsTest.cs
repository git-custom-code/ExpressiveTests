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
    }
}