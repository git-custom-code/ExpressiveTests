namespace CustomCode.Test.BehaviorDrivenDevelopment.Tests
{
    using System;
    using System.Collections.Generic;
    using Xunit;
    using Xunit.Sdk;

    /// <summary>
    /// Test cases for the <see cref="EnumerableInverseValidator{T}"/> type.
    /// </summary>
    [UnitTest]
    [Category("Assert", "EnumerableValidation")]
    public sealed class EnumerableInversValidatorTest
    {
        #region IEnumerable.NotBeEmpty()

        [Fact(DisplayName = "IEnumerable.NotBeEmpty()")]
        public void ValidateEnumerableNotToBeEmpty()
        {
            // Given
            var validator = new EnumerableInverseValidator<int>(new List<int> { 1 });

            // When
            validator.BeEmpty();

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "IEnumerable.NotBeEmpty()")]
        public void ValidateEnumerableToBeEmtpyViolated()
        {
            // Given
            var validator = new EnumerableInverseValidator<int>(new List<int>());

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeEmpty("that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}contains \"0\" item(s){rn}but was expected not to be empty{rn}because that's the bottom line",
                exception.UserMessage);
        }

        #endregion

        #region IEnumerable.NotBeNull()

        [Fact(DisplayName = "IEnumerable.NotBeNull()")]
        public void ValidateEnumerableNotToBeNull()
        {
            // Given
            var validator = new EnumerableInverseValidator<int>(new List<int>());

            // When
            validator.BeNull();

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "IEnumerable.NotBeNull()")]
        public void ValidateEnumerableNotToBeNullViolated()
        {
            // Given
            var validator = new EnumerableInverseValidator<int>(null);

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

        #region IEnumerable.NotBeNullOrEmpty()

        [Fact(DisplayName = "IEnumerable.NotBeNullOrEmpty()")]
        public void ValidateEnumerableNotToBeNullOrEmpty()
        {
            // Given
            var validator = new EnumerableInverseValidator<int>(new List<int> { 1 });

            // When
            validator.BeNullOrEmpty();

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "IEnumerable.NotBeNullOrEmpty()")]
        public void ValidateEmptyEnumerableNotToBeNullOrEmpty()
        {
            // Given
            var validator = new EnumerableInverseValidator<int>(new List<int>());

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeNullOrEmpty("that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is null or empty{rn}but was expected not to be null or empty{rn}because that's the bottom line",
                exception.UserMessage);
        }

        [Fact(DisplayName = "IEnumerable.BeNullOrEmpty()")]
        public void ValidateEnumerableToBeNullOrEmtpyViolated()
        {
            // Given
            var validator = new EnumerableInverseValidator<int>(null);

            // When
            var exception = Assert.Throws<XunitException>(() => validator.BeNullOrEmpty("that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}is null or empty{rn}but was expected not to be null or empty{rn}because that's the bottom line",
                exception.UserMessage);
        }

        #endregion

        #region IEnumerable.NotHaveCountGreaterThan(x)

        [Fact(DisplayName = "IEnumerable.NotHaveCountGreaterThan(x)")]
        public void ValidateEnumerableNotHaveCountGreaterThan()
        {
            // Given
            var validator = new EnumerableInverseValidator<int>(new List<int>());

            // When
            validator.HaveCountGreaterThan(10);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "IEnumerable.NotHaveCountGreaterThan(x)")]
        public void ValidateEnumerableNotHaveCountGreaterThanViolated()
        {
            // Given
            var validator = new EnumerableInverseValidator<int>(new List<int> { 1, 2, 3 });

            // When
            var exception = Assert.Throws<XunitException>(() => validator.HaveCountGreaterThan(1, "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}contains \"3\" item(s){rn}but was expected not to contain more than \"1\" item(s){rn}because that's the bottom line",
                exception.UserMessage);
        }

        #endregion

        #region IEnumerable.NotHaveCountGreaterThanOrEqualTo(x)

        [Fact(DisplayName = "IEnumerable.NotHaveCountGreaterThanOrEqualTo(x)")]
        public void ValidateEnumerableNotHaveCountGreaterThanOrEqualTo()
        {
            // Given
            var validator = new EnumerableInverseValidator<int>(new List<int>());

            // When
            validator.HaveCountGreaterThanOrEqualTo(1);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "IEnumerable.NotHaveCountGreaterThanOrEqualTo(x)")]
        public void ValidateEnumerableNotHaveCountGreaterThanOrEqualToViolated()
        {
            // Given
            var validator = new EnumerableInverseValidator<int>(new List<int> { 1, 2, 3 });

            // When
            var exception = Assert.Throws<XunitException>(() => validator.HaveCountGreaterThanOrEqualTo(1, "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}contains \"3\" item(s){rn}but was expected not to contain more than or equal to \"1\" item(s){rn}because that's the bottom line",
                exception.UserMessage);
        }

        #endregion

        #region IEnumerable.NotHaveCountLessThan(x)

        [Fact(DisplayName = "IEnumerable.NotHaveCountLessThan(x)")]
        public void ValidateEnumerableNotHaveCountLessThan()
        {
            // Given
            var validator = new EnumerableInverseValidator<int>(new List<int> { 1, 2 ,3 });

            // When
            validator.HaveCountLessThan(1);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "IEnumerable.NotHaveCountLessThan(x)")]
        public void ValidateEnumerableNotHaveCountLessThanViolated()
        {
            // Given
            var validator = new EnumerableInverseValidator<int>(new List<int> { 1 });

            // When
            var exception = Assert.Throws<XunitException>(() => validator.HaveCountLessThan(10, "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}contains \"1\" item(s){rn}but was expected not to contain less than \"10\" item(s){rn}because that's the bottom line",
                exception.UserMessage);
        }

        #endregion

        #region IEnumerable.NotHaveCountLessThanOrEqualTo(x)

        [Fact(DisplayName = "IEnumerable.NotHaveCountLessThanOrEqualTo(x)")]
        public void ValidateEnumerableNotHaveCountLessThanOrEqualTo()
        {
            // Given
            var validator = new EnumerableInverseValidator<int>(new List<int> { 1, 2, 3 });

            // When
            validator.HaveCountLessThanOrEqualTo(1);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "IEnumerable.NotHaveCountLessThanOrEqualTo(x)")]
        public void ValidateEnumerableNotHaveCountLessThanOrEqualToViolated()
        {
            // Given
            var validator = new EnumerableInverseValidator<int>(new List<int> { 1 });

            // When
            var exception = Assert.Throws<XunitException>(() => validator.HaveCountLessThanOrEqualTo(10, "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}contains \"1\" item(s){rn}but was expected not to contain less than or equal to \"10\" item(s){rn}because that's the bottom line",
                exception.UserMessage);
        }

        #endregion

        #region IEnumerable.NotHaveCountOf()

        [Fact(DisplayName = "IEnumerable.NotHaveCountOf(x)")]
        public void ValidateEnumerableNotHaveCountOf()
        {
            // Given
            var validator = new EnumerableInverseValidator<int>(new List<int> { 1 });

            // When
            validator.HaveCountOf(2);

            // Then
            Assert.True(true);
        }

        [Fact(DisplayName = "IEnumerable.NotHaveCountOf(x)")]
        public void ValidateEnumerableNotHaveCountOfViolated()
        {
            // Given
            var validator = new EnumerableInverseValidator<int>(new List<int> { 1 });

            // When
            var exception = Assert.Throws<XunitException>(() => validator.HaveCountOf(1, "that's the bottom line"));

            // Then
            Assert.NotNull(exception);
            var rn = Environment.NewLine;
            Assert.Equal(
                $"{rn}validator{rn}contains \"1\" item(s){rn}but was expected not to have \"1\" item(s){rn}because that's the bottom line",
                exception.UserMessage);
        }

        #endregion
    }
}