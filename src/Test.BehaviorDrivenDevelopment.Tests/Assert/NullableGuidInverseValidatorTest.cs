namespace CustomCode.Test.BehaviorDrivenDevelopment.Tests
{
    using System;
    using Xunit;
    using Xunit.Sdk;

    /// <summary>
    /// Test cases for the <see cref="NullableGuidInverseValidator"/> type.
    /// </summary>
    [UnitTest]
    [Category("Assert", "GuidValidation")]
    public sealed class NullableGuidInverseValidatorTest
    {
        #region guid?.NotBe()

        [Fact(DisplayName = "guid?.NotBe(other)")]
        public void ValidateGuidNotToBeValue()
        {
            // Given
            var validator = new NullableGuidInverseValidator(Guid.NewGuid());

            // When
            validator.Be(Guid.Empty);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "guid?.NotBe(null)")]
        public void ValidateGuidNotToBeNull()
        {

            // Given
            var validator = new NullableGuidInverseValidator(Guid.NewGuid());

            // When
            validator.Be(null);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "guid?.NotBe(guid?)")]
        public void ValidateGuidNotToBeValueViolated()
        {
            // Given
            var validator = new NullableGuidInverseValidator(Guid.Empty);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.Be(Guid.Empty, "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"{Guid.Empty}\"{rn}but was expected not to be \"{Guid.Empty}\"{rn}because that's the bottom line",
                exception.UserMessage);
        }

        #endregion

        #region guid?.NotBeEmpty()

        [Fact(DisplayName = "guid?.NotBeEmpty()")]
        public void ValidateGuidNotToBeEmpty()
        {
            // Given
            var validator = new NullableGuidInverseValidator(Guid.NewGuid());

            // When
            validator.BeEmpty();

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "guid?.NotBeEmpty()")]
        public void ValidateGuidNotToBeEmptyViolated()
        {
            // Given
            var validator = new NullableGuidInverseValidator(Guid.Empty);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeEmpty(because: "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"{Guid.Empty}\"{rn}but was expected not to be empty{rn}because that's the bottom line",
                exception.UserMessage);
        }

        #endregion
        
        #region guid?.BeNull()

        [Fact(DisplayName = "guid?.NotBeNull()")]
        public void ValidateNullableNotToBeNull()
        {
            // Given
            var validator = new NullableGuidInverseValidator(Guid.Empty);

            // When
            validator.BeNull();

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "guid?.NotBeNull(reason)")]
        public void ValidateNullableNotToBeNullWithReasonViolated()
        {
            // Given
            var validator = new NullableGuidInverseValidator(null);

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

        #region guid?.NotBeNullOrEmpty()

        [Fact(DisplayName = "guid?.NotBeNullOrEmpty()")]
        public void ValidateGuidNotToBeNullOrEmpty()
        {
            // Given
            var validator = new NullableGuidInverseValidator(Guid.NewGuid());

            // When
            validator.BeNullOrEmpty();

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "guid?.NotBeNullOrEmpty()")]
        public void ValidateGuidNotToBeNullOrEmptyViolated()
        {
            // Given
            var validator = new NullableGuidInverseValidator(null);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeNullOrEmpty(because: "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"\"{rn}but was expected not to be null or empty{rn}because that's the bottom line",
                exception.UserMessage);
        }

        [Fact(DisplayName = "guid?.NotBeNullOrEmpty()")]
        public void ValidateEmptyGuidNotToBeNullOrEmptyViolated()
        {
            // Given
            var validator = new NullableGuidInverseValidator(Guid.Empty);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeNullOrEmpty(because: "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is \"{Guid.Empty}\"{rn}but was expected not to be null or empty{rn}because that's the bottom line",
                exception.UserMessage);
        }

        #endregion

    }
}