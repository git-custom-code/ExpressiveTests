namespace CustomCode.Test.BehaviorDrivenDevelopment.Synchronization
{
    /// <summary>
    /// String enumeration with keys for the <see cref="AmbientCache{T}"/>.
    /// </summary>
    internal static class CacheKeys
    {
        #region Data

        /// <summary> The chache key for the <see cref="TestContext.EnableOutput"/> property. </summary>
        public const string EnableOutput = nameof(EnableOutput);

        /// <summary> The chache key for the <see cref="TestContext.TestOutput"/> property. </summary>
        public const string TestOutput = nameof(TestOutput);

        #endregion
    }
}