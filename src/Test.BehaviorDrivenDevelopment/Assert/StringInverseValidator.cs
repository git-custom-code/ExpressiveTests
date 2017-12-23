namespace CustomCode.Test.BehaviorDrivenDevelopment
{
    using System;
    using System.Runtime.CompilerServices;

    /// <summary>
    /// A <see cref="ContextValidator{T}"/> that defines inverse assertions for the <see cref="string"/> data type.
    /// </summary>
    public sealed class StringInverseValidator : ContextValidator<string>
    {
        #region Dependencies

        /// <summary>
        /// Creates a new instance of the <see cref="StringValidator"/> type.
        /// </summary>
        /// <param name="value"> The string value to be validated. </param>
        public StringInverseValidator(string value)
        {
            Value = value;
        }

        #endregion

        #region Data

        /// <summary>
        /// Gets the string value to be validated.
        /// </summary>
        private string Value { get; }

        #endregion

        #region Logic

        /// <summary>
        /// Assert that a given string equals another string.
        /// </summary>
        /// <param name="expected"> The expected value of a given string. </param>
        /// <param name="because"> A reason why this assertion needs to be correct. </param>
        /// <param name="ignoreCase"> False if the string comparison should be case sensitive, false otherwise. </param>
        /// <param name="testMethodName"> Supplied by the compiler. </param>
        /// <param name="lineNumber"> Supplied by the compiler. </param>
        /// <param name="sourceCodePath"> Supplied by the compiler. </param>
        public void Be(string expected, string because = null, bool ignoreCase = false,
            [CallerMemberName] string testMethodName = null, [CallerLineNumber] int lineNumber = 0, [CallerFilePath] string sourceCodePath = null)
        {
            if (ignoreCase)
            {
                if (string.Equals(Value, expected, StringComparison.OrdinalIgnoreCase))
                {
                    var context = GetContext(testMethodName, expected, sourceCodePath, lineNumber);
                    throw ValidationException(testMethodName, context, $"\"{Value}\"", $"be \"{expected}\"", because);
                }
            }
            else
            {
                if (string.Equals(Value, expected))
                {
                    var context = GetContext(testMethodName, expected, sourceCodePath, lineNumber);
                    throw ValidationException(testMethodName, context, $"\"{Value}\"", $"be \"{expected}\"", because);
                }
            }
        }

        /// <summary>
        /// Assert that a given string starts with a sequence of characters.
        /// </summary>
        /// <param name="start"> The sequence of characters at the start of a given string. </param>
        /// <param name="because"> A reason why this assertion needs to be correct. </param>
        /// <param name="ignoreCase"> False if the string comparison should be case sensitive, false otherwise. </param>
        /// <param name="testMethodName"> Supplied by the compiler. </param>
        /// <param name="lineNumber"> Supplied by the compiler. </param>
        /// <param name="sourceCodePath"> Supplied by the compiler. </param>
        public void StartWith(string start, string because = null, bool ignoreCase = false,
            [CallerMemberName] string testMethodName = null, [CallerLineNumber] int lineNumber = 0, [CallerFilePath] string sourceCodePath = null)
        {
            if (ignoreCase)
            {
                if (Value != null && !string.IsNullOrEmpty(start) && Value.StartsWith(start, StringComparison.OrdinalIgnoreCase))
                {
                    var context = GetContext(testMethodName, start, sourceCodePath, lineNumber);
                    throw ValidationException(testMethodName, context, $"\"{Value}\"", $"start with \"{start}\"", because);
                }
            }
            else
            {
                if (Value != null && !string.IsNullOrEmpty(start) && Value.StartsWith(start))
                {
                    var context = GetContext(testMethodName, start, sourceCodePath, lineNumber);
                    throw ValidationException(testMethodName, context, $"\"{Value}\"", $"start with \"{start}\"", because);
                }
            }
        }

        /// <summary>
        /// Assert that a given string ends with a sequence of characters.
        /// </summary>
        /// <param name="end"> The sequence of characters at the end of a given string. </param>
        /// <param name="because"> A reason why this assertion needs to be correct. </param>
        /// <param name="ignoreCase"> False if the string comparison should be case sensitive, false otherwise. </param>
        /// <param name="testMethodName"> Supplied by the compiler. </param>
        /// <param name="lineNumber"> Supplied by the compiler. </param>
        /// <param name="sourceCodePath"> Supplied by the compiler. </param>
        public void EndWith(string end, string because = null, bool ignoreCase = false,
            [CallerMemberName] string testMethodName = null, [CallerLineNumber] int lineNumber = 0, [CallerFilePath] string sourceCodePath = null)
        {
            if (ignoreCase)
            {
                if (Value != null && !string.IsNullOrEmpty(end) && Value.EndsWith(end, StringComparison.OrdinalIgnoreCase))
                {
                    var context = GetContext(testMethodName, end, sourceCodePath, lineNumber);
                    throw ValidationException(testMethodName, context, $"\"{Value}\"", $"end with \"{end}\"", because);
                }
            }
            else
            {
                if (Value != null && !string.IsNullOrEmpty(end) && Value.EndsWith(end))
                {
                    var context = GetContext(testMethodName, end, sourceCodePath, lineNumber);
                    throw ValidationException(testMethodName, context, $"\"{Value}\"", $"end with \"{end}\"", because);
                }
            }
        }

        #endregion
    }
}