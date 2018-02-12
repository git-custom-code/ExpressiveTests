namespace CustomCode.Test.BehaviorDrivenDevelopment.Tests
{
    using System;
    using Xunit;
    using Xunit.Sdk;

    /// <summary>
    /// Test cases for the <see cref="NullableGuidValidator"/> type.
    /// </summary>
    [UnitTest]
    [Category("Assert", "GuidValidation")]
    public sealed class NullableGuidValidatorTest
    {
        #region guid?.Be()

        [Fact(DisplayName = "guid?.Be(guid?)")]
        public void ValidateGuidToBeValue()
        {
            // Given
            var validator = new NullableGuidValidator(Guid.Empty);

            // When
            validator.Be(Guid.Empty);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "guid?.Be(null)")]
        public void ValidateGuidToBeNull()
        {
            // Given
            var validator = new NullableGuidValidator(null);

            // When
            validator.Be(null);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "guid?.Be(other)")]
        public void ValidateGuidToBeValueViolated()
        {
            // Given
            var guid = Guid.NewGuid();
            var validator = new NullableGuidValidator(guid);

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

        #region guid?.BeEmpty()

        [Fact(DisplayName = "guid?.BeEmpty()")]
        public void ValidateGuidToBeEmpty()
        {
            // Given
            var validator = new NullableGuidValidator(Guid.Empty);

            // When
            validator.BeEmpty();

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "guid?.BeEmpty()")]
        public void ValidateGuidToBeEmptyViolated()
        {
            // Given
            var guid = Guid.NewGuid();
            var validator = new NullableGuidValidator(guid);

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

        #region guid?.BeNull()

        [Fact(DisplayName = "guid?.BeNull()")]
        public void ValidateNullableToBeNull()
        {
            // Given
            var validator = new NullableGuidValidator(null);

            // When
            validator.BeNull();

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "guid?.BeNull(reason)")]
        public void ValidateNullableToBeNullWithReasonViolated()
        {
            // Given
            var validator = new NullableGuidValidator(Guid.Empty);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeNull("that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"{Guid.Empty}\"{rn}but was expected to be null{rn}because that's the bottom line",
                exception.UserMessage);
        }

        #endregion

        #region guid?.BeNullOrEmpty()

        [Fact(DisplayName = "guid?.BeNullOrEmpty()")]
        public void ValidateNullableToBeNullOrEmpty()
        {
            // Given
            var validator = new NullableGuidValidator(null);

            // When
            validator.BeNullOrEmpty();

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "guid?.BeNullOrEmpty()")]
        public void ValidateEmptyNullableToBeNullOrEmpty()
        {
            // Given
            var validator = new NullableGuidValidator(Guid.Empty);

            // When
            validator.BeNullOrEmpty();

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "guid?.BeNullOrEmpty(reason)")]
        public void ValidateNullableToBeNullOrEmptyWithReasonViolated()
        {
            // Given
            var guid = Guid.NewGuid();
            var validator = new NullableGuidValidator(guid);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeNullOrEmpty("that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"{guid}\"{rn}but was expected to be null or empty{rn}because that's the bottom line",
                exception.UserMessage);
        }

        #endregion
    }
}