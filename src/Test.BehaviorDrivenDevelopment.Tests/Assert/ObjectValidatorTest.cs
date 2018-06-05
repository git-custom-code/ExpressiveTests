namespace CustomCode.Test.BehaviorDrivenDevelopment.Tests
{
    using System;
    using Xunit;
    using Xunit.Sdk;

    /// <summary>
    /// Test cases for the <see cref="ObjectValidator"/> type.
    /// </summary>
    [UnitTest]
    [Category("Assert", "ObjectValidation")]
    public sealed class ObjectValidatorTest
    {
        #region Object.BeNull()

        [Fact(DisplayName = "((object)null).BeNull()")]
        public void ValidateObjectToBeNull()
        {
            // Given
            var validator = new ObjectValidator(null);

            // When
            validator.BeNull();

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "((object)o).BeNull()")]
        public void ValidateObjectToBeNullViolated()
        {
            // Given
            var validator = new ObjectValidator(new object());

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
        public void ValidateObjectToBeNullWithReasonViolated()
        {
            // Given
            var validator = new ObjectValidator(new object());

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

        #region Object.BeOfType()

        [Fact(DisplayName = "((object)o).BeOfType<T>()")]
        public void ValidateObjectToBeOfType()
        {
            // Given
            var validator = new ObjectValidator(42);

            // When
            validator.BeOfType<Int32>();

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "((object)o).BeOfType<TOther>()")]
        public void ValidateObjectToBeOfTypeViolated()
        {
            // Given
            var validator = new ObjectValidator(42);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeOfType<String>());

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"Int32\"{rn}but was expected to be of type \"String\"",
                exception.UserMessage);
        }

        [Fact(DisplayName = "((object)o).BeOfType<TOther>(reason)")]
        public void ValidateObjectToBeOfTypeWithReasonViolated()
        {
            // Given
            var validator = new ObjectValidator(42);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeOfType<String>("that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"Int32\"{rn}but was expected to be of type \"String\"{rn}because that's the bottom line",
                exception.UserMessage);
        }

        #endregion
    }
}