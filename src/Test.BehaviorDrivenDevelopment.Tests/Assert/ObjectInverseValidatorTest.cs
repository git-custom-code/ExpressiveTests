namespace CustomCode.Test.BehaviorDrivenDevelopment.Tests
{
    using System;
    using Xunit;
    using Xunit.Sdk;

    /// <summary>
    /// Test cases for the <see cref="ObjectInverseValidator"/> type.
    /// </summary>
    [UnitTest]
    [Category("Assert", "ObjectValidation")]
    public sealed class ObjectInverseValidatorTest
    {
        #region Object.BeNull()

        [Fact(DisplayName = "((object)o).NotBeNull()")]
        public void ValidateObjectNotToBeNull()
        {
            // Given
            var validator = new ObjectInverseValidator(new object());

            // When
            validator.BeNull();

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "((object)null).NotBeNull()")]
        public void ValidateObjectNotToBeNullViolated()
        {
            // Given
            var validator = new ObjectInverseValidator(null);

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
        public void ValidateObjectNotToBeNullWithReasonViolated()
        {
            // Given
            var validator = new ObjectInverseValidator(null);

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

        #region Object.BeOfType()

        [Fact(DisplayName = "((object)o).NotBeOfType<T>()")]
        public void ValidateObjectNotToBeOfType()
        {
            // Given
            var validator = new ObjectInverseValidator(42);

            // When
            validator.BeOfType<String>();

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "((object)o).NotBeOfType<TOther>()")]
        public void ValidateObjectNotToBeOfTypeViolated()
        {
            // Given
            var validator = new ObjectInverseValidator(42);

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
        public void ValidateObjectNotToBeOfTypeWithReasonViolated()
        {
            // Given
            var validator = new ObjectInverseValidator(42);

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