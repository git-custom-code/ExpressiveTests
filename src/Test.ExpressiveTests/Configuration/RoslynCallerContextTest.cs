namespace Test.ExpressiveTests.Configuration
{
    using global::ExpressiveTests;
    using global::ExpressiveTests.Configuration;
    using System.Runtime.CompilerServices;
    using Xunit;

    /// <summary>
    /// Test cases for the <see cref="RoslynCallerContext"/> type.
    /// </summary>
    /// <remarks>
    /// Carefully when changing line numbers inside of this file, because the integration test depends on it!
    /// </remarks>
    public sealed class RoslynCallerContextTest : TestCase
    {
        /// <summary>
        /// Dummy method that simulates a failed test whose caller context should be extracted.
        /// </summary>
        private void TestMethod()
        {
            Given()
            .When(() => new string(new char[] { 'f', 'o', 'o' }))
            .Then(@string => @string.Should().Be("bar"));
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

        [Fact(DisplayName = "GetCallerContext")]
        [Trait("Category", "Configuration")]
        public void ParseCallerContextSuccess()
        {
            // Given
            var context = new RoslynCallerContext();

            // When
            var actual = context.GetCallerContext("bar", nameof(TestMethod), "Be", 23, GetSourcePath());

            // Then
            Assert.Equal("@string", actual);
        }
    }
}