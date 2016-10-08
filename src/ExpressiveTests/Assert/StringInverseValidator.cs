namespace ExpressiveTests
{
    using System.Runtime.CompilerServices;

    /// <summary>
    /// 
    /// </summary>
    public sealed class StringInverseValidator : ContextValidator<string>
    {
        #region Dependencies

        /// <summary>
        /// Standard ctor.
        /// </summary>
        /// <param name="value"> The string value to be validated. </param>
        public StringInverseValidator(string value)
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

        public void Be(string expected,
            [CallerMemberName] string name = null, [CallerLineNumber] int lineNumber = 0, [CallerFilePath] string sourceCodePath = null)
        {
            if (string.Equals(Value, expected))
            {
                var context = GetContext(name, sourceCodePath, expected, lineNumber);
                throw ValidationException(context, $"\"{Value}\"", $"be \"{expected}\"");
            }
        }

        public void StartWith(string start,
            [CallerMemberName] string name = null, [CallerLineNumber] int lineNumber = 0, [CallerFilePath] string sourceCodePath = null)
        {
            if (Value != null && Value.StartsWith(start))
            {
                var context = GetContext(name, sourceCodePath, start, lineNumber);
                throw ValidationException(context, $"\"{Value}\"", $"start with \"{start}\"");
            }
        }
    }
}