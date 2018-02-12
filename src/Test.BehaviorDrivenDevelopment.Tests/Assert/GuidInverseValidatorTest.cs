namespace CustomCode.Test.BehaviorDrivenDevelopment.Tests
{
    using System;
    using Xunit;
    using Xunit.Sdk;

    /// <summary>
    /// Test cases for the <see cref="GuidInverseValidator"/> type.
    /// </summary>
    [UnitTest]
    [Category("Assert", "GuidValidation")]
    public sealed class GuidInverseValidatorTest
    {
        #region guid.NotBe()

        [Fact(DisplayName = "guid.NotBe(other)")]
        public void ValidateGuidNotToBeValue()
        {
            // Given
            var validator = new GuidInverseValidator(Guid.NewGuid());

            // When
            validator.Be(Guid.Empty);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "guid.NotBe(guid)")]
        public void ValidateGuidNotToBeValueViolated()
        {
            // Given
            var validator = new GuidInverseValidator(Guid.Empty);

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

        #region guid.NotBeEmpty()

        [Fact(DisplayName = "guid.NotBeEmpty()")]
        public void ValidateGuidNotToBeEmpty()
        {
            // Given
            var validator = new GuidInverseValidator(Guid.NewGuid());

            // When
            validator.BeEmpty();

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "guid.NotBeEmpty()")]
        public void ValidateGuidNotToBeEmptyViolated()
        {
            // Given
            var validator = new GuidInverseValidator(Guid.Empty);

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
    }
}