﻿namespace CustomCode.Test.BehaviorDrivenDevelopment.Configuration.Tests
{
    using System.Runtime.CompilerServices;
    using Xunit;

    /// <summary>
    /// Test cases for the <see cref="RoslynCallerContext"/> type.
    /// </summary>
    /// <remarks>
    /// Carefully when changing line numbers inside of this file, because the integration test depends on it!
    /// </remarks>
    [UnitTest]
    [Category("Configuration")]
    public sealed class RoslynCallerContextTest : TestCase
    {
        #region Mockup

        /// <summary>
        /// Dummy method that simulates a failed test whose caller context should be extracted.
        /// </summary>
        private void TestCallerContextForShouldWithOneParameterAndWithoutReason()
        {
            Given()
            .When(() => new string(new char[] { 'f', 'o', 'o' }))
            .Then(@string => @string.Should().Be("bar"));
        }

        /// <summary>
        /// Dummy method that simulates a failed test whose caller context should be extracted.
        /// </summary>
        private void TestCallerContextForShouldWithOneParameterAndWithReason()
        {
            Given()
            .When(() => new string(new char[] { 'f', 'o', 'o' }))
            .Then(@string => @string.Should().Be("bar", because: "that's the bottom line"));
        }

        /// <summary>
        /// Dummy method that simulates a failed test whose caller context should be extracted.
        /// </summary>
        private void TestCallerContextForShouldWithoutParameterAndWithoutReason()
        {
            Given()
            .When(() => new string(new char[] { 'f', 'o', 'o' }))
            .Then(@string => @string.Should().BeNull());
        }

        /// <summary>
        /// Dummy method that simulates a failed test whose caller context should be extracted.
        /// </summary>
        private void TestCallerContextForShouldWithoutParameterAndWithReason()
        {
            Given()
            .When(() => new string(new char[] { 'f', 'o', 'o' }))
            .Then(@string => @string.Should().BeNull(because: "that's the bottom line"));
        }

        /// <summary>
        /// Helper method to get the path of this source code file.
        /// </summary>
        /// <param name="sourcePath"> The compiler generated path of this source code file. </param>
        /// <returns> The path of this source code file. </returns>
        private string GetSourcePath([CallerFilePath] string sourcePath = null)
        {
            return sourcePath;
        }

        #endregion

        [Fact(DisplayName = "Caller context for should with 1 parameter and without reason")]
        public void ParseCallerContextForShouldWithOneParameterAndWithoutReasonSuccess()
        {
            // Given
            var context = new RoslynCallerContext();

            // When
            var actual = context.GetCallerContext(
                "bar",
                nameof(TestCallerContextForShouldWithOneParameterAndWithoutReason),
                "Be",
                25, 
                GetSourcePath());

            // Then
            Assert.Equal("@string", actual);
        }

        [Fact(DisplayName = "Caller context for should with 1 parameter and with reason")]
        public void ParseCallerContextForShouldWithOneParameterAndWithReasonSuccess()
        {
            // Given
            var context = new RoslynCallerContext();

            // When
            var actual = context.GetCallerContext(
                "bar",
                nameof(TestCallerContextForShouldWithOneParameterAndWithReason),
                "Be",
                35,
                GetSourcePath());

            // Then
            Assert.Equal("@string", actual);
        }

        [Fact(DisplayName = "Caller context for should without parameter and without reason")]
        public void ParseCallerContextForShouldWithoutParameterAndWithoutReasonSuccess()
        {
            // Given
            var context = new RoslynCallerContext();

            // When
            var actual = context.GetCallerContext(
                (string)null,
                nameof(TestCallerContextForShouldWithoutParameterAndWithoutReason),
                "BeNull",
                45,
                GetSourcePath());

            // Then
            Assert.Equal("@string", actual);
        }

        [Fact(DisplayName = "Caller context for should without parameter and with reason")]
        public void ParseCallerContextForShouldWithoutParameterAndWithReasonSuccess()
        {
            // Given
            var context = new RoslynCallerContext();

            // When
            var actual = context.GetCallerContext(
                (string)null,
                nameof(TestCallerContextForShouldWithoutParameterAndWithReason),
                "BeNull",
                55,
                GetSourcePath());

            // Then
            Assert.Equal("@string", actual);
        }
    }
}