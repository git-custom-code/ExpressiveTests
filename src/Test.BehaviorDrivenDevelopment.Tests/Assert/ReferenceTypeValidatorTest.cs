namespace CustomCode.Test.BehaviorDrivenDevelopment.Tests
{
    using System;
    using Xunit;
    using Xunit.Sdk;

    /// <summary>
    /// Test cases for the <see cref="ReferenceTypeValidator{T}"/> type.
    /// </summary>
    [UnitTest]
    [Category("Assert", "ReferenceTypeValidation")]
    public sealed class ReferenceTypeValidatorTest
    {
        #region ReferenceType.BeNull()

        [Fact(DisplayName = "((object)null).BeNull()")]
        public void ValidateReferenceTypeToBeNull()
        {
            // Given
            var validator = new ReferenceTypeValidator<object>(null);

            // When
            validator.BeNull();

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "((object)o).BeNull()")]
        public void ValidateReferenceTypeToBeNullViolated()
        {
            // Given
            var validator = new ReferenceTypeValidator<object>(new object());

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeNull());

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"System.Object\"{rn}but was expected to be null",
                exception.UserMessage);
        }

        [Fact(DisplayName = "((object)o).BeNull(reason)")]
        public void ValidateReferenceTypeToBeNullWithReasonViolated()
        {
            // Given
            var validator = new ReferenceTypeValidator<object>(new object());

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeNull("that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"System.Object\"{rn}but was expected to be null{rn}because that's the bottom line",
                exception.UserMessage);
        }

        #endregion
    }
}