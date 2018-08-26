namespace CustomCode.Test.BehaviorDrivenDevelopment.Tests
{
    using System;
    using System.Collections.Generic;
    using Xunit;
    using Xunit.Sdk;

    /// <summary>
    /// Test cases for the <see cref="EnumerableValidator{T}"/> type.
    /// </summary>
    [UnitTest]
    [Category("Assert", "EnumerableValidation")]
    public sealed class EnumerableValidatorTest
    {
        #region IEnumerable.BeEmpty()

        [Fact(DisplayName = "IEnumerable.BeEmpty()")]
        public void ValidateEnumerableToBeEmpty()
        {
            // Given
            var validator = new EnumerableValidator<int>(new List<int>());

            // When
            validator.BeEmpty();

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "IEnumerable.BeEmpty()")]
        public void ValidateEnumerableToBeEmtpyViolated()
        {
            // Given
            var validator = new EnumerableValidator<int>(new List<int> { 1 });

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeEmpty("that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}contains \"1\" item(s){rn}but was expected to be empty{rn}because that's the bottom line",
                exception.UserMessage);
        }

        #endregion

        #region IEnumerable.BeNull()

        [Fact(DisplayName = "IEnumerable.BeNull()")]
        public void ValidateEnumerableToBeNull()
        {
            // Given
            var validator = new EnumerableValidator<int>(null);

            // When
            validator.BeNull();

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "IEnumerable.BeNull()")]
        public void ValidateEnumerableToBeNullViolated()
        {
            // Given
            var validator = new EnumerableValidator<int>(new List<int>());

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeNull("that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}contains \"0\" item(s){rn}but was expected to be null{rn}because that's the bottom line",
                exception.UserMessage);
        }

        #endregion

        #region IEnumerable.BeNullOrEmpty()

        [Fact(DisplayName = "IEnumerable.BeNullOrEmpty()")]
        public void ValidateEnumerableToBeNullOrEmpty()
        {
            // Given
            var validator = new EnumerableValidator<int>(null);

            // When
            validator.BeNullOrEmpty();

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "IEnumerable.BeNullOrEmpty()")]
        public void ValidateEmptyEnumerableToBeNullOrEmpty()
        {
            // Given
            var validator = new EnumerableValidator<int>(new List<int>());

            // When
            validator.BeNullOrEmpty();

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "IEnumerable.BeNullOrEmpty()")]
        public void ValidateEnumerableToBeNullOrEmtpyViolated()
        {
            // Given
            var validator = new EnumerableValidator<int>(new List<int> { 1 });

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeNullOrEmpty("that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}contains \"1\" item(s){rn}but was expected to be null or empty{rn}because that's the bottom line",
                exception.UserMessage);
        }

        #endregion

        #region IEnumerable.HaveCountGreaterThan(x)

        [Fact(DisplayName = "IEnumerable.HaveCountGreaterThan(x)")]
        public void ValidateEnumerableHaveCountGreaterThan()
        {
            // Given
            var validator = new EnumerableValidator<int>(new List<int> { 1 });

            // When
            validator.HaveCountGreaterThan(0);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "IEnumerable.HaveCountGreaterThan(x)")]
        public void ValidateEnumerableHaveCountGreaterThanViolated()
        {
            // Given
            var validator = new EnumerableValidator<int>(new List<int> { 1 });

            // When
            var exception = Assert.Throws<XunitException>(() => validator.HaveCountGreaterThan(10, "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}contains \"1\" item(s){rn}but was expected to contain more than \"10\" item(s){rn}because that's the bottom line",
                exception.UserMessage);
        }

        #endregion

        #region IEnumerable.HaveCountGreaterThanOrEqualTo(x)

        [Fact(DisplayName = "IEnumerable.HaveCountGreaterThanOrEqualTo(x)")]
        public void ValidateEnumerableHaveCountGreaterThanOrEqualTo()
        {
            // Given
            var validator = new EnumerableValidator<int>(new List<int> { 1 });

            // When
            validator.HaveCountGreaterThanOrEqualTo(1);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "IEnumerable.HaveCountGreaterThanOrEqualTo(x)")]
        public void ValidateEnumerableHaveCountGreaterThanOrEqualToViolated()
        {
            // Given
            var validator = new EnumerableValidator<int>(new List<int> { 1 });

            // When
            var exception = Assert.Throws<XunitException>(() => validator.HaveCountGreaterThanOrEqualTo(10, "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}contains \"1\" item(s){rn}but was expected to contain at least \"10\" item(s){rn}because that's the bottom line",
                exception.UserMessage);
        }

        #endregion

        #region IEnumerable.HaveCountLessThan(x)

        [Fact(DisplayName = "IEnumerable.HaveCountLessThan(x)")]
        public void ValidateEnumerableHaveCountLessThan()
        {
            // Given
            var validator = new EnumerableValidator<int>(new List<int> { 1 });

            // When
            validator.HaveCountLessThan(10);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "IEnumerable.HaveCountLessThan(x)")]
        public void ValidateEnumerableHaveCountLessThanViolated()
        {
            // Given
            var validator = new EnumerableValidator<int>(new List<int> { 1 });

            // When
            var exception = Assert.Throws<XunitException>(() => validator.HaveCountLessThan(1, "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}contains \"1\" item(s){rn}but was expected to contain less than \"1\" item(s){rn}because that's the bottom line",
                exception.UserMessage);
        }

        #endregion

        #region IEnumerable.HaveCountLessThanOrEqualTo(x)

        [Fact(DisplayName = "IEnumerable.HaveCountLessThanOrEqualTo(x)")]
        public void ValidateEnumerableHaveCountLessThanOrEqualTo()
        {
            // Given
            var validator = new EnumerableValidator<int>(new List<int> { 1 });

            // When
            validator.HaveCountLessThanOrEqualTo(10);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "IEnumerable.HaveCountLessThanOrEqualTo(x)")]
        public void ValidateEnumerableHaveCountLessThanOrEqualToViolated()
        {
            // Given
            var validator = new EnumerableValidator<int>(new List<int> { 1 });

            // When
            var exception = Assert.Throws<XunitException>(() => validator.HaveCountLessThanOrEqualTo(0, "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}contains \"1\" item(s){rn}but was expected to contain at most \"0\" item(s){rn}because that's the bottom line",
                exception.UserMessage);
        }

        #endregion

        #region IEnumerable.HaveCountOf()

        [Fact(DisplayName = "IEnumerable.HaveCountOf(x)")]
        public void ValidateEnumerableHaveCountOf()
        {
            // Given
            var validator = new EnumerableValidator<int>(new List<int> { 1 });

            // When
            validator.HaveCountOf(1);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "IEnumerable.HaveCountOf(x)")]
        public void ValidateEnumerableHaveCountOfViolated()
        {
            // Given
            var validator = new EnumerableValidator<int>(new List<int> { 1 });

            // When
            var exception = Assert.Throws<XunitException>(() => validator.HaveCountOf(0, "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}contains \"1\" item(s){rn}but was expected to have \"0\" item(s){rn}because that's the bottom line",
                exception.UserMessage);
        }

        #endregion
    }
}