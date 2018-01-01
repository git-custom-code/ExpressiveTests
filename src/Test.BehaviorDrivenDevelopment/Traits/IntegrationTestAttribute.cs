namespace CustomCode.Test.BehaviorDrivenDevelopment
{
    using System;
    using Xunit.Sdk;

    /// <summary>
    /// Attribute that can be used to mark a test as integration test.
    /// </summary>
    /// <remarks>
    /// If you group your tests by trait in the test explorer, tests marked this way will be
    /// displayed under the Type [Integration Test].
    /// </remarks>
    [TraitDiscoverer("CustomCode.Test.BehaviorDrivenDevelopment.IntegrationTestDiscoverer", "CustomCode.Test.BehaviorDrivenDevelopment")]
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]
    public sealed class IntegrationTestAttribute : Attribute, ITraitAttribute
    { }
}