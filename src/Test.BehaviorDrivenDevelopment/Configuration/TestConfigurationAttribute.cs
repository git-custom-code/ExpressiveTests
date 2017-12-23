namespace CustomCode.Test.BehaviorDrivenDevelopment.Configuration
{
    using System;
    using System.Reflection;
    using Xunit.Sdk;

    /// <summary>
    /// Use this attribute on the "per test level" (i.e. on the method level) to set a custom
    /// <see cref="ICallerContext"/> and/or <see cref="IMessageFormatter"/>
    /// that should be used by the test.
    /// </summary>
    /// <example>
    ///
    /// [Fact]
    /// [TestConfiguration(CallerContext = typeof(MyContext), MessageFormatter = typeof(MyFormattter))]
    /// public void TestMethod()
    /// {
    ///   ...
    /// }
    ///
    /// </example>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public sealed class TestConfigurationAttribute : BeforeAfterTestAttribute
    {
        #region Data

        /// <summary>
        /// Gets or sets the type of the custom <see cref="ICallerContext"/> that should be used by the test.
        /// </summary>
        public Type CallerContext { get; set; }

        /// <summary>
        /// Gets or sets the type of the custom <see cref="IMessageFormatter"/> that should be used by the test.
        /// </summary>
        public Type MessageFormatter { get; set; }

        #endregion

        #region Logic

        /// <summary>
        /// This method is called before the test method is executed.
        /// </summary>
        /// <param name="methodUnderTest"> The method under test. </param>
        public override void Before(MethodInfo methodUnderTest)
        {
            if (MessageFormatter != null && typeof(IMessageFormatter).IsAssignableFrom(MessageFormatter))
            {
                TestConfiguration.SetMessageFormatterFor(
                    methodUnderTest.Name,
                    (IMessageFormatter)Activator.CreateInstance(MessageFormatter));
            }
            if (CallerContext != null && typeof(ICallerContext).IsAssignableFrom(CallerContext))
            {
                TestConfiguration.SetCallerContextFor(
                    methodUnderTest.Name,
                    (ICallerContext)Activator.CreateInstance(CallerContext));
            }
        }

        /// <summary>
        /// This method is called after the test method is executed.
        /// </summary>
        /// <param name="methodUnderTest"> The method under test. </param>
        public override void After(MethodInfo methodUnderTest)
        {
            TestConfiguration.ResetMessageFormatterFor(methodUnderTest.Name);
            TestConfiguration.ResetCallerContextFor(methodUnderTest.Name);
        }

        #endregion
    }
}