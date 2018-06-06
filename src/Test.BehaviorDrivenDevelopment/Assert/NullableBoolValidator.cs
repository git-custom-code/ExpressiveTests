namespace CustomCode.Test.BehaviorDrivenDevelopment
{
    using System.Runtime.CompilerServices;

    /// <summary>
    /// A validator that defines assertions for the nullable <see cref="bool"/> data type.
    /// </summary>
    public struct NullableBoolValidator : IFluentInterface
    {
        #region Dependencies

        /// <summary>
        /// Creates a new instance of the <see cref="NullableBoolValidator"/> type.
        /// </summary>
        /// <param name="value"> The nullable boolean value to be validated. </param>
        public NullableBoolValidator(bool? value)
        {
            Context = new ValidationContext<bool?>();
            Value = value;
        }

        #endregion

        #region Data

        /// <summary>
        /// Gets the context validator.
        /// </summary>
        private ValidationContext<bool?> Context { get; }

        /// <summary>
        /// Gets the nullable boolean value to be validated.
        /// </summary>
        private bool? Value { get; }

        #endregion

        #region Logic

        /// <summary>
        /// Assert that a given nullable boolean equals another nullable boolean.
        /// </summary>
        /// <param name="expected"> The expected value of a given nullable boolean. </param>
        /// <param name="because"> A reason why this assertion needs to be correct. </param>
        /// <param name="testMethodName"> Supplied by the compiler. </param>
        /// <param name="lineNumber"> Supplied by the compiler. </param>
        /// <param name="sourceCodePath"> Supplied by the compiler. </param>
        public void Be(bool? expected, string because = null,
            [CallerMemberName] string testMethodName = null, [CallerLineNumber] int lineNumber = 0, [CallerFilePath] string sourceCodePath = null)
        {
            if (Value != expected)
            {
                var context = Context.GetCallerContext(testMethodName, expected, sourceCodePath, lineNumber);
                throw Context.GetFormattedException(testMethodName, context, $"is \"{Value}\"", $"to be \"{expected}\"", because);
            }
        }

        /// <summary>
        /// Assert that a given nullable boolean is false.
        /// </summary>
        /// <param name="because"> A reason why this assertion needs to be correct. </param>
        /// <param name="testMethodName"> Supplied by the compiler. </param>
        /// <param name="lineNumber"> Supplied by the compiler. </param>
        /// <param name="sourceCodePath"> Supplied by the compiler. </param>
        public void BeFalse(string because = null,
            [CallerMemberName] string testMethodName = null, [CallerLineNumber] int lineNumber = 0, [CallerFilePath] string sourceCodePath = null)
        {
            if (Value == true || Value == null)
            {
                var context = Context.GetCallerContext(testMethodName, default(bool?), sourceCodePath, lineNumber);
                throw Context.GetFormattedException(testMethodName, context, $"is \"{Value}\"", $"to be false", because);
            }
        }

        /// <summary>
        /// Assert that a given nullable boolean is null.
        /// </summary>
        /// <param name="because"> A reason why this assertion needs to be correct. </param>
        /// <param name="testMethodName"> Supplied by the compiler. </param>
        /// <param name="lineNumber"> Supplied by the compiler. </param>
        /// <param name="sourceCodePath"> Supplied by the compiler. </param>
        public void BeNull(string because = null,
            [CallerMemberName] string testMethodName = null, [CallerLineNumber] int lineNumber = 0, [CallerFilePath] string sourceCodePath = null)
        {
            if (Value.HasValue)
            {
                var context = Context.GetCallerContext(testMethodName, default(bool?), sourceCodePath, lineNumber);
                throw Context.GetFormattedException(testMethodName, context, $"is \"{Value}\"", $"to be null", because);
            }
        }

        /// <summary>
        /// Assert that a given nullable boolean is true.
        /// </summary>
        /// <param name="because"> A reason why this assertion needs to be correct. </param>
        /// <param name="testMethodName"> Supplied by the compiler. </param>
        /// <param name="lineNumber"> Supplied by the compiler. </param>
        /// <param name="sourceCodePath"> Supplied by the compiler. </param>
        public void BeTrue(string because = null,
            [CallerMemberName] string testMethodName = null, [CallerLineNumber] int lineNumber = 0, [CallerFilePath] string sourceCodePath = null)
        {
            if (Value == false || Value == null)
            {
                var context = Context.GetCallerContext(testMethodName, default(bool?), sourceCodePath, lineNumber);
                throw Context.GetFormattedException(testMethodName, context, $"is \"{Value}\"", $"to be true", because);
            }
        }

        #endregion
    }
}