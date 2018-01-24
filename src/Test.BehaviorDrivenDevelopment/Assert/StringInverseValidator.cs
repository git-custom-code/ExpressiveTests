namespace CustomCode.Test.BehaviorDrivenDevelopment
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Text.RegularExpressions;

    /// <summary>
    /// A validator that defines inverse assertions for the <see cref="string"/> data type.
    /// </summary>
    public struct StringInverseValidator : IFluentInterface
    {
        #region Dependencies

        /// <summary>
        /// Creates a new instance of the <see cref="StringValidator"/> type.
        /// </summary>
        /// <param name="value"> The string value to be validated. </param>
        public StringInverseValidator(string value)
        {
            Context = new ValidationContext<string>();
            Value = value;
        }

        #endregion

        #region Data

        /// <summary>
        /// Gets the validation context.
        /// </summary>
        private ValidationContext<string> Context { get; }

        /// <summary>
        /// Gets the string value to be validated.
        /// </summary>
        private string Value { get; }

        #endregion

        #region Logic

        /// <summary>
        /// Assert that a given string does not equal another string.
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
                    var context = Context.GetCallerContext(testMethodName, expected, sourceCodePath, lineNumber);
                    throw Context.GetFormattedException(testMethodName, context, $"\"{Value}\"", $"not to be \"{expected}\"", because);
                }
            }
            else
            {
                if (string.Equals(Value, expected))
                {
                    var context = Context.GetCallerContext(testMethodName, expected, sourceCodePath, lineNumber);
                    throw Context.GetFormattedException(testMethodName, context, $"\"{Value}\"", $"not to be \"{expected}\"", because);
                }
            }
        }

        /// <summary>
        /// Assert that a given string does not equal the empty string.
        /// </summary>
        /// <param name="because"> A reason why this assertion needs to be correct. </param>
        /// <param name="testMethodName"> Supplied by the compiler. </param>
        /// <param name="lineNumber"> Supplied by the compiler. </param>
        /// <param name="sourceCodePath"> Supplied by the compiler. </param>
        public void BeEmpty(string because = null,
            [CallerMemberName] string testMethodName = null, [CallerLineNumber] int lineNumber = 0, [CallerFilePath] string sourceCodePath = null)
        {
            if (Value == string.Empty)
            {
                var context = Context.GetCallerContext(testMethodName, null, sourceCodePath, lineNumber);
                throw Context.GetFormattedException(testMethodName, context, $"\"{Value}\"", $"not to be empty", because);
            }
        }

        /// <summary>
        /// Assert that a given string does not equal null.
        /// </summary>
        /// <param name="because"> A reason why this assertion needs to be correct. </param>
        /// <param name="testMethodName"> Supplied by the compiler. </param>
        /// <param name="lineNumber"> Supplied by the compiler. </param>
        /// <param name="sourceCodePath"> Supplied by the compiler. </param>
        public void BeNull(string because = null,
            [CallerMemberName] string testMethodName = null, [CallerLineNumber] int lineNumber = 0, [CallerFilePath] string sourceCodePath = null)
        {
            if (Value == null)
            {
                var context = Context.GetCallerContext(testMethodName, null, sourceCodePath, lineNumber);
                throw Context.GetFormattedException(testMethodName, context, $"\"{Value}\"", $"not to be null", because);
            }
        }

        /// <summary>
        /// Assert that a given string does not equal null or the empty string.
        /// </summary>
        /// <param name="because"> A reason why this assertion needs to be correct. </param>
        /// <param name="testMethodName"> Supplied by the compiler. </param>
        /// <param name="lineNumber"> Supplied by the compiler. </param>
        /// <param name="sourceCodePath"> Supplied by the compiler. </param>
        public void BeNullOrEmpty(string because = null,
            [CallerMemberName] string testMethodName = null, [CallerLineNumber] int lineNumber = 0, [CallerFilePath] string sourceCodePath = null)
        {
            if (string.IsNullOrEmpty(Value))
            {
                var context = Context.GetCallerContext(testMethodName, null, sourceCodePath, lineNumber);
                throw Context.GetFormattedException(testMethodName, context, $"\"{Value}\"", $"not to be null or empty", because);
            }
        }

        /// <summary>
        /// Assert that a given string does not contain another (sub-)string.
        /// </summary>
        /// <param name="expected"> The expected value of a given (sub-)string. </param>
        /// <param name="because"> A reason why this assertion needs to be correct. </param>
        /// <param name="ignoreCase"> False if the string comparison should be case sensitive, false otherwise. </param>
        /// <param name="testMethodName"> Supplied by the compiler. </param>
        /// <param name="lineNumber"> Supplied by the compiler. </param>
        /// <param name="sourceCodePath"> Supplied by the compiler. </param>
        public void Contain(string expected, string because = null, bool ignoreCase = false,
            [CallerMemberName] string testMethodName = null, [CallerLineNumber] int lineNumber = 0, [CallerFilePath] string sourceCodePath = null)
        {
            if (ignoreCase)
            {
                if (Value?.IndexOf(expected, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    var context = Context.GetCallerContext(testMethodName, expected, sourceCodePath, lineNumber);
                    throw Context.GetFormattedException(testMethodName, context, $"\"{Value}\"", $"to not contain \"{expected}\"", because);
                }
            }
            else
            {
                if (Value?.IndexOf(expected) >= 0)
                {
                    var context = Context.GetCallerContext(testMethodName, expected, sourceCodePath, lineNumber);
                    throw Context.GetFormattedException(testMethodName, context, $"\"{Value}\"", $"to not contain \"{expected}\"", because);
                }
            }
        }

        /// <summary>
        /// Assert that a given string does not end with a sequence of characters.
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
                if ((Value != null && !string.IsNullOrEmpty(end) && Value.EndsWith(end, StringComparison.OrdinalIgnoreCase)) ||
                    (Value == null && end == null))
                {
                    var context = Context.GetCallerContext(testMethodName, end, sourceCodePath, lineNumber);
                    throw Context.GetFormattedException(testMethodName, context, $"\"{Value}\"", $"not to end with \"{end}\"", because);
                }
            }
            else
            {
                if ((Value != null && !string.IsNullOrEmpty(end) && Value.EndsWith(end)) || (Value == null && end == null))
                {
                    var context = Context.GetCallerContext(testMethodName, end, sourceCodePath, lineNumber);
                    throw Context.GetFormattedException(testMethodName, context, $"\"{Value}\"", $"not to end with \"{end}\"", because);
                }
            }
        }

        /// <summary>
        /// Assert that a given string does not match the specified (wildcard-)pattern.
        /// </summary>
        /// <param name="pattern"> The (wildcard-)pattern that should match. </param>
        /// <param name="because"> A reason why this assertion needs to be correct. </param>
        /// <param name="ignoreCase"> False if the string comparison should be case sensitive, false otherwise. </param>
        /// <param name="testMethodName"> Supplied by the compiler. </param>
        /// <param name="lineNumber"> Supplied by the compiler. </param>
        /// <param name="sourceCodePath"> Supplied by the compiler. </param>
        public void Match(string pattern, string because = null, bool ignoreCase = false,
            [CallerMemberName] string testMethodName = null, [CallerLineNumber] int lineNumber = 0, [CallerFilePath] string sourceCodePath = null)
        {
            Regex regex;
            if (ignoreCase)
            {
                regex = new Regex(pattern?.Replace("*", ".*") ?? ".*", RegexOptions.IgnoreCase);
            }
            else
            {
                regex = new Regex(pattern?.Replace("*", ".*") ?? ".*");
            }

            if (regex.IsMatch(Value))
            {
                var context = Context.GetCallerContext(testMethodName, pattern, sourceCodePath, lineNumber);
                throw Context.GetFormattedException(testMethodName, context, $"\"{Value}\"", $"to not match pattern \"{pattern}\"", because);
            }
        }

        /// <summary>
        /// Assert that a given string does not match the specified regular expression.
        /// </summary>
        /// <param name="regex"> The regex that should match. </param>
        /// <param name="because"> A reason why this assertion needs to be correct. </param>
        /// <param name="regexOptions"> The options for the regular expression. </param>
        /// <param name="testMethodName"> Supplied by the compiler. </param>
        /// <param name="lineNumber"> Supplied by the compiler. </param>
        /// <param name="sourceCodePath"> Supplied by the compiler. </param>
        public void MatchRegex(string regex, string because = null, RegexOptions regexOptions = RegexOptions.None,
            [CallerMemberName] string testMethodName = null, [CallerLineNumber] int lineNumber = 0, [CallerFilePath] string sourceCodePath = null)
        {
            var expression = new Regex(regex ?? ".", regexOptions);

            if (expression.IsMatch(Value))
            {
                var context = Context.GetCallerContext(testMethodName, regex, sourceCodePath, lineNumber);
                throw Context.GetFormattedException(testMethodName, context, $"\"{Value}\"", $"to not match regular expression \"{regex}\"", because);
            }
        }

        /// <summary>
        /// Assert that a given string does not start with a sequence of characters.
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
                if ((Value != null && !string.IsNullOrEmpty(start) && Value.StartsWith(start, StringComparison.OrdinalIgnoreCase)) ||
                    (Value == null && start == null))
                {
                    var context = Context.GetCallerContext(testMethodName, start, sourceCodePath, lineNumber);
                    throw Context.GetFormattedException(testMethodName, context, $"\"{Value}\"", $"not to start with \"{start}\"", because);
                }
            }
            else
            {
                if ((Value != null && !string.IsNullOrEmpty(start) && Value.StartsWith(start)) ||
                    (Value == null && start == null))
                {
                    var context = Context.GetCallerContext(testMethodName, start, sourceCodePath, lineNumber);
                    throw Context.GetFormattedException(testMethodName, context, $"\"{Value}\"", $"not to start with \"{start}\"", because);
                }
            }
        }

        #endregion
    }
}