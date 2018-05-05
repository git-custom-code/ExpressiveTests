namespace CustomCode.Test.BehaviorDrivenDevelopment
{
    using System;
    using Xunit.Sdk;

    /// <summary>
    /// Attribute that can be used to categorize tests.
    /// </summary>
    /// <remarks>
    /// If you group your tests by trait in the test explorer, tests marked this way will be
    /// displayed under the Category ["your category here"].
    /// </remarks>
    [TraitDiscoverer("CustomCode.Test.BehaviorDrivenDevelopment.CategoryDiscoverer", "Test.BehaviorDrivenDevelopment")]
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]
    public sealed class CategoryAttribute : Attribute, ITraitAttribute
    {
        #region Dependencies

        /// <summary>
        /// Creates a new instance of the <see cref="CategoryAttribute"/> type.
        /// </summary>
        /// <param name="names"> A collection of category names. </param>
        public CategoryAttribute(params string[] names)
        {
            Names = names;
        }

        #endregion

        #region Data

        /// <summary>
        /// Gets a collection of category names.
        /// </summary>
        public string[] Names { get; }

        #endregion
    }
}