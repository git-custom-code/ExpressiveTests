namespace CustomCode.Test.BehaviorDrivenDevelopment.Tests
{
    using System;
    using Xunit;
    using Xunit.Sdk;

    /// <summary>
    /// Test cases for the <see cref="GuidValidator"/> type.
    /// </summary>
    [UnitTest]
    [Category("Assert", "GuidValidation")]
    public sealed class GuidValidatorTest
    {
        #region guid.Be()

        [Fact(DisplayName = "guid.Be(guid)")]
        public void ValidateGuidToBeValue()
        {
            // Given
            var validator = new GuidValidator(Guid.Empty);

            // When
            validator.Be(Guid.Empty);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "guid.Be(other)")]
        public void ValidateGuidToBeValueViolated()
        {
            // Given
            var guid = Guid.NewGuid();
            var validator = new GuidValidator(guid);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.Be(Guid.Empty, "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"{guid}\"{rn}but was expected to be \"{Guid.Empty}\"{rn}because that's the bottom line",
                exception.UserMessage);
        }

        #endregion

        #region guid.BeEmpty()

        [Fact(DisplayName = "guid.BeEmpty()")]
        public void ValidateGuidToBeEmpty()
        {
            // Given
            var validator = new GuidValidator(Guid.Empty);

            // When
            validator.BeEmpty();

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "guid.BeEmpty()")]
        public void ValidateGuidToBeEmptyViolated()
        {
            // Given
            var guid = Guid.NewGuid();
            var validator = new GuidValidator(guid);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeEmpty(because: "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"{guid}\"{rn}but was expected to be empty{rn}because that's the bottom line",
                exception.UserMessage);
        }

        #endregion
    }
}