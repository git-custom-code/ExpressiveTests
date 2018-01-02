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