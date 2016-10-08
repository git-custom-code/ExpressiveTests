namespace ExpressiveTests
{
    using Configuration;
    using System.Runtime.CompilerServices;

    /// <summary>
    /// 
    /// </summary>
    public sealed class StringValidator : ContextValidator<string>
    {
        #region Dependencies

        /// <summary>
        /// Standard ctor.
        /// </summary>
        /// <param name="value"> The string value to be validated. </param>
        public StringValidator(string value)
        {
            Value = value;
        }

        /// <summary>
        /// Standard ctor.
        /// </summary>
        /// <param name="value"> The string value to be validated. </param>
        /// <param name="callerContext"> The caller context that can be used to enrich assert messages. </param>
        /// <param name="messageFormatter"> The formatter used to format the assertion message. </param>
        public StringValidator(string value, ICallerContext callerContext, IMessageFormatter messageFormatter)
            : base(callerContext, messageFormatter)
        {
            Value = value;
        }

        #endregion

        #region Data

        /// <summary>
        /// The string value to be validated.
        /// </summary>
        private string Value { get; }

        #endregion

        #region Logic

        public StringInverseValidator Not()
        {
            return new StringInverseValidator(Value);
        }

        /// <summary>
        /// Assert that a given string equals another string.
        /// </summary>
        /// <param name="expected"> The expected value of a given string. </param>
        /// <param name="because"> A reason why this assertion needs to be correct. </param>
        /// <param name="testMethodName"> Supplied by the compiler. </param>
        /// <param name="sourceCodePath"> Supplied by the compiler. </param>
        public void Be(string expected, string because = null,
            [CallerMemberName] string testMethodName = null, [CallerLineNumber] int lineNumber = 0, [CallerFilePath] string sourceCodePath = null)
        {
            if (!string.Equals(Value, expected))
            {
                var context = GetContext(testMethodName, expected, sourceCodePath, lineNumber);
                throw ValidationException(context, $"\"{Value}\"", $"be \"{expected}\"", because);
            }
        }

        /// <summary>
        /// Assert that a given string starts with a sequence of characters.
        /// </summary>
        /// <param name="start"> The sequence of characters at the start of a given string. </param>
        /// <param name="because"> A reason why this assertion needs to be correct. </param>
        /// <param name="testMethodName"> Supplied by the compiler. </param>
        /// <param name="sourceCodePath"> Supplied by the compiler. </param>
        public void StartWith(string start, string because = null,
            [CallerMemberName] string testMethodName = null, [CallerLineNumber] int lineNumber = 0, [CallerFilePath] string sourceCodePath = null)
        {
            if (Value == null || string.IsNullOrEmpty(start) || !Value.StartsWith(start))
            {
                var context = GetContext(testMethodName, start, sourceCodePath, lineNumber);
                throw ValidationException(context, $"\"{Value}\"", $"start with \"{start}\"", because);
            }
        }

        /// <summary>
        /// Assert that a given string ends with a sequence of characters.
        /// </summary>
        /// <param name="end"> The sequence of characters at the end of a given string. </param>
        /// <param name="because"> A reason why this assertion needs to be correct. </param>
        /// <param name="testMethodName"> Supplied by the compiler. </param>
        /// <param name="sourceCodePath"> Supplied by the compiler. </param>
        public void EndWith(string end, string because = null,
            [CallerMemberName] string testMethodName = null, [CallerLineNumber] int lineNumber = 0, [CallerFilePath] string sourceCodePath = null)
        {
            if (Value == null || string.IsNullOrEmpty(end) || !Value.EndsWith(end))
            {
                var context = GetContext(testMethodName, end, sourceCodePath, lineNumber);
                throw ValidationException(context, $"\"{Value}\"", $"end with \"{end}\"", because);
            }
        }

        #endregion
    }
}