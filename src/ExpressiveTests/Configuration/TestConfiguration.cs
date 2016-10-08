namespace ExpressiveTests.Configuration
{
    using System.Diagnostics;

    /// <summary>
    /// Global test configuration that can be overriden via <see cref="TestConfigurationAttribute"/>
    /// or <see cref="GlobalTestConfigurationAttribute"/> to use a custom <see cref="ICallerContext"/>
    /// and/or <see cref="IMessageFormatter"/>.
    /// </summary>
    internal static class TestConfiguration
    {
        #region Dependencies

        /// <summary>
        /// Static ctor.
        /// </summary>
        static TestConfiguration()
        {
            Initialize();
        }

        #endregion

        #region Data

        /// <summary>
        /// The default <see cref="ICallerContext"/> implementation that is used by all tests.
        /// </summary>
        private static ICallerContext DefaultCallerContext { get; set; }

        /// <summary>
        /// The default <see cref="IMessageFormatter"/> implementation that is used by all tests.
        /// </summary>
        private static IMessageFormatter DefaultMessageFormatter { get; set; }

        #region CallerContext

        /// <summary>
        /// The <see cref="ICallerContext"/> that is used by the currently executing test.
        /// </summary>
        /// <value> Modifies the <see cref="_callerContext"/> field. </value>
        /// <remarks>
        /// This property is called when you use the <see cref="TestConfigurationAttribute"/> to
        /// configure an test specific <see cref="ICallerContext"/>.
        /// </remarks>
        public static ICallerContext CallerContext
        {
            get
            {
                return _callerContext ?? DefaultCallerContext;
            }
            set
            {
                _callerContext = value;
            }
        }

        /// <summary> The <see cref="ICallerContext"/> that is used by the currently executing test. </summary>
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private static ICallerContext _callerContext;

        #endregion

        #region MessageFormatter

        /// <summary>
        /// The <see cref="IMessageFormatter"/> that is used by the currently executing test.
        /// </summary>
        /// <value> Modifies the <see cref="_messageFormatter"/> field. </value>
        /// <remarks>
        /// This property is called when you use the <see cref="TestConfigurationAttribute"/> to
        /// configure an test specific <see cref="IMessageFormatter"/>.
        /// </remarks>
        internal static IMessageFormatter MessageFormatter
        {
            get
            {
                return _messageFormatter ?? DefaultMessageFormatter;
            }
            set
            {
                _messageFormatter = value;
            }
        }

        /// <summary> The <see cref="IMessageFormatter"/> that is used by the currently executing test. </summary>
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private static IMessageFormatter _messageFormatter;

        #endregion

        #endregion

        #region Logic

        /// <summary>
        /// Initialize the <see cref="DefaultCallerContext"/> and <see cref="DefaultMessageFormatter"/>.
        /// </summary>
        /// <param name="context">
        /// A <see cref="ICallerContext"/> instance that should be used as default or null to use the
        /// <see cref="RoslynCallerContext"/> type as default.
        /// </param>
        /// <param name="formatter">
        /// A <see cref="IMessageFormatter"/> instance that should be used as default or null to use
        /// the <see cref="MessageFormatter"/> type as default.
        /// </param>
        /// <remarks>
        /// This method is called when you use the <see cref="GlobalTestConfigurationAttribute"/> to
        /// configure an assembly wide <see cref="ICallerContext"/> or <see cref="IMessageFormatter"/>.
        /// </remarks>
        public static void Initialize(ICallerContext context = null, IMessageFormatter formatter = null)
        {
            DefaultCallerContext = context ?? new RoslynCallerContext();
            DefaultMessageFormatter = formatter ?? new MessageFormatter();
        }

        #endregion
    }
}