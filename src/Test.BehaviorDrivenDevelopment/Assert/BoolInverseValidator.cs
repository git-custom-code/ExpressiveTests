namespace CustomCode.Test.BehaviorDrivenDevelopment
{
    using System.Runtime.CompilerServices;

    /// <summary>
    /// A validator that defines inverse assertions for the <see cref="bool"/> data type.
    /// </summary>
    public struct BoolInverseValidator : IFluentInterface
    {
        #region Dependencies

        /// <summary>
        /// Creates a new instance of the <see cref="BoolInverseValidator"/> type.
        /// </summary>
        /// <param name="value"> The boolean value to be validated. </param>
        public BoolInverseValidator(bool value)
        {
            Context = new ValidationContext<bool>();
            Value = value;
        }

        #endregion

        #region Data

        /// <summary>
        /// Gets the context validator.
        /// </summary>
        private ValidationContext<bool> Context { get; }

        /// <summary>
        /// Gets the boolean value to be validated.
        /// </summary>
        private bool Value { get; }

        #endregion

        #region Logic

        /// <summary>
        /// Assert that a given boolean does not equal another boolean.
        /// </summary>
        /// <param name="expected"> The expected value of a given boolean. </param>
        /// <param name="because"> A reason why this assertion needs to be correct. </param>
        /// <param name="testMethodName"> Supplied by the compiler. </param>
        /// <param name="lineNumber"> Supplied by the compiler. </param>
        /// <param name="sourceCodePath"> Supplied by the compiler. </param>
        public void Be(bool expected, string because = null,
            [CallerMemberName] string testMethodName = null, [CallerLineNumber] int lineNumber = 0, [CallerFilePath] string sourceCodePath = null)
        {
            if (Value == expected)
            {
                var context = Context.GetCallerContext(testMethodName, expected, sourceCodePath, lineNumber);
                throw Context.GetFormattedException(testMethodName, context, $"is \"{Value}\"", $"not to be \"{expected}\"", because);
            }
        }

        /// <summary>
        /// Assert that a given boolean is not true.
        /// </summary>
        /// <param name="because"> A reason why this assertion needs to be correct. </param>
        /// <param name="testMethodName"> Supplied by the compiler. </param>
        /// <param name="lineNumber"> Supplied by the compiler. </param>
        /// <param name="sourceCodePath"> Supplied by the compiler. </param>
        public void BeTrue(string because = null,
            [CallerMemberName] string testMethodName = null, [CallerLineNumber] int lineNumber = 0, [CallerFilePath] string sourceCodePath = null)
        {
            if (Value == true)
            {
                var context = Context.GetCallerContext(testMethodName, default(bool), sourceCodePath, lineNumber);
                throw Context.GetFormattedException(testMethodName, context, $"is \"{Value}\"", $"not to be true", because);
            }
        }

        /// <summary>
        /// Assert that a given boolean is not false.
        /// </summary>
        /// <param name="because"> A reason why this assertion needs to be correct. </param>
        /// <param name="testMethodName"> Supplied by the compiler. </param>
        /// <param name="lineNumber"> Supplied by the compiler. </param>
        /// <param name="sourceCodePath"> Supplied by the compiler. </param>
        public void BeFalse(string because = null,
            [CallerMemberName] string testMethodName = null, [CallerLineNumber] int lineNumber = 0, [CallerFilePath] string sourceCodePath = null)
        {
            if (Value == false)
            {
                var context = Context.GetCallerContext(testMethodName, default(bool), sourceCodePath, lineNumber);
                throw Context.GetFormattedException(testMethodName, context, $"is \"{Value}\"", $"not to be false", because);
            }
        }

        #endregion
    }
}