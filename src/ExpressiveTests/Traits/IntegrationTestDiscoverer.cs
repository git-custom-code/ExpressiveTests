namespace CustomCode.ExpressiveTests
{
    using System.Collections.Generic;
    using Xunit.Abstractions;
    using Xunit.Sdk;

    /// <summary>
    /// <see cref="ITraitDiscoverer"/> implementation for the <see cref="IntegrationTestAttribute"/>.
    /// </summary>
    public class IntegrationTestDiscoverer : ITraitDiscoverer
    {
        #region Logic

        /// <summary>
        /// Gets the trait values from the <paramref name="traitAttribute"/>.
        /// </summary>
        /// <param name="traitAttribute"> The trait attribute containing the trait values. </param>
        /// <returns> The trait values. </returns>
        public IEnumerable<KeyValuePair<string, string>> GetTraits(IAttributeInfo traitAttribute)
        {
            yield return new KeyValuePair<string, string>("Category", "Integration Test");
        }

        #endregion
    }
}