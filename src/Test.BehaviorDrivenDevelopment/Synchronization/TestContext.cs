namespace CustomCode.Test.BehaviorDrivenDevelopment.Synchronization
{
    using Xunit.Abstractions;

    /// <summary>
    /// Strongly typed decorator for the <see cref="AmbientCache{T}"/>.
    /// </summary>
    internal static class TestContext
    {
        #region Logic

        /// <summary>
        /// Gets or sets a flag indicating whether or not the test should write additional output.
        /// </summary>
        internal static bool EnableOutput
        {
            get { return AmbientCache<bool>.Get(CacheKeys.EnableOutput); }
            set { AmbientCache<bool>.Set(CacheKeys.EnableOutput, value); }
        }

        /// <summary>
        /// Gets or sets an xunit <see cref="ITestOutputHelper"/> for writing additional output.
        /// </summary>
        internal static ITestOutputHelper TestOutput
        {
            get { return AmbientCache<ITestOutputHelper>.Get(CacheKeys.TestOutput); }
            set { AmbientCache<ITestOutputHelper>.Set(CacheKeys.TestOutput, value); }
        }

        #endregion
    }
}