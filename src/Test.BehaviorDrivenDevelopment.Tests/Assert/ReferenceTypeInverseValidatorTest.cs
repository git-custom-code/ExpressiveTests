namespace CustomCode.Test.BehaviorDrivenDevelopment.Tests
{
    using System;
    using Xunit;
    using Xunit.Sdk;

    /// <summary>
    /// Test cases for the <see cref="ReferenceTypeInverseValidator{T}"/> type.
    /// </summary>
    [UnitTest]
    [Category("Assert", "ReferenceTypeValidation")]
    public sealed class ReferenceTypeInverseValidatorTest
    {
        #region ReferenceType.BeNull()

        [Fact(DisplayName = "((object)o).NotBeNull()")]
        public void ValidateReferenceTypeNotToBeNull()
        {
            // Given
            var validator = new ReferenceTypeInverseValidator<object>(new object());

            // When
            validator.BeNull();

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "((object)null).NotBeNull()")]
        public void ValidateReferenceTypeNotToBeNullViolated()
        {
            // Given
            var validator = new ReferenceTypeInverseValidator<object>(null);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeNull());

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is null{rn}but was expected not to be null",
                exception.UserMessage);
        }

        [Fact(DisplayName = "((object)null).NotBeNull(reason)")]
        public void ValidateReferenceTypeNotToBeNullWithReasonViolated()
        {
            // Given
            var validator = new ReferenceTypeInverseValidator<object>(null);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeNull("that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is null{rn}but was expected not to be null{rn}because that's the bottom line",
                exception.UserMessage);
        }

        #endregion

        #region ReferenceType.BeOfType()

        [Fact(DisplayName = "((object)o).NotBeOfType<T>()")]
        public void ValidateReferenceTypeNotToBeOfType()
        {
            // Given
            var validator = new ReferenceTypeInverseValidator<object>(42);

            // When
            validator.BeOfType<String>();

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "((object)o).NotBeOfType<TOther>()")]
        public void ValidateReferenceTypeNotToBeOfTypeViolated()
        {
            // Given
            var validator = new ReferenceTypeInverseValidator<object>(42);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeOfType<Int32>());

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"Int32\"{rn}but was expected not to be of that type",
                exception.UserMessage);
        }

        [Fact(DisplayName = "((object)o).NotBeOfType<TOther>(reason)")]
        public void ValidateReferenceTypeNotToBeOfTypeWithReasonViolated()
        {
            // Given
            var validator = new ReferenceTypeInverseValidator<object>(42);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeOfType<Int32>("that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"Int32\"{rn}but was expected not to be of that type{rn}because that's the bottom line",
                exception.UserMessage);
        }

        #endregion
    }
}