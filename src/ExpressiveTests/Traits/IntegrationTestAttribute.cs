namespace CustomCode.ExpressiveTests
{
    using System;
    using Xunit.Sdk;

    /// <summary>
    /// Attribute that can be used to mark a test as integration test.
    /// If you group your tests by trait in the test explorer tests marked this way will be
    /// displayed under the Category [Integration Test].
    /// </summary>
    [TraitDiscoverer("CustomCode.ExpressiveTests.IntegrationTestDiscoverer", "CustomCode.ExpressiveTests")]
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]
    public sealed class IntegrationTestAttribute : Attribute, ITraitAttribute
    { }
}