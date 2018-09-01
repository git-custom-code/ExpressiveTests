namespace CustomCode.Test.BehaviorDrivenDevelopment
{
    using System;
    using Xunit;
    using Xunit.Sdk;

    /// <summary>
    /// A attribute that describes a single scenario (acceptance criteria) of a user story.
    /// </summary>
    /// <remarks>
    /// Scenario attributes can be placed only on the method level and only on methods with no input and no output
    /// parameters. Methods decorated in that way can be executed as xunit tests.
    /// </remarks>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    [XunitTestCaseDiscoverer("CustomCode.Test.BehaviorDrivenDevelopment.ScenarioAttributeDiscoverer", "Test.BehaviorDrivenDevelopment")]
    public sealed class ScenarioAttribute : FactAttribute
    {
        #region Data

        /// <summary>
        /// Gets or sets a flag indicating whether or not the test will write additional output.
        /// </summary>
        public bool EnableOutput { get; set; } = true;

        #endregion
    }
}