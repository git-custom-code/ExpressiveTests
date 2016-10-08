namespace CustomCode.ExpressiveTests
{
    using System;
    using System.Diagnostics;
    using Xunit;

    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public sealed class DeveloperFactAttribute : FactAttribute
    {
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
    }
}