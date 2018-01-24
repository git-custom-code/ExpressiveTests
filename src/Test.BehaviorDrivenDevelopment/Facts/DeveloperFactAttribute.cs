namespace CustomCode.Test.BehaviorDrivenDevelopment
{
    using System;
    using System.Diagnostics;
    using Xunit;

    /// <summary>
    /// Attribute that is applied to a method to indicate that it is a fact that should
    /// be skipped by the test runner and only be executed manually by the developer
    /// from within visual studio.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public sealed class DeveloperFactAttribute : FactAttribute
    {
        #region Data

        /// <summary>
        /// Gets or sets the skip reason.
        /// </summary>
        public override string Skip
        {
            get
            {
                if (!Debugger.IsAttached)
                {
                    return "Only running when executed manually by a developer with attached debugger";
                }
                return base.Skip;
            }
            set { base.Skip = value; }
        }

        #endregion
    }
}